using System;
using System.Diagnostics;

// #util Scanner
// #util ScannerExtensions
// #util Utilities/Common

namespace Utils
{
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static readonly Scanner In = new Scanner(Console.In);

        public static readonly bool IsLocal =
#if LOCAL
                true;
#else
                false;
#endif
    }
}
