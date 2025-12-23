using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C2179
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var list = await In.ReadWordListAsync<int>(n).ToArrayAsync();
                var diff1 = list.Zip(list.Skip(1)).Select(p => Math.Abs(p.First - p.Second)).Prepend(0).Append(0).ToArray();
                var diff2 = list.Zip(list.Skip(2)).Select(p => Math.Abs(p.First - p.Second)).Prepend(0).Append(0).ToArray();
                var minChange = Range(list.Length).Min(i => diff2[i] - diff1[i] - diff1[i + 1]);
                OutLine($"{diff1.Sum() + minChange}");
            }
        }
    }
}
