using System;
using System.Collections.Generic;

// #util Utilities/LeastPowerOfTwoOnMin

namespace Utils
{
    public static partial class Utilities
    {
        /// <summary>
        /// Gets the interval in which Value resides in inside a sorted list.
        /// </summary>
        /// <param name="Value">The value to look for.</param>
        /// <returns>
        /// Start index being the index of fist occurrance of Value, and length being the count of its occurrances.
        /// If no occurrance of Value is found, start index will be at the first element larger than Value.
        /// </returns>
        public static (int Index, int Count) BinarySearch<T, TValue>(this IReadOnlyList<T> Self, TValue Value, Func<T, TValue, int> Comp)
        {
            var Count = LeastPowerOfTwoOnMin(Self.Count + 1) / 2;
            var Offset1 = -1;

            while (Count > 0)
            {
                if ((Offset1 + Count) < Self.Count)
                {
                    var C = Comp.Invoke(Self[Offset1 + Count], Value);
                    if (C < 0)
                    {
                        Offset1 += Count;
                    }
                    else if (C == 0)
                    {
                        break;
                    }
                }
                Count /= 2;
            }

            var Offset2 = Offset1;
            if (Count > 0)
            {
                // This should h ave been done in the ElseIf block in the previous loop before the Exit statement.
                Offset2 += Count;

                while (Count > 1)
                {
                    Count /= 2;
                    if ((Offset1 + Count) < Self.Count)
                    {
                        if (Comp.Invoke(Self[Offset1 + Count], Value) < 0)
                        {
                            Offset1 += Count;
                        }
                    }
                    if ((Offset2 + Count) < Self.Count)
                    {
                        if (Comp.Invoke(Self[Offset2 + Count], Value) <= 0)
                        {
                            Offset2 += Count;
                        }
                    }
                }
            }

            return (Offset1 + 1, Offset2 - Offset1);
        }
    }
}
