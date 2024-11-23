using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons
// #util MathI
// #util AutoDictionary

namespace C1737
{
    public static class B
    {
        public static async Task Main()
        {
            // PrintSample();
            // TestCountDivisibles();
            await foreach (var (f, t) in In.ReadWordListAsync<long, long>(await In.ReadWordAsync<int>()))
            {
                var fr = MathI.SquareRoot(f).Root;
                var tr = MathI.SquareRoot(t).Root;

                var res = 0L;

                res += CountDivisibles(f, Math.Min(t + 1, (fr + 1) * (fr + 1)), fr);
                if (fr != tr)
                {
                    res += (tr - fr - 1) * 3;
                    res += CountDivisibles(tr * tr, t + 1, tr);
                }

                // for (var i = fr; i <= tr; i += 1)
                // {
                //     res += CountDivisibles(Math.Max(f, i * i), Math.Min(t + 1, (i + 1) * (i + 1)), i);
                // }

                OutLine($"{res}");
            }
        }

        private static long CountDivisibles(long from, long to, long divisor)
        {
            from += divisor - MathI.PosMod(from, divisor);
            to -= MathI.PosMod(to, divisor);
            return (to - from) / divisor + 1;
        }

        private static void TestCountDivisibles()
        {
            var r = new Random(42423);
            foreach (var _ in Range(200))
            {
                var start = r.Next(0, 100);
                var count = r.Next(5, 20);
                var divisor = r.Next(1, 10);

                ErrLine($"{start}-{start + count} / {divisor} => {CountDivisibles(start, start + count, divisor)}   {RangeSC(start, count).JoinToString(i => i % divisor == 0 ? $"({i})" : $"{i}")}");
            }
        }

        private static void PrintSample()
        {
            var bn = new AutoDictionary<int, StringBuilder>();
            var br = new AutoDictionary<int, StringBuilder>();
            var bil = new AutoDictionary<int, StringBuilder>();

            var pl = 50;

            foreach (var n in RangeSC(1, 1000))
            {
                var ns = n.ToString().Length;
                bn[n / pl].AppendFormat($"{{0,{ns}}} ", n);
                br[n / pl].AppendFormat($"{{0,{ns}}} ", MathI.SquareRoot(n).Root);
                bil[n / pl].AppendFormat($"{{0,{ns}}} ", n % MathI.SquareRoot(n).Root == 0 ? "*" : "");
            }

            foreach (var i in Range(bn.Count))
            {
                ErrLine(bn[i].ToString());
                ErrLine(br[i].ToString());
                ErrLine(bil[i].ToString());
            }
        }
    }
}
