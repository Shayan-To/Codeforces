using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C1665
{
    public static class B
    {
        public static async Task Main()
        {
            foreach (var _ in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadIntAsync();
                var dic = new Dictionary<int, int>();
                foreach (var ii in Enumerable.Range(0, n))
                {
                    var i = await In.ReadIntAsync();
                    if (!dic.ContainsKey(i))
                    {
                        dic[i] = 0;
                    }
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
