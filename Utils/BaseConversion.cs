using Utils._Verify;
using Utils.Extensions._Common;

namespace Utils._BaseConversion
{
    public static class BaseConversion
    {

        public static string ConvertToBase(long n, char[] digits, char negativeSign = '-')
        {
            var isNegative = n < 0;
            if (isNegative)
            {
                n = -n;
            }

            var res = new List<char>();
            var @base = digits.Length;

            while (n != 0)
            {
                res.Add(digits[n % @base]);
                n /= @base;
            }

            if (isNegative)
            {
                res.Add(negativeSign);
            }

            res.Reverse();

            return new string(res.ToArray());
        }

        public static long ConvertFromBase(string n, char[] digits, char negativeSign = '-')
        {
            var i = 0;
            var isNegative = n[i] == negativeSign;
            if (isNegative)
            {
                i += 1;
            }

            var res = 0L;
            var @base = digits.Length;
            for (; i < n.Length; i++)
            {
                var t = Array.IndexOf(digits, n[i]);
                Verify.False(t == -1, $"Invalid digit at index {i}.");
                res = res * @base + t;
            }

            if (isNegative)
            {
                res = -res;
            }

            return res;
        }

        public static string ConvertToBaseU(ulong n, char[] digits)
        {
            var res = new List<char>();
            var @base = (uint)digits.Length;

            while (n != 0)
            {
                res.Add(digits[n % @base]);
                n /= @base;
            }

            res.Reverse();

            return new string(res.ToArray());
        }

        public static ulong ConvertFromBaseU(string n, char[] digits)
        {
            var i = 0;

            var res = 0UL;
            var @base = (uint)digits.Length;
            for (; i < n.Length; i += 1)
            {
                var T = Array.IndexOf(digits, n[i]);
                Verify.False(T == -1, $"Invalid digit at index {i}.");
                res = res * @base + (ulong)T;
            }

            return res;
        }

        public static string ConvertToBase(long n, int @base)
        {
            return ConvertToBase(n, Digits[@base]);
        }

        public static long ConvertFromBase(string n, int @base)
        {
            return ConvertFromBase(n, Digits[@base]);
        }

        public static string ConvertToBaseU(ulong n, int @base)
        {
            return ConvertToBaseU(n, Digits[@base]);
        }

        public static ulong ConvertFromBaseU(string n, int @base)
        {
            return ConvertFromBaseU(n, Digits[@base]);
        }

        private static readonly char[][] Digits = new Func<char[][]>(() =>
        {
            var d = Enumerable.Concat(Enumerable.Range(0, 10).Select(i => (char)('0' + i)), Enumerable.Range(0, 26).Select(i => (char)('a' + i)))
                            .ToArray();
            return Enumerable.Range(2, d.Length - 2).Select(i => d.Subarray(0, i)).ToArray();
        }).Invoke();

    }
}
