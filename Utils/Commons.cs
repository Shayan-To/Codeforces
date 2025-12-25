using System.Diagnostics;

using Utils._Scanner;

namespace Utils._Commons;

public static class Commons
{
    public static void OutLine(string s)
    {
#if LOCAL
        var fg = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
#endif
        Console.Out.WriteLine(s);
#if LOCAL
        Console.ForegroundColor = fg;
#endif
    }

    [Conditional("LOCAL")]
    public static void ErrLine(string s)
    {
        var fg = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(s);
        Console.ForegroundColor = fg;
    }

    public static IEnumerable<int> Range(int count)
    {
        return Enumerable.Range(0, count);
    }

    public static IEnumerable<int> RangeSC(int start, int count)
    {
        return Enumerable.Range(start, count);
    }

    public static IEnumerable<int> RangeSE(int start, int end)
    {
        return Enumerable.Range(start, end - start);
    }

    public static readonly Scanner In = new Scanner(Console.In);

    public static readonly bool IsLocal =
#if LOCAL
            true;
#else
            false;
#endif
}
