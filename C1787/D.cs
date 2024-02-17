using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;


// #util Commons

namespace C1787
{
    public static class D
    {
        public static async Task Main()
        {
            var t = 0;
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                t += 1;
                var print = t > 4044;
                var l = await In.ReadWordListAsync<int>(n).ToArrayAsync();

                for (var i = 0; i < n; i += 1)
                {
                    l[i] += i;
                }

if (print)
                ErrLine(Enumerable.Range(0, n).JoinToString());
if (print)
                ErrLine(l.JoinToString());

                var mk = new bool[n];
                var bh = new int?[n];

                Dfs(0, true);
                for (var i = 1; i < n; i += 1)
                {
                    Dfs(i, false);
                }

if (print)
                ErrLine(bh.Select(b => b ?? -1).JoinToString());

                var pathLen = 0;
                var r = 0;
                Array.Clear(mk);
                for (var i = 0; 0 <= i && i < n; i = l[i])
                {
                    if (mk[i])
                    {
                        break;
                    }
                    mk[i] = true;
                    pathLen += 1;
                    var bb = bh[i] ?? int.MaxValue;
                    var c = n + 1 + bh.Count(b => b <= bb) - (bh[i].HasValue ? 1 : 0);
if (print)
                    ErrLine($"c {i} {c}");
                    r += c;
                }

                if (bh[0].HasValue)
                {
                    for (var i = 0; i < n; i += 1)
                    {
                        if (mk[i])
                        {
                            continue;
                        }
                        var c = 2 * n + 1;
if (print)
                        ErrLine($"n {i} {c}");
                        r += c;
                    }
                }

                OutLine($"{r}");

                int? Dfs(int i, bool mainPath)
                {
                    Assert.NonNull(l);
                    Assert.NonNull(mk);
                    Assert.NonNull(bh);

                    if (i < 0 || i >= n)
                    {
                        return mainPath ? 1 : 0;
                    }

                    if (mk[i])
                    {
                        return bh[i];
                    }
                    mk[i] = true;

                    var b = Dfs(l[i], mainPath);
                    return bh[i] = (b ?? -1) <= 0 ? b : b + 1;
                }
            }
        }
    }
}
