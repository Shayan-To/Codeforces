using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infra
{
    public static class Program
    {
        public static async Task Main()
        {
            if ((Options.Mode & Mode.Generate) == Mode.Generate)
            {
                if (Options.Generation.ClearRoot)
                {
                    if (Directory.Exists(Paths.GenerationRoot))
                    {
                        Directory.Delete(Paths.GenerationRoot, true);
                    }
                    if (File.Exists(Paths.GenerationRoot))
                    {
                        File.Delete(Paths.GenerationRoot);
                    }
                }
                if (!Directory.Exists(Paths.GenerationRoot))
                {
                    Directory.CreateDirectory(Paths.GenerationRoot);
                }

                if (Options.Mode == Mode.GenerateAll)
                {
                    foreach (var solution in Assembly.GetEntryAssembly()!.GetTypes().Where(t => Regex.IsMatch(t.FullName, @"^C\d+\.[A-Z]$")))
                    {
                        await GenerateForSolutionAsync(solution);
                    }
                    Console.WriteLine("All sources generated.");
                }
                else
                {
                    await GenerateForSolutionAsync(Options.Solution);
                    Console.WriteLine("Source generated.");
                }
            }

            if ((Options.Mode & Mode.Run) == Mode.Run)
            {
                Console.WriteLine("Running...");
                var res = Options.Solution.GetMethod("Main", BindingFlags.Static | BindingFlags.Public)!.Invoke(null, null);
                if (res is Task t)
                {
                    await t;
                }
            }

            async Task GenerateForSolutionAsync(Type solution)
            {
                using var writer = new StreamWriter(Path.Combine(Paths.GenerationRoot, $"{Options.Generation.GetFileName(solution)}.cs"));
                await GenerateForSolutionToAsync(solution, writer);
            }

            async Task GenerateForSolutionToAsync(Type solution, TextWriter writer)
            {
                var utils = new HashSet<string>();

                var usings = new List<string>();
                var lines = new List<string>();

                await ReadSourceRecAsync(solution.Namespace ?? "", solution.Name);

                await writer.WriteLineAsync("#nullable enable");
                await writer.WriteLineAsync();

                foreach (var l in usings.OrderBy(s => s).Distinct())
                {
                    await writer.WriteLineAsync(l);
                }

                foreach (var l in lines)
                {
                    await writer.WriteLineAsync(l);
                }

                async Task ReadSourceRecAsync(string directory, string name)
                {
                    var src = await ReadSourceAsync(directory, name);
                    usings.AddRange(src.Usings);
                    lines.AddRange(src.Lines.Prepend(""));

                    foreach (var u in src.Utils.Where(u => utils.Add(u)))
                    {
                        await ReadSourceRecAsync("Utils", u);
                    }
                }
            }

            async Task<(IEnumerable<string> Usings, IEnumerable<string> Utils, IEnumerable<string> Lines)> ReadSourceAsync(string directory, string name)
            {
                var names = name.Split("/");
                var paths = new[] { Paths.ProjectRoot, directory }.Concat(names.SkipLast(1)).Append($"{names.Last()}.cs").ToArray();
                var lines = (await File.ReadAllLinesAsync(Path.Combine(paths))).AsEnumerable();
                var usings = lines.TakeWhile(l => Regex.IsMatch(l, @"^\s*(?:using\s.*;)?\s*$")).ToArray();
                lines = lines.Skip(usings.Length);
                var utils = lines.TakeWhile(l => Regex.IsMatch(l, @"^\s*(?:// ?#util\s.*)?$")).ToArray();
                lines = lines.Skip(utils.Length);

                return (
                    Usings: usings.Select(l => Regex.Replace(l, @"\s+", " "))
                                .Select(l => Regex.Replace(l, @"^ | $| (?=;)", ""))
                                .Where(l => l.Length != 0),
                    Utils: utils.Select(l => Regex.Replace(l, @"\s+", " "))
                                .Select(l => Regex.Replace(l, @"^ | $", ""))
                                .Select(l => Regex.Replace(l, @"^// ?#util ", ""))
                                .Where(l => l.Length != 0),
                    Lines: lines
                );
            }
        }
    }
}
