using System.Linq;
using System.Threading.Tasks;

using Utils._ScannerExtensions;
using Utils.Extensions._Common;

using static Utils._Commons.Commons;

namespace C2039
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                OutLine($"{RangeSC(1, n).Select(i => 2 * i - 1).JoinToString()}");
            }
        }
    }
}
