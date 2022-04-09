using System;
using System.Collections.Generic;

// #util Verify

namespace Utils
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

        public static T MinOn<T, TKey>(this IEnumerable<T> self, Func<T, TKey> keySelector)
        {
            return self.MinOn(keySelector, Comparer<TKey>.Default);
        }

        public static T MinOn<T, TKey>(this IEnumerable<T> self, Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            var minKey = default(TKey);
            var min = default(T);
            var bl = true;
            foreach (var i in self)
            {
                if (bl)
                {
                    min = i;
                    minKey = keySelector(i);
                    bl = false;
                    continue;
                }

                var key = keySelector(i);
                if (comparer.Compare(key, minKey) < 0)
                {
                    min = i;
                    minKey = key;
                }
            }

            Verify.False(bl, "Collection contains no elements.");
            return min!;
        }

        public static T MaxOn<T, TKey>(this IEnumerable<T> self, Func<T, TKey> keySelector)
        {
            return self.MaxOn(keySelector, Comparer<TKey>.Default);
        }

        public static T MaxOn<T, TKey>(this IEnumerable<T> self, Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            var maxKey = default(TKey);
            var max = default(T);
            var bl = true;
            foreach (var i in self)
            {
                if (bl)
                {
                    max = i;
                    maxKey = keySelector(i);
                    bl = false;
                    continue;
                }

                var key = keySelector(i);
                if (comparer.Compare(key, maxKey) > 0)
                {
                    max = i;
                    maxKey = key;
                }
            }

            Verify.False(bl, "Collection contains no elements.");
            return max!;
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
            var bl = true;
            var prev = default(T);
            foreach (var i in self)
            {
                if (bl)
                {
                    bl = false;
                    prev = i;
                    continue;
                }
                yield return (prev!, i);
                prev = i;
            }
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
