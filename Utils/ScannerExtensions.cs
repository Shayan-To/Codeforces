using System.Collections.Generic;
using System.Threading.Tasks;

// #util Scanner

namespace Utils
{
    public static class ScannerExtensions
    {
        #region Typed Read
        public static async Task<int> ReadIntAsync(this Scanner self)
        {
            return int.Parse(await self.ReadWordAsync());
        }

        public static async Task<long> ReadLongAsync(this Scanner self)
        {
            return long.Parse(await self.ReadWordAsync());
        }

        public static async Task<double> ReadDoubleAsync(this Scanner self)
        {
            return double.Parse(await self.ReadWordAsync());
        }

        public static async Task<float> ReadSingleAsync(this Scanner self)
        {
            return float.Parse(await self.ReadWordAsync());
        }

        public static async Task<decimal> ReadDecimalAsync(this Scanner self)
        {
            return decimal.Parse(await self.ReadWordAsync());
        }
        #endregion

        #region List Read
        public static async IAsyncEnumerable<string> ReadWordListAsync(this Scanner self, int n)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadWordAsync();
            }
        }

        public static async IAsyncEnumerable<string> ReadLineListAsync(this Scanner self, int n)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadLineAsync();
            }
        }

        public static async IAsyncEnumerable<int> ReadIntListAsync(this Scanner self, int n, int diff = 0)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadIntAsync() + diff;
            }
        }

        public static async IAsyncEnumerable<long> ReadLongListAsync(this Scanner self, int n)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadLongAsync();
            }
        }

        public static async IAsyncEnumerable<double> ReadDoubleListAsync(this Scanner self, int n)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadDoubleAsync();
            }
        }

        public static async IAsyncEnumerable<float> ReadSingleListAsync(this Scanner self, int n)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadSingleAsync();
            }
        }

        public static async IAsyncEnumerable<decimal> ReadDecimalListAsync(this Scanner self, int n)
        {
            for (var i = 0; i < n; i += 1)
            {
                yield return await self.ReadDecimalAsync();
            }
        }
        #endregion
    }
}
