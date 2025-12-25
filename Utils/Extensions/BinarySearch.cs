using Utils._MathI;

namespace Utils.Extensions._BinarySearch;

public static partial class Utilities
{
    /// <summary>
    /// Gets the interval which equals to `value` inside a sorted list.
    /// </summary>
    /// <param name="value">The value to look for.</param>
    /// <returns>
    /// Index of the fist occurrance of `value`, together with the count of its occurrances.
    /// If no occurrance of `value` is found, index will be at the first element larger than `value`.
    /// </returns>
    public static (int Index, int Count) BinarySearch<T, TValue>(this IReadOnlyList<T> self, TValue value, Func<T, TValue, int> comp)
    {
        var count = MathI.LeastPowerOfTwoOnMin(self.Count + 1) / 2;
        var offset1 = -1;

        while (count > 0)
        {
            if ((offset1 + count) < self.Count)
            {
                var c = comp.Invoke(self[offset1 + count], value);
                if (c < 0)
                {
                    offset1 += count;
                }
                else if (c == 0)
                {
                    break;
                }
            }
            count /= 2;
        }

        var offset2 = offset1;
        if (count > 0)
        {
            // This should have been done in the `else if` block in the previous loop before the break statement.
            offset2 += count;

            while (count > 1)
            {
                count /= 2;
                if ((offset1 + count) < self.Count)
                {
                    if (comp.Invoke(self[offset1 + count], value) < 0)
                    {
                        offset1 += count;
                    }
                }
                if ((offset2 + count) < self.Count)
                {
                    if (comp.Invoke(self[offset2 + count], value) <= 0)
                    {
                        offset2 += count;
                    }
                }
            }
        }

        return (offset1 + 1, offset2 - offset1);
    }
}
