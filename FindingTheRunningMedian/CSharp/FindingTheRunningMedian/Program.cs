using System;

class Solution
{
    public class Heap
    {
        public enum Priority
        {
            Min,
            Max
        }

        private int[] Numbers { get; }
        private Priority HeapType { get; }
        private int TreeSize { get; set; }

        public Heap(int size, Priority heapType)
        {
            Numbers = new int[size + 1];
            TreeSize = 0;
            HeapType = heapType;
        }

        public int Peek()
        {
            if (TreeSize == 0)
            {
                return 0;
            }

            return Numbers[1];
        }

        public int GetSize()
        {
            return TreeSize;
        }

        public void Insert(int number)
        {
            if (TreeSize >= Numbers.Length)
            {
                return;
            }

            Numbers[++TreeSize] = number;
            HeapifyBottomToTop(TreeSize);
        }

        public int Remove()
        {
            if (TreeSize == 0)
            {
                return -1;
            }

            var value = Numbers[1];
            Numbers[1] = Numbers[TreeSize--];
            HeapifyTopToBottom(1);

            return value;
        }

        private void HeapifyBottomToTop(int index)
        {
            if (index <= 1)
            {
                return;
            }

            var parent = index / 2;

            if ((HeapType == Priority.Min && Numbers[index] < Numbers[parent]) ||
                (HeapType == Priority.Max && Numbers[index] > Numbers[parent]))
            {
                var temp = Numbers[index];
                Numbers[index] = Numbers[parent];
                Numbers[parent] = temp;

                HeapifyBottomToTop(parent);
            }
        }

        private void HeapifyTopToBottom(int index)
        {
            var left = index * 2;
            var right = (index * 2) + 1;

            if (TreeSize < left)
            {
                return;
            }
            else if (TreeSize == left)
            {
                if ((HeapType == Priority.Min && Numbers[index] > Numbers[left]) ||
                    (HeapType == Priority.Max && Numbers[index] < Numbers[left]))
                {
                    var temp = Numbers[index];
                    Numbers[index] = Numbers[left];
                    Numbers[left] = temp;

                    return;
                }
            }
            else if (HeapType == Priority.Min)
            {
                int smallestChild;
                if (Numbers[left] < Numbers[right])
                {
                    smallestChild = left;
                }
                else
                {
                    smallestChild = right;
                }

                if (Numbers[index] > Numbers[smallestChild])
                {
                    var temp = Numbers[index];
                    Numbers[index] = Numbers[smallestChild];
                    Numbers[smallestChild] = temp;
                }

                HeapifyTopToBottom(smallestChild);
            }
            else
            {
                int largestChild;
                if (Numbers[left] > Numbers[right])
                {
                    largestChild = left;
                }
                else
                {
                    largestChild = right;
                }

                if (Numbers[index] < Numbers[largestChild])
                {
                    var temp = Numbers[index];
                    Numbers[index] = Numbers[largestChild];
                    Numbers[largestChild] = temp;
                }

                HeapifyTopToBottom(largestChild);
            }
        }
    }

    private static void AddNumber(int number, Heap minHeap, Heap maxHeap)
    {
        if (minHeap.GetSize() == 0 || number < minHeap.Peek())
        {
            minHeap.Insert(number);
        }
        else
        {
            maxHeap.Insert(number);
        }
    }

    private static void Rebalance(Heap minHeap, Heap maxHeap)
    {
        var biggerHeap = minHeap.GetSize() > maxHeap.GetSize() ? minHeap : maxHeap;
        var smallerHeap = minHeap.GetSize() > maxHeap.GetSize() ? maxHeap : minHeap;

        if (biggerHeap.GetSize() - smallerHeap.GetSize() >= 2)
        {
            smallerHeap.Insert(biggerHeap.Remove());
        }
    }

    private static double GetMedian(Heap minHeap, Heap maxHeap)
    {
        var biggerHeap = minHeap.GetSize() > maxHeap.GetSize() ? minHeap : maxHeap;
        var smallerHeap = minHeap.GetSize() > maxHeap.GetSize() ? maxHeap : minHeap;

        if (biggerHeap.GetSize() == smallerHeap.GetSize())
        {
            return (biggerHeap.Peek() + smallerHeap.Peek()) / 2D;
        }

        return biggerHeap.Peek();
    }

    static double[] RunningMedian(int[] a)
    {
        var minHeap = new Heap(a.Length, Heap.Priority.Max);
        var maxHeap = new Heap(a.Length, Heap.Priority.Min);

        var result = new double[a.Length];

        for (int i = 0; i < a.Length; i++)
        {
            var num = a[i];
            AddNumber(num, minHeap, maxHeap);
            Rebalance(minHeap, maxHeap);
            result[i] = GetMedian(minHeap, maxHeap);
        }

        return result;
    }

    static void Main(string[] args)
    {
        int aCount = Convert.ToInt32(Console.ReadLine());

        int[] a = new int[aCount];

        for (int aItr = 0; aItr < aCount; aItr++)
        {
            int aItem = Convert.ToInt32(Console.ReadLine());
            a[aItr] = aItem;
        }

        double[] result = RunningMedian(a);

        Console.WriteLine(string.Join("\n", result));
    }
}
