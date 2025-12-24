using System.Threading.Tasks;

using Utils._ScannerExtensions;

using static Utils._Commons.Commons;

namespace C2179
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var (k, x) in In.ReadWordListAsync<int, int>(await In.ReadWordAsync<int>()))
            {
                OutLine($"{k * x + 1}");
            }
        }
    }
}
