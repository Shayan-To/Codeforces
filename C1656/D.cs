using System;
using System.Linq;
using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C1656
{
    public static class D
    {
        public static async Task Main()
        {
            foreach (var ti in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadLongAsync();
                var m = n;
                var res = default(long?);

                var p2 = 1L;
                while (m % 2 == 0)
                {
                    m /= 2;
                    p2 *= 2;
                }
                ErrLine($"p2 {p2}");

                p2 *= 2;
                if ((double)p2 * (p2 + 1) <= n * 2)
                {
                    res = p2;
                }
                else if (m != 1 && (double)m * (m + 1) <= n * 2)
                {
                    res = m;
                }
                else
                {
                    for (var i = 3; (double)i * i <= m && (double)i * (i + 1) <= n * 2; i += 2)
                    {
                        if (n % i == 0)
                        {
                            res = i;
                            break;
                        }
                    }
                }
                ErrLine($"res {(double?)res * (res + 1) ?? -1} <= {n * 2}");

                OutLine($"{res ?? -1}");
            }
        }
    }
}
