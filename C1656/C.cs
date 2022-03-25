using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C1656
{
    public static class C
    {
        public static async Task Main()
        {
            foreach (var ti in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadIntAsync();
                var l = new List<int>();
                foreach (var i in Enumerable.Range(0, n))
                {
                    l.Add(await In.ReadIntAsync());
                }
                l.Sort();
                ErrLine(l.Select(i => $"{i}").Aggregate((p, c) => $"{p} {c}"));

                var bl = true;

                if (l.BinarySearch(1) >= 0)
                {
                    foreach (var i in Enumerable.Range(0, l.Count - 1))
                    {
                        if (l[i] == l[i + 1] - 1)
                        {
                            bl = false;
                            ErrLine($"{l[i]} {l[i + 1]}");
                            if (!IsLocal)
                            {
                                break;
                            }
                        }
                    }
                }

                OutLine(bl ? "Yes" : "No");
            }
        }
    }
}
