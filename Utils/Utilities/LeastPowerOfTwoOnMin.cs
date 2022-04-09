namespace Utils
{
    public static partial class Utilities
    {
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
    }
}
