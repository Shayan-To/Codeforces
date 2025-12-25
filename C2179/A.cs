namespace C2179;

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
