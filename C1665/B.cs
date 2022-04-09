using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons
// #util AutoDictionary

namespace C1665
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadIntListAsync(await In.ReadIntAsync()))
            {
                var dic = new AutoDictionary<int, int>();
                await foreach (var i in In.ReadIntListAsync(n))
                {
                    dic[i] += 1;
                }

                var count = dic.Max(kv => kv.Value);
                var steps = 0;
                while (count < n)
                {
                    steps += 1 + Math.Min(n - count, count);
                    count *= 2;
                }
                OutLine($"{steps}");
            }
        }
    }
}
