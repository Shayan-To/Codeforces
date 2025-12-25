using Utils.Extensions._Common;

namespace C1787
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var nn in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var n = nn;
                var l = new List<int>();

                for (var k = 2; k * k <= n; k += 1)
                {
                    for (var i = 0; n % k == 0; i += 1)
                    {
                        n /= k;
                        if (i < l.Count)
                        {
                            l[i] *= k;
                        }
                        else
                        {
                            l.Add(k);
                        }
                    }
                }

                if (n != 1)
                {
                    if (0 < l.Count)
                    {
                        l[0] *= n;
                    }
                    else
                    {
                        l.Add(n);
                    }
                }

                ErrLine($"{l.JoinToString()}");

                OutLine($"{l.Sum()}");
            }
        }
    }
}
