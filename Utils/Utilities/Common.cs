using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// #util Verify

namespace Utils
{
    public static partial class Utilities
    {
        #region AsyncEnumerable
        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IEnumerable<TIn> self, Func<TIn, Task<TOut>> selector)
        {
            foreach (var i in self)
            {
                yield return await selector(i);
            }
        }

        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IEnumerable<TIn> self, Func<TIn, int, Task<TOut>> selector)
        {
            var ind = 0;
            foreach (var i in self)
            {
                yield return await selector(i, ind);
                ind += 1;
            }
        }

        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> self, Func<TIn, Task<TOut>> selector)
        {
            await foreach (var i in self)
            {
                yield return await selector(i);
            }
        }

        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> self, Func<TIn, int, Task<TOut>> selector)
        {
            var ind = 0;
            await foreach (var i in self)
            {
                yield return await selector(i, ind);
                ind += 1;
            }
        }

        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> self, Func<TIn, TOut> selector)
        {
            await foreach (var i in self)
            {
                yield return selector(i);
            }
        }

        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> self, Func<TIn, int, TOut> selector)
        {
            var ind = 0;
            await foreach (var i in self)
            {
                yield return selector(i, ind);
                ind += 1;
            }
        }

        public static async Task<T> AggregateAsync<T>(this IAsyncEnumerable<T> self, Func<T, T, T> func)
        {
            var bl = true;
            var v = default(T);
            await foreach (var i in self)
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
            }
            Verify.False(bl, "Collection contains no elements.");
            return v!;
        }

        public static async Task<TAggregate> AggregateAsync<T, TAggregate>(this IAsyncEnumerable<T> self, TAggregate seed, Func<TAggregate, T, TAggregate> func)
        {
            var v = seed;
            await foreach (var i in self)
            {
                v = func.Invoke(v, i);
            }
            return v;
        }

        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> self)
        {
            var list = new List<T>();
            await foreach (var i in self)
            {
                list.Add(i);
            }
            return list;
        }

        public static async Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(this IAsyncEnumerable<T> self, Func<T, TKey> keySelector) where TKey : notnull
        {
            var dic = new Dictionary<TKey, T>();
            await foreach (var i in self)
            {
                dic.Add(keySelector(i), i);
            }
            return dic;
        }

        public static async Task<T[]> ToArrayAsync<T>(this IAsyncEnumerable<T> self)
        {
            return (await self.ToListAsync()).ToArray();
        }
        #endregion

        #region Enumerable
        public static string JoinToString<T>(this IEnumerable<T> self, string delimiter = " ")
        {
            return self.JoinToString(i => $"{i}", delimiter);
        }

        public static string JoinToString<T>(this IEnumerable<T> self, Func<T, string> toString, string delimiter = " ")
        {
            var res = new StringBuilder();
            var first = true;
            foreach (var i in self)
            {
                if (!first)
                {
                    res.Append(delimiter);
                }
                res.Append(toString(i));
                first = false;
            }
            return res.ToString();
        }

        public static IEnumerable<int> Range(this int n, int diff = 0, bool reverse = false)
        {
            if (!reverse)
            {
                for (var i = 0; i < n; i += 1)
                {
                    yield return i + diff;
                }
            }
            else
            {
                for (var i = n - 1; i >= 0; i -= 1)
                {
                    yield return i + diff;
                }
            }
        }

        public static async Task<IEnumerable<int>> RangeAsync(this Task<int> n, int diff = 0, bool reverse = false)
        {
            return (await n).Range(diff, reverse);
        }

        public static T[] Subarray<T>(this T[] self, int start, int count)
        {
            var res = new T[count];
            Array.Copy(self, start, res, 0, count);
            return res;
        }

        public static void Swap<T>(this IList<T> self, int i1, int i2)
        {
            if (i1 == i2)
            {
                return;
            }

            var c = self[i1];
            self[i1] = self[i2];
            self[i2] = c;
        }
        #endregion
    }
}
