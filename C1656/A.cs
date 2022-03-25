using System;
using System.Linq;
using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C1656
{
    public static class A
    {
        public static async Task Main()
        {
            foreach (var ti in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadIntAsync();
                var (min, minI) = (int.MaxValue, -1);
                var (max, maxI) = (int.MinValue, -1);
                foreach (var i in Enumerable.Range(0, n))
                {
                    var x = await In.ReadIntAsync();
                    if (min > x)
                    {
                        min = x;
                        minI = i;
                    }
                    if (max < x)
                    {
                        max = x;
                        maxI = i;
                    }
                }
                OutLine($"{minI + 1} {maxI + 1}");
            }
        }
    }
}
