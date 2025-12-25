namespace C2039
{
    public static class B
    {
        public static async Task Main()
        {
            await foreach (var s in In.ReadWordListAsync<string>(await In.ReadWordAsync<int>()))
            {
                var curP = new (int Prev, int Next)[s.Length];
                var prevP = new (int Prev, int Next)[s.Length];

                foreach (var i in Range(s.Length))
                {
                    if (curP[i] != (0, 0))
                    {
                        continue;
                    }
                    var ch = s[i];
                    var p = i;
                    var prev = -1;
                    foreach (var j in RangeSE(i + 1, s.Length))
                    {
                        if (ch == s[j])
                        {
                            curP[p] = (prev, j);
                            prev = j;
                        }
                    }
                    curP[p] = (prev, -1);
                }

                // OutLine
            }
        }
    }
}
