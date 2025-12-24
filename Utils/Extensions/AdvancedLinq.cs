using System;
using System.Collections.Generic;
using System.Linq;

using Utils._Verify;

namespace Utils.Extensions._AdvancedLinq
{
    public static partial class Utilities
    {
        public static void Move<T>(this IList<T> self, int oldIndex, int newIndex)
        {
            var item = self[oldIndex];
            for (var i = oldIndex; i < newIndex; i += 1)
            {
                self[i] = self[i + 1];
            }

            for (var i = oldIndex; i > newIndex; i -= 1)
            {
                self[i] = self[i - 1];
            }

            self[newIndex] = item;
        }

        public static void RemoveRange<T>(this IList<T> self, int startIndex, int length = -1)
        {
            if (length == -1)
            {
                length = self.Count - startIndex;
            }
            else if (length == 0)
            {
                return;
            }

            Verify.TrueArg(length > 0, nameof(length), "Length must be a non-negative number.");
            Verify.True((startIndex + length) <= self.Count, "The given range must be inside the list.");
            for (var i = startIndex; i < self.Count - length; i += 1)
            {
                self[i] = self[i + length];
            }

            for (var i = self.Count - 1; i >= self.Count - length; i -= 1)
            {
                self.RemoveAt(i);
            }
        }

        public static int RemoveWhere<T>(this IList<T> self, Func<T, bool> predicate, int startIndex = 0, int length = -1)
        {
            if (length == -1)
            {
                length = self.Count - startIndex;
            }
            else if (length == 0)
            {
                return 0;
            }

            Verify.TrueArg(length > 0, nameof(length), "Length must be a non-negative number.");
            Verify.True((startIndex + length) <= self.Count, "The given range must be inside the list.");

            var count = 0;
            var i = startIndex;
            for (var j = startIndex; j < startIndex + length; j += 1)
            {
                if (!predicate.Invoke(self[j]))
                {
                    self[i] = self[j];
                    i += 1;
                }
                else
                {
                    count += 1;
                }
            }

            self.RemoveRange(i, count);

            return count;
        }

        public static void ReverseSelf<T>(this IList<T> self, int index = 0, int count = -1)
        {
            if (count == -1)
            {
                count = self.Count - index;
            }

            var complement = count + (2 * index) - 1;
            var maxI = index + (count / 2);
            for (var i = index; i < maxI; i += 1)
            {
                var c = self[i];
                self[i] = self[complement - i];
                self[complement - i] = c;
            }
        }

        public static IEnumerable<T> Reverse<T>(this IReadOnlyList<T> self)
        {
            for (var i = self.Count - 1; i >= 0; i -= 1)
            {
                yield return self[i];
            }
        }

        public static IEnumerable<T> DistinctNeighbors<T>(this IEnumerable<T> self)
        {
            return self.DistinctNeighbors(EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> DistinctNeighbors<T>(this IEnumerable<T> self, IEqualityComparer<T> comparer)
        {
            var bl = true;
            var p = default(T);

            foreach (var i in self)
            {
                if (bl)
                {
                    yield return i;
                    p = i;
                    bl = false;
                }
                else if (!comparer.Equals(p, i))
                {
                    yield return i;
                    p = i;
                }
            }
        }

        public static IEnumerable<(T, T)> ZipNeighbors<T>(this IEnumerable<T> self)
        {
            return self.Zip(self.Skip(1));
        }

        public static IEnumerable<T> Cumulate<T>(this IEnumerable<T> self, Func<T, T, T> func)
        {
            var bl = true;
            var v = default(T);
            foreach (var i in self)
            {
                if (bl)
                {
                    v = i;
                    bl = false;
                }
                else
                {
                    v = func.Invoke(v!, i);
                }
                yield return v;
            }
        }

        public static IEnumerable<TCumulate> Cumulate<T, TCumulate>(this IEnumerable<T> self, TCumulate seed, Func<TCumulate, T, TCumulate> func)
        {
            var v = seed;
            foreach (var i in self)
            {
                v = func.Invoke(v, i);
                yield return v;
            }
        }
    }
}
