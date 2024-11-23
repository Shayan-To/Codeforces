using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using static Utils.Commons;

// #util Commons
// #util AutoDictionary
// #util HeapOperations

namespace C1665
{
    public static class C
    {
        public static async Task Main()
        {
            await foreach (var nn in In.ReadWordListAsync<int>(await In.ReadWordAsync<int>()))
            {
                var dic = new AutoDictionary<int, int>() { [0] = 1 };
                await foreach (var i in In.ReadWordListAsync<int>(nn - 1))
                {
                    dic[i] += 1;
                }

                var list = dic.Select(kv => kv.Value).ToArray();
                Array.Sort(list, Larger);
                var n = list.Length;

                ErrLine(list.JoinToString());

                foreach (var i in Range(n))
                {
                    list[i] -= Math.Min(n - i, list[i]);
                }

                ErrLine(list.JoinToString());

                var heap = new HeapOperations<int>(Larger);
                heap.MakeHeap(list, list.Length);

                var s = 0;
                while (list[0] > s)
                {
                    s += 1;
                    list[0] -= 1;
                    heap.SlideDown(list, list.Length, 0);
                }

                OutLine($"{n + s}");
            }
        }

        private static readonly Comparer<int> Larger = Comparer<int>.Create((a, b) => b - a);
    }
}
