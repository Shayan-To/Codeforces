using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C1656
{
    public static class B
    {
        public static async Task Main()
        {
            foreach (var ti in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadIntAsync();
                var k = await In.ReadIntAsync();
                var l = new List<int>();
                foreach (var i in Enumerable.Range(0, n))
                {
                    l.Add(await In.ReadIntAsync());
                }
                l.Sort();

                var bl = false;
                foreach (var i in Enumerable.Range(0, l.Count))
                {
                    int j = l.BinarySearch(i, l.Count - i, l[i] + k, null);
                    if (j >= 0)
                    {
                        bl = true;
                        ErrLine($"{i} {l[i]}     {j} {l[j]}");
                        if (!IsLocal)
                        {
                            break;
                        }
                    }
                }

                OutLine(bl ? "Yes" : "No");
            }
        }
    }
}
