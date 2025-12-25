namespace C1787
{
    public static class Test
    {
        public static async Task Main()
        {
            await Task.CompletedTask;
            int? a = default;
            OutLine($"{a} {a + 1} {a == 0} {a > 0} {a < 0} {a >= 0} {a <= 0} {0 == a} {0 > a} {0 < a} {0 >= a} {0 <= a}");
            a = 4;
            OutLine($"{a} {a + 1} {a == 0} {a > 0} {a < 0} {a >= 0} {a <= 0} {0 == a} {0 > a} {0 < a} {0 >= a} {0 <= a}");
        }
    }
}
