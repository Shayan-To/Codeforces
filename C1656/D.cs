namespace C1656
{
    public static class D
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<long>(await In.ReadWordAsync<int>()))
            {
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
