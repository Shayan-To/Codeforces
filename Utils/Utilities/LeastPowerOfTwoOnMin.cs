namespace Utils
{
    public static partial class Utilities
    {
        public static int LeastPowerOfTwoOnMin(int Min)
        {
            if (Min < 1)
            {
                return 1;
            }

            // If Min is a power of two, we should return Min, otherwise, Min * 2
            var T = (Min - 1) & Min;
            if (T == 0)
            {
                return Min;
            }

            Min = T;

            while (true)
            {
                T = (Min - 1) & Min;
                if (T == 0)
                {
                    return Min << 1;
                }

                Min = T;
            }
        }
    }
}
