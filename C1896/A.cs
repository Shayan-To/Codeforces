using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons
// #util MathI

namespace C1896
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var l = await In.ReadWordListAsync<int>(n).ToArrayAsync();
                if (l.First() == 1)
                {
                    OutLine("Yes");
                }
                else
                {
                    OutLine("No");
                }
            }
        }
    }
}
