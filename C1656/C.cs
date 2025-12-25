using Utils.Extensions._AdvancedLinq;
using Utils.Extensions._Common;

namespace C1656;

public static class C
{
    public static async Task Main()
    {
        await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
        {
            var l = await In.ReadWordListAsync<int>(n).ToListAsync();
            l.Sort();
            ErrLine(l.JoinToString());

            var bl = true;

            if (l.BinarySearch(1) >= 0)
            {
                foreach (var (prev, cur) in l.ZipNeighbors())
                {
                    if (prev == cur - 1)
                    {
                        bl = false;
                        ErrLine($"{prev} {cur}");
                        if (!IsLocal)
                        {
                            break;
                        }
                    }
                }
            }

            OutLine(bl ? "Yes" : "No");
        }
    }
}
