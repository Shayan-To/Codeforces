using Utils.Extensions._Common;

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
