using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C282
{
    public static class A
    {
        public static async Task Main()
        {
            var x = 0;
            await foreach (var cmd in In.ReadWordListAsync(await In.ReadIntAsync()))
            {
                x += cmd.Contains('+') ? +1 : -1;
            }
            OutLine($"{x}");
        }
    }
}
