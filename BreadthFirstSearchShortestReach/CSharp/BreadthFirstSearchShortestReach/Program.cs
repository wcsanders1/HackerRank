using System;
using System.Collections.Generic;

namespace BreadthFirstSearchShortestReach
{
    class Program
    {
        class Node
        {
            public Node(int value)
            {
                Value = value;
                Nodes = new List<Node>();
            }
            public int Value { get; set; }
            public List<Node> Nodes { get; set; }
        }

        static int[] GetShortestPaths(int nodeAmount, int edgeAmount, int[][] edges, int startingNode)
        {
            var result = new int[nodeAmount];
            var nodes = new Node[nodeAmount];

            for (var i = 0; i < nodeAmount; i++)
            {
                if (nodes[i] == null)
                {
                    nodes[i] = new Node(i + 1);
                }
            }

            for (var i = 0; i < edgeAmount; i++)
            {
                var nodeOne = nodes[edges[i][0] - 1];
                var nodeTwo = nodes[edges[i][1] - 1];
                nodeOne.Nodes.Add(nodeTwo);
                nodeTwo.Nodes.Add(nodeOne);
            }

            GetShortestPaths(nodes[startingNode - 1], result, 0, startingNode);
            var processedResult = new int[nodeAmount - 1];
            var resultIndex = 0;
            for (var i = 0; i < nodeAmount; i++)
            {
                if (i == startingNode - 1)
                {
                    continue;
                }

                if (result[i] == 0)
                {
                    processedResult[resultIndex++] = -1;
                    continue;
                }

                processedResult[resultIndex++] = result[i];
            }

            return processedResult;
        }

        static void GetShortestPaths(Node node, int[] pathLengths, int depth, int startingNode)
        {
            if (depth > 0)
            {
                if (pathLengths[node.Value - 1] != 0 && pathLengths[node.Value - 1] <= depth)
                {
                    return;
                }

                if (pathLengths[node.Value - 1] == 0 || pathLengths[node.Value - 1] > depth)
                {
                    pathLengths[node.Value - 1] = depth;
                }
            }

            foreach (var nextNode in node.Nodes)
            {
                if (nextNode.Value == startingNode)
                {
                    continue;
                }

                GetShortestPaths(nextNode, pathLengths, depth + 6, startingNode);
            }
        }

        static void Main(string[] args)
        {
            var queries = int.Parse(Console.ReadLine());
            for (var query = 0; query < queries; query++)
            {
                var amounts = Console.ReadLine().Split(' ');
                var nodeAmount = int.Parse(amounts[0]);
                var edgeAmount = int.Parse(amounts[1]);

                var edges = new int[edgeAmount][];

                for (var i = 0; i < edgeAmount; i++)
                {
                    edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                }

                var startingNode = int.Parse(Console.ReadLine());

                var result = GetShortestPaths(nodeAmount, edgeAmount, edges, startingNode);

                Console.WriteLine(string.Join(" ", result));
            }

            Console.ReadKey();
        }
    }
}
