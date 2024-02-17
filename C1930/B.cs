﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1930
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var h = n / 2;
                var r = h.Range(1).Zip(h.Range(1).Select(i => i + h)).SelectMany(p => new[] { p.First, p.Second });
                if (n % 2 == 1)
                {
                    r = r.Append(n);
                }
                OutLine($"{r.JoinToString()}");
            }
        }
    }
}
