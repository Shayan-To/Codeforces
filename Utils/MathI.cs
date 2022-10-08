using System;

// #util Verify

namespace Utils
{
    public static class MathI
    {

        /// <returns>
        /// The reminder, between 0 and B - 1.
        /// </returns>
        public static int NonNegMod(int A, int B)
        {
            A %= B;
            if (A >= 0)
            {
                return A;
            }

            return A + Math.Abs(B);
        }

        /// <returns>
        /// The reminder, between 0 and B - 1.
        /// </returns>
        public static long NonNegMod(long A, long B)
        {
            A %= B;
            if (A >= 0)
            {
                return A;
            }

            return A + Math.Abs(B);
        }

        /// <returns>
        /// The reminder, between 1 and B.
        /// </returns>
        public static int PosMod(int A, int B)
        {
            A %= B;
            if (A > 0)
            {
                return A;
            }

            if (B > 0)
            {
                return A + B;
            }

            return A - B;
        }

        /// <returns>
        /// The reminder, between 1 and B.
        /// </returns>
        public static long PosMod(long A, long B)
        {
            A %= B;
            if (A > 0)
            {
                return A;
            }

            if (B > 0)
            {
                return A + B;
            }

            return A - B;
        }

        public static int Power(int a, int b)
        {
            Verify.FalseArg(b < 0, nameof(b), $"{nameof(b)} must be non-negative.");
            var r = 1;
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    r *= a;
                }

                a *= a;
                b >>= 1;
            }
            return r;
        }

        public static long Power(long a, int b)
        {
            Verify.FalseArg(b < 0, nameof(b), $"{nameof(b)} must be non-negative.");
            var r = 1L;
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    r *= a;
                }

                a *= a;
                b >>= 1;
            }
            return r;
        }

        public static (int Root, int Remainder) SquareRoot(int a)
        {
            Verify.FalseArg(a < 0, nameof(a), $"{nameof(a)} must be non-negative.");

            var aRev = 0;
            var t = a;
            while (t != 0)
            {
                aRev = (aRev << 2) | (t & 0b11);
                t >>= 2;
            }

            var remainder = 0;
            var root = 0;
            while (a != 0)
            {
                remainder = (remainder << 2) | (aRev & 0b11);

                aRev >>= 2;
                a >>= 2;

                root <<= 1;
                var root2 = (root << 1) | 1;

                if (remainder >= root2)
                {
                    root |= 1;
                    remainder -= root2;
                }
            }

            return (root, remainder);
        }

        public static (long Root, long Remainder) SquareRoot(long a)
        {
            Verify.FalseArg(a < 0, nameof(a), $"{nameof(a)} must be non-negative.");

            var aRev = 0L;
            var t = a;
            while (t != 0)
            {
                aRev = (aRev << 2) | (t & 0b11);
                t >>= 2;
            }

            var remainder = 0L;
            var root = 0L;
            while (a != 0)
            {
                remainder = (remainder << 2) | (aRev & 0b11);

                aRev >>= 2;
                a >>= 2;

                root <<= 1;
                var root2 = (root << 1) | 1;

                if (remainder >= root2)
                {
                    root |= 1;
                    remainder -= root2;
                }
            }

            return (root, remainder);
        }

        public static int LeastPowerOfTwoOnMin(int min)
        {
            if (min < 1)
            {
                return 1;
            }

            // If `min` is a power of two, we should return `min`, otherwise, `min * 2`.
            var t = (min - 1) & min;
            if (t == 0)
            {
                return min;
            }

            min = t;

            while (true)
            {
                t = (min - 1) & min;
                if (t == 0)
                {
                    return min << 1;
                }

                min = t;
            }
        }

        public static long LeastPowerOfTwoOnMin(long min)
        {
            if (min < 1)
            {
                return 1;
            }

            // If `min` is a power of two, we should return `min`, otherwise, `min * 2`.
            var t = (min - 1) & min;
            if (t == 0)
            {
                return min;
            }

            min = t;

            while (true)
            {
                t = (min - 1) & min;
                if (t == 0)
                {
                    return min << 1;
                }

                min = t;
            }
        }

        public static int FloorDiv(int a, int b)
        {
            if (b < 0)
            {
                a = -a;
                b = -b;
            }
            if (a >= 0 || a % b == 0)
            {
                return a / b;
            }

            return a / b - 1;
        }

        public static long FloorDiv(long a, long b)
        {
            if (b < 0)
            {
                a = -a;
                b = -b;
            }
            if (a >= 0 || a % b == 0)
            {
                return a / b;
            }

            return a / b - 1;
        }

        public static int CeilDiv(int a, int b)
        {
            if (b < 0)
            {
                a = -a;
                b = -b;
            }
            if (a < 0 || a % b == 0)
            {
                return a / b;
            }

            return a / b + 1;
        }

        public static long CeilDiv(long a, long b)
        {
            if (b < 0)
            {
                a = -a;
                b = -b;
            }
            if (a < 0 || a % b == 0)
            {
                return a / b;
            }

            return a / b + 1;
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            if (b < 0)
            {
                b = -b;
            }
            if (a < 0)
            {
                a = -a;
            }

            while (b != 0)
            {
                var c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            if (b < 0)
            {
                b = -b;
            }
            if (a < 0)
            {
                a = -a;
            }

            while (b != 0)
            {
                var c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        public static int LeastCommonMultiple(int a, int b)
        {
            return a / GreatestCommonDivisor(a, b) * b;
        }

        public static long LeastCommonMultiple(long a, long b)
        {
            return a / GreatestCommonDivisor(a, b) * b;
        }

        public static (int Log, long Remainder) Logarithm(long n, long @base)
        {
            var remainder = 0L;
            var power = 1L;
            var log = 0;
            while (n != 0)
            {
#pragma warning disable IDE0047 // Parentheses can be removed
                remainder += (n % @base) * power;
#pragma warning restore IDE0047 // Parentheses can be removed
                n /= @base;
                power *= @base;
                log += 1;
            }
            return (log, remainder);
        }
    }
}
