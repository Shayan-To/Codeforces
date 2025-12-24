using System.Threading.Tasks;

using Utils._ScannerExtensions;

using static Utils._Commons.Commons;

namespace C1665
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                OutLine($"{n - 3} 1 1 1");
            }
        }
    }
}
