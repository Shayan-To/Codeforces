using Utils.Extensions._Common;

namespace C2179
{
    public static class D
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                OutLine(GenerateList(n).JoinToString());
                if (IsLocal)
                {
                    foreach (var i in GenerateList(n))
                    {
                        ErrLine(i.ToString($"B{n}"));
                    }
                }
            }
        }

        public static IEnumerable<int> GenerateList(int n)
        {
            for (var i = n; i >= 0; i -= 1)
            {
                var e = (1 << i) - 1;

                var remainingLength = Math.Max(0, n - i - 1);
                for (var j = 0; j < (1 << remainingLength); j += 1)
                {
                    yield return e | (j << (i + 1));
                }
            }
        }
    }
}
