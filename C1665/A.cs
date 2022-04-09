using System;
using System.Linq;
using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C1665
{
    public static class A
    {
        public static async Task Main()
        {
            foreach (var _ in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadIntAsync();
                OutLine($"{n - 3} 1 1 1");
            }
        }
    }
}
