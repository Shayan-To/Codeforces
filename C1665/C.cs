using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using static Utils.Commons;

// #util Commons
// #util HeapOperations

namespace C1665
{
    public static class C
    {
        public static async Task Main()
        {
            foreach (var _ in Enumerable.Range(0, await In.ReadIntAsync()))
            {
                var n = await In.ReadIntAsync();

                var dic = new Dictionary<int, int>() { [0] = 1 };
                foreach (var ii in Enumerable.Range(0, n - 1))
                {
                    var i = await In.ReadIntAsync();
                    if (!dic.ContainsKey(i))
                    {
                        dic[i] = 0;
                    }
                    dic[i] += 1;
                }

                var list = dic.Select(kv => kv.Value).ToArray();
                Array.Sort(list, Larger);
                n = list.Length;

                ErrLine(list.Select(i => $"{i}").Aggregate((p, c) => $"{p} {c}"));

                foreach (var i in Enumerable.Range(0, n))
                {
                    list[i] -= Math.Min(n - i, list[i]);
                }

                ErrLine(list.Select(i => $"{i}").Aggregate((p, c) => $"{p} {c}"));

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
