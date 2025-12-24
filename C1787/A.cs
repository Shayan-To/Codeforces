using System.Threading.Tasks;


using Utils._ScannerExtensions;

using static Utils._Commons.Commons;

namespace C1787
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                if (n % 2 == 1)
                {
                    OutLine("-1");
                }
                else
                {
                    OutLine($"{1} {n / 2}");
                }
            }
        }
    }
}
