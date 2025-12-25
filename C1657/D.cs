namespace C1657;

public static class D
{
    public static async Task Main()
    {
        var n = await In.ReadWordAsync<int>();
        var c = await In.ReadWordAsync<int>();

        foreach (var _ in Range(n))
        {
            var unit = new Unit()
            {
                Cost = await In.ReadWordAsync<int>(),
                Damage = await In.ReadWordAsync<int>(),
                Health = await In.ReadWordAsync<int>(),
            };
        }

        var m = await In.ReadWordAsync<int>();
        foreach (var _ in Range(m))
        {

        }
    }

    public class Unit
    {
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
    }
}
