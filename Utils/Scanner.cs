using Utils._Verify;

namespace Utils._Scanner;

public class Scanner
{
    public Scanner(TextReader reader)
    {
        Reader = reader;
    }

    private async Task<bool> FillBufferAsync()
    {
        var length = BufferEnd - BufferStart;
        if (length < Buffer.Length / 2)
        {
            Array.Copy(Buffer, BufferStart, Buffer, 0, length);
            BufferStart = 0;
            BufferEnd = length;
        }

        Verify.False(BufferEnd == Buffer.Length, "Buffer too full.");

        var read = await Reader.ReadAsync(Buffer, BufferEnd, Buffer.Length - BufferEnd);
        if (read == 0)
        {
            return false;
        }
        BufferEnd += read;
        return true;
    }

    private async Task<int> FindNextAsync(Func<char, bool> predicate)
    {
        while (true)
        {
            for (var i = BufferStart; i < BufferEnd; i += 1)
            {
                if (predicate(Buffer[i]))
                {
                    return i;
                }
            }

            if (!await FillBufferAsync())
            {
                return BufferEnd;
            }
        }
    }

    private async Task<(int Start, int Length)> SkipToNextAsync(Func<char, bool> predicate)
    {
        var end = await FindNextAsync(predicate);
        var start = BufferStart;
        BufferStart = end;
        return (start, end - start);
    }

    private async Task<char?> GetBufferAtAsync(int i)
    {
        while (BufferStart + i >= BufferEnd)
        {
            if (!await FillBufferAsync())
            {
                return null;
            }
        }
        return Buffer[BufferStart + i];
    }

    public async Task<string> ReadWordAsync()
    {
        await SkipToNextAsync(ch => !char.IsWhiteSpace(ch));
        var (start, length) = await SkipToNextAsync(ch => char.IsWhiteSpace(ch));
        return new string(Buffer, start, length);
    }

    public async Task<string> ReadLineAsync()
    {
        var (start, length) = await SkipToNextAsync(ch => ch == '\r' || ch == '\n');
        var result = new string(Buffer, start, length);

        if (await GetBufferAtAsync(0) == '\r')
        {
            BufferStart += 1;
        }
        if (await GetBufferAtAsync(0) == '\n')
        {
            BufferStart += 1;
        }

        return result;
    }

    private readonly char[] Buffer = new char[4096];
    private int BufferStart = 0;
    private int BufferEnd = 0;
    private readonly TextReader Reader;
}
