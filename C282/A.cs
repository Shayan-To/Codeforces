using System.Threading.Tasks;

using static Utils.Commons;

// #util Commons

namespace C282
{
    public static class A
    {
        public static async Task Main()
        {
            var n = await In.ReadIntAsync();
            var x = 0;
            for (var i = 0; i < n; i += 1)
            {
                string cmd = await In.ReadWordAsync();
                if (cmd.Contains('+'))
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            OutLine($"{x}");
        }
    }
}
