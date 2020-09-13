using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    private class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    static int[][] swapNodes(int[][] indexes, int[] queries)
    {
        var root = new Node { Value = 1 };
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        foreach (var index in indexes)
        {
            var node = queue.Dequeue();
            if (index[0] != -1)
            {
                var leftNode = new Node { Value = index[0] };
                node.Left = leftNode;
                queue.Enqueue(leftNode);
            }

            if (index[1] != -1)
            {
                var rightNode = new Node { Value = index[1] };
                node.Right = rightNode;
                queue.Enqueue(rightNode);
            }
        }

        var result = new int[queries.Length][];

        for (var i = 0; i < queries.Length; i++)
        {
            var traversal = ReadInOrder(root, queries[i]);
            result[i] = traversal.ToArray();
        }

        return result;
    }

    private static List<int> ReadInOrder(Node node, int target, int level = 1)
    {
        if (level >= target && level % target == 0)
        {
            var temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;
        }

        var nodes = new List<int>();

        if (node.Left != null)
        {
            var leftNodes = ReadInOrder(node.Left, target, level + 1);
            nodes.AddRange(leftNodes);
        }

        nodes.Add(node.Value);

        if (node.Right != null)
        {
            var rightNodes = ReadInOrder(node.Right, target, level + 1);
            nodes.AddRange(rightNodes);
        }

        return nodes;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[][] indexes = new int[n][];

        for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++)
        {
            indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int[queriesCount];

        for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[][] result = swapNodes(indexes, queries);

        Console.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));
    }
}
