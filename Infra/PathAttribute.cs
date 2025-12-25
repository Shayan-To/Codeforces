using System.Reflection;

namespace Infra;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class PathAttribute : Attribute
{
    public PathAttribute(string key, string path)
    {
        this.Key = key;
        this.Path = path;
    }

    public static string? GetPath(string key)
    {
        if (Paths == null)
        {
            var dic = new Dictionary<string, string>();
            foreach (var path in Assembly.GetEntryAssembly()?.GetCustomAttributes<PathAttribute>() ?? Array.Empty<PathAttribute>())
            {
                dic.Add(path.Key, path.Path);
            }
            Paths = new System.Collections.ObjectModel.ReadOnlyDictionary<string, string>(dic);
        }

        if (Paths.TryGetValue(key, out var res))
        {
            return res;
        }
        return null;
    }

    private static IReadOnlyDictionary<string, string>? Paths;

    public string Key { get; }
    public string Path { get; }
}
