using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1737
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadIntListAsync(await In.ReadIntAsync()))
            {
                var k = await In.ReadIntAsync();
                var bMax = n / k;
                var chars = await In.ReadWordAsync();

                var alph = new int['z' - 'a' + 1];

                foreach (var ch in chars)
                {
                    alph[ch - 'a'] += 1;
                }

                ErrLine(Enumerable.Range(0, 'z' - 'a' + 1).Select(i => (char)(i + 'a')).JoinToString());
                ErrLine(alph.JoinToString());

                var comps = Enumerable.Range(0, k).Select(_ => new Compartment()).ToArray();

                for (var ch = 'a'; ch <= 'z'; ch++)
                {
                    foreach (var comp in comps)
                    {
                        if (alph[ch - 'a'] == 0 || comp.Count == bMax)
                        {
                            comp.Mex = ch < comp.Mex ? ch : comp.Mex;
                        }
                        else
                        {
                            alph[ch - 'a'] -= 1;
                            comp.Count += 1;
                        }
                    }
                }

                OutLine(string.Join("", comps.Select(c => c.Mex)));
            }
        }

        public class Compartment
        {
            public char Mex { get; set; } = 'z';
            public int Count { get; set; }
        }
    }
}
