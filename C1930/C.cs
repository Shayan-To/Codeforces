using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1930
{
    public static class C
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var l = In.ReadWordListAsync<int>(n);

                // OutLine($"{r.JoinToString()}");
            }
        }
    }
}
