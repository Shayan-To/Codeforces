using Utils._Scanner;

namespace Utils._ScannerExtensions;

public static class ScannerExtensions
{
    private abstract class Parser { }
    private abstract class Parser<T> : Parser { public abstract T Parse(string s); }
    private class StringParser : Parser<string> { public override string Parse(string s) => s; }
    private class IntParser : Parser<int> { public override int Parse(string s) => int.Parse(s); }
    private class LongParser : Parser<long> { public override long Parse(string s) => long.Parse(s); }
    private class DoubleParser : Parser<double> { public override double Parse(string s) => double.Parse(s); }
    private class SingleParser : Parser<float> { public override float Parse(string s) => float.Parse(s); }
    private class DecimalParser : Parser<decimal> { public override decimal Parse(string s) => decimal.Parse(s); }

    private static readonly Dictionary<Type, Parser> parsers = new Dictionary<Type, Parser>()
    {
        [typeof(string)] = new StringParser(),
        [typeof(int)] = new IntParser(),
        [typeof(long)] = new LongParser(),
        [typeof(double)] = new DoubleParser(),
        [typeof(float)] = new SingleParser(),
        [typeof(decimal)] = new DecimalParser(),
    };

    private static Parser<T> GetParser<T>()
    {
        return (Parser<T>)parsers[typeof(T)];
    }

    private static T Parse<T>(string s)
    {
        return GetParser<T>().Parse(s);
    }

    public static async Task<T> ReadWordAsync<T>(this Scanner self)
    {
        return Parse<T>(await self.ReadWordAsync());
    }

    public static async Task<(T1, T2)> ReadWordAsync<T1, T2>(this Scanner self)
    {
        return (await self.ReadWordAsync<T1>(), await self.ReadWordAsync<T2>());
    }

    public static async Task<(T1, T2, T3)> ReadWordAsync<T1, T2, T3>(this Scanner self)
    {
        return (await self.ReadWordAsync<T1>(), await self.ReadWordAsync<T2>(), await self.ReadWordAsync<T3>());
    }

    public static async Task<(T1, T2, T3, T4)> ReadWordAsync<T1, T2, T3, T4>(this Scanner self)
    {
        return (await self.ReadWordAsync<T1>(), await self.ReadWordAsync<T2>(), await self.ReadWordAsync<T3>(), await self.ReadWordAsync<T4>());
    }

    public static async Task<(T1, T2, T3, T4, T5)> ReadWordAsync<T1, T2, T3, T4, T5>(this Scanner self)
    {
        return (
            await self.ReadWordAsync<T1>(), await self.ReadWordAsync<T2>(), await self.ReadWordAsync<T3>(), await self.ReadWordAsync<T4>(),
            await self.ReadWordAsync<T5>()
        );
    }

    public static async Task<(T1, T2, T3, T4, T5, T6)> ReadWordAsync<T1, T2, T3, T4, T5, T6>(this Scanner self)
    {
        return (
            await self.ReadWordAsync<T1>(), await self.ReadWordAsync<T2>(), await self.ReadWordAsync<T3>(), await self.ReadWordAsync<T4>(),
            await self.ReadWordAsync<T5>(), await self.ReadWordAsync<T6>()
        );
    }

    public static async IAsyncEnumerable<string> ReadLineListAsync(this Scanner self, int n)
    {
        for (var i = 0; i < n; i += 1)
        {
            yield return await self.ReadLineAsync();
        }
    }

    public static async IAsyncEnumerable<string> ReadWordListAsync(this Scanner self, int n)
    {
        for (var i = 0; i < n; i += 1)
        {
            yield return await self.ReadWordAsync();
        }
    }

    public static async IAsyncEnumerable<T> ReadWordListAsync<T>(this Scanner self, int n)
    {
        var parser = GetParser<T>();
        for (var i = 0; i < n; i += 1)
        {
            yield return parser.Parse(await self.ReadWordAsync());
        }
    }

    public static async IAsyncEnumerable<(T1, T2)> ReadWordListAsync<T1, T2>(this Scanner self, int n)
    {
        var parser1 = GetParser<T1>();
        var parser2 = GetParser<T2>();
        for (var i = 0; i < n; i += 1)
        {
            yield return (parser1.Parse(await self.ReadWordAsync()), parser2.Parse(await self.ReadWordAsync()));
        }
    }

    public static async IAsyncEnumerable<(T1, T2, T3)> ReadWordListAsync<T1, T2, T3>(this Scanner self, int n)
    {
        var parser1 = GetParser<T1>();
        var parser2 = GetParser<T2>();
        var parser3 = GetParser<T3>();
        for (var i = 0; i < n; i += 1)
        {
            yield return (parser1.Parse(await self.ReadWordAsync()), parser2.Parse(await self.ReadWordAsync()), parser3.Parse(await self.ReadWordAsync()));
        }
    }

    public static async IAsyncEnumerable<(T1, T2, T3, T4)> ReadWordListAsync<T1, T2, T3, T4>(this Scanner self, int n)
    {
        var parser1 = GetParser<T1>();
        var parser2 = GetParser<T2>();
        var parser3 = GetParser<T3>();
        var parser4 = GetParser<T4>();
        for (var i = 0; i < n; i += 1)
        {
            yield return (
                parser1.Parse(await self.ReadWordAsync()), parser2.Parse(await self.ReadWordAsync()), parser3.Parse(await self.ReadWordAsync()),
                parser4.Parse(await self.ReadWordAsync())
            );
        }
    }

    public static async IAsyncEnumerable<(T1, T2, T3, T4, T5)> ReadWordListAsync<T1, T2, T3, T4, T5>(this Scanner self, int n)
    {
        var parser1 = GetParser<T1>();
        var parser2 = GetParser<T2>();
        var parser3 = GetParser<T3>();
        var parser4 = GetParser<T4>();
        var parser5 = GetParser<T5>();
        for (var i = 0; i < n; i += 1)
        {
            yield return (
                parser1.Parse(await self.ReadWordAsync()), parser2.Parse(await self.ReadWordAsync()), parser3.Parse(await self.ReadWordAsync()),
                parser4.Parse(await self.ReadWordAsync()), parser5.Parse(await self.ReadWordAsync())
            );
        }
    }

    public static async IAsyncEnumerable<(T1, T2, T3, T4, T5, T6)> ReadWordListAsync<T1, T2, T3, T4, T5, T6>(this Scanner self, int n)
    {
        var parser1 = GetParser<T1>();
        var parser2 = GetParser<T2>();
        var parser3 = GetParser<T3>();
        var parser4 = GetParser<T4>();
        var parser5 = GetParser<T5>();
        var parser6 = GetParser<T6>();
        for (var i = 0; i < n; i += 1)
        {
            yield return (
                parser1.Parse(await self.ReadWordAsync()), parser2.Parse(await self.ReadWordAsync()), parser3.Parse(await self.ReadWordAsync()),
                parser4.Parse(await self.ReadWordAsync()), parser5.Parse(await self.ReadWordAsync()), parser6.Parse(await self.ReadWordAsync())
            );
        }
    }
}
