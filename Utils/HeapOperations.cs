namespace Utils._HeapOperations;

public class HeapOperations<T>
{
    public HeapOperations(IComparer<T> Comparer)
    {
        this.Comparer = Comparer;
    }

    public HeapOperations() : this(Comparer<T>.Default)
    {
    }

    public void SlideDown(IList<T> list, int count, int index)
    {
        while (true)
        {
            var minIndex = LeftChild(index);
            if (minIndex >= count)
            {
                break;
            }

            var min = list[minIndex];
            var i = RightChild(index);
            T t;
            if (i < count)
            {
                t = list[i];
                if (Comparer.Compare(t, min) < 0)
                {
                    minIndex = i;
                    min = t;
                }
            }

            t = list[index];
            if (Comparer.Compare(min, t) < 0)
            {
                list[index] = min;
                list[minIndex] = t;
                index = minIndex;
            }
            else
            {
                break;
            }
        }
    }

    public void MakeHeap(IList<T> list, int count)
    {
        for (var i = Parent(count - 1); i >= 0; i -= 1)
        {
            SlideDown(list, count, i);
        }
    }

    public void BubbleUp(IList<T> list, int index)
    {
        while (true)
        {
            if (index == 0)
            {
                break;
            }

            var t = list[index];
            var pi = Parent(index);
            var p = list[pi];
            if (Comparer.Compare(p, t) > 0)
            {
                list[pi] = t;
                list[index] = p;
                index = pi;
            }
            else
            {
                break;
            }
        }
    }

    public static int Parent(int index)
    {
        return (index - 1) / 2;
    }

    public static int LeftChild(int index)
    {
        return 2 * index + 1;
    }

    public static int RightChild(int index)
    {
        return 2 * index + 2;
    }

    private readonly IComparer<T> Comparer;
}
