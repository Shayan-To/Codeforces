using Utils.Extensions._Common;

namespace C1656;

public static class A
{
    public static async Task Main()
    {
        await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
        {
            var (min, minI) = (int.MaxValue, -1);
            var (max, maxI) = (int.MinValue, -1);

            await foreach (var (x, i) in In.ReadWordListAsync<int>(n).SelectAsync((x, i) => (x, i)))
            {
                if (min > x)
                {
                    (min, minI) = (x, i);
                }
                if (max < x)
                {
                    (max, maxI) = (x, i);
                }
            }
            OutLine($"{minI + 1} {maxI + 1}");
        }
    }
}
