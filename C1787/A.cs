﻿using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons
// #util MathI

namespace C1787
{
    public static class A
    {
        public static async Task Main()
        {
            await foreach (var n in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                if (n % 2 == 1)
                {
                    OutLine("-1");
                }
                else
                {
                    OutLine($"{1} {n / 2}");
                }
            }
        }
    }
}
