using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1737
{
    public static class C
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var (r1, c1) = await In.ReadWordAsync<int, int>();
                var (r2, c2) = await In.ReadWordAsync<int, int>();
                var (r3, c3) = await In.ReadWordAsync<int, int>();
                var (x, y) = await In.ReadWordAsync<int, int>();

                var r = r1 == r2 ? r1 : r3;
                var c = c1 == c2 ? c1 : c3;

                var possible = x % 2 == r % 2 || y % 2 == c % 2;

                if ((r == 1 || r == n) && (c == 1 || c == n))
                {
                    possible = x == r || y == c;
                }

                OutLine(possible ? "YES" : "NO");
            }
        }

        public class Compartment
        {
            public char Mex { get; set; } = 'z';
            public int Count { get; set; }
        }
    }
}
