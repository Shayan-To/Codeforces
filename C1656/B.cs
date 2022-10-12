﻿using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons

namespace C1656
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var (n, k) in In.ReadWordListAsync<int, int>(await In.ReadWordAsync<int>()))
            {
                var l = await In.ReadWordListAsync<int>(n).ToListAsync();
                l.Sort();

                var bl = false;
                foreach (var i in l.Count.Range())
                {
                    int j = l.BinarySearch(i, l.Count - i, l[i] + k, null);
                    if (j >= 0)
                    {
                        bl = true;
                        ErrLine($"{i} {l[i]}     {j} {l[j]}");
                        if (!IsLocal)
                        {
                            break;
                        }
                    }
                }

                OutLine(bl ? "Yes" : "No");
            }
        }
    }
}
