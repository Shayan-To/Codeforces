using Utils.Extensions._Common;

namespace C1737;

public static class A
{
    public static async Task Main()
    {
        await foreach (var (n, k) in In.ReadWordListAsync<int, int>(await In.ReadWordAsync<int>()))
        {
            var bMax = n / k;
            var chars = await In.ReadWordAsync();

            var alph = new int['z' - 'a' + 1];

            foreach (var ch in chars)
            {
                alph[ch - 'a'] += 1;
            }

            ErrLine(Range('z' - 'a' + 1).Select(i => (char)(i + 'a')).JoinToString());
            ErrLine(alph.JoinToString());

            var comps = Range(k).Select(_ => new Compartment()).ToArray();

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
