using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1656
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadIntListAsync(await In.ReadIntAsync()))
            {
                var (min, minI) = (int.MaxValue, -1);
                var (max, maxI) = (int.MinValue, -1);

                await foreach (var (x, i) in In.ReadIntListAsync(n).SelectAsync((x, i) => (x, i)))
                {
                    if (min > x)
                    {
                        (min, minI) = (x, i);
                    }
                    if (max < x)
                    {
                        (max, maxI) = (x, i);
                    }
                }
                OutLine($"{minI + 1} {maxI + 1}");
            }
        }
    }
}
