namespace C1896
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var (_, s) in In.ReadWordListAsync<int, string>(await In.ReadWordAsync<int>()))
            {
                var firstA = s.IndexOf('A');
                var lastB = s.LastIndexOf('B');
                firstA = firstA == -1 ? s.Length : firstA;
                OutLine($"{Math.Max(0, lastB - firstA)}");
            }
        }
    }
}
