using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1665
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadIntListAsync(await In.ReadIntAsync()))
            {
                OutLine($"{n - 3} 1 1 1");
            }
        }
    }
}
