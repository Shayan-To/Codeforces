using Utils.Extensions._Common;

namespace C1930
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var h = n / 2;
                var r = RangeSC(1, h).SelectMany(i => new[] { i, i + h });
                if (n % 2 == 1)
                {
                    r = r.Append(n);
                }
                OutLine($"{r.JoinToString()}");
            }
        }
    }
}
