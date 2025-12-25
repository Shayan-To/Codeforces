using System.Text;

using Utils._Verify;

namespace Utils.Extensions._Common;

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
        (self[i2], self[i1]) = (self[i1], self[i2]);
    }
    #endregion
}
