using System.Linq;
using System.Threading.Tasks;

using Utils._ScannerExtensions;
using Utils.Extensions._Common;

using static Utils._Commons.Commons;

namespace C1930
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var l = await In.ReadWordListAsync<int>(2 * n).ToArrayAsync();
                OutLine($"{l.OrderBy(i => i).Where((_, i) => i % 2 == 0).Sum()}");
            }
        }
    }
}
