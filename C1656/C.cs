using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons
// #util Utilities/AdvancedLinq

namespace C1656
{
    public static class C
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadIntListAsync(await In.ReadIntAsync()))
            {
                var l = await In.ReadIntListAsync(n).ToListAsync();
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
}
