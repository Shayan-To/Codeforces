namespace C282
{
    public static class A
    {
        public static async Task Main()
        {
            var x = 0;
            await foreach (var cmd in In.ReadWordListAsync(await In.ReadWordAsync<int>()))
            {
                x += cmd.Contains('+') ? +1 : -1;
            }
            OutLine($"{x}");
        }
    }
}
