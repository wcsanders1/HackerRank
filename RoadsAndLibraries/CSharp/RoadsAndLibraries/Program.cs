using System;
using System.Collections.Generic;

namespace RoadsAndLibraries
{
    class Program
    {
        class Node
        {
            public int Value { get; set; }
            public List<Node> ConnectedNodes { get; set; }
            public Node(int value)
            {
                Value = value;
                ConnectedNodes = new List<Node>();
            }
        }

        static long GetResult(int cities, int libraryCost, int roadCost, int[][] cityRoadConnections)
        {
            if (cities == 1)
            {
                return libraryCost;
            }

            var nodes = new Node[cities];

            for (int road = 0; road < cityRoadConnections.Length; road++)
            {
                var cityOne = cityRoadConnections[road][0];
                var cityTwo = cityRoadConnections[road][1];

                if (nodes[cityOne - 1] == null)
                {
                    nodes[cityOne - 1] = new Node(cityOne);
                }

                if (nodes[cityTwo - 1] == null)
                {
                    nodes[cityTwo - 1] = new Node(cityTwo);
                }

                nodes[cityOne - 1].ConnectedNodes.Add(nodes[cityTwo - 1]);
                nodes[cityTwo - 1].ConnectedNodes.Add(nodes[cityOne - 1]);
            }

            var result = 0L;
            var visited = new bool[cities];

            foreach (var node in nodes)
            {
                if (node == null)
                {
                    result += libraryCost;
                    continue;
                }

                var newGroupAmount = GetNewGroupAmount(node, visited);
                if (newGroupAmount > 0)
                {
                    if (newGroupAmount == 1)
                    {
                        result += libraryCost;
                    }

                    var costToBuildAllLibraries = libraryCost * newGroupAmount;
                    var costToBuildOneLibraryAndAllRoads = libraryCost + (roadCost * (newGroupAmount - 1));

                    result += Math.Min(costToBuildAllLibraries, costToBuildOneLibraryAndAllRoads);
                }
            }

            return result;
        }

        static int GetNewGroupAmount(Node node, bool[] visited)
        {
            if (visited[node.Value - 1])
            {
                return 0;
            }

            visited[node.Value - 1] = true;
            var connections = 1;

            if (node.ConnectedNodes.Count == 0)
            {
                return connections;
            }

            foreach (var connectedNode in node.ConnectedNodes)
            {
                connections += GetNewGroupAmount(connectedNode, visited);
            }

            return connections;
        }

        static void Main(string[] args)
        {
            var testCases = int.Parse(Console.ReadLine());
            for (var testCase = 0; testCase < testCases; testCase++)
            {
                var info = Console.ReadLine().Split(' ');
                var cities = int.Parse(info[0]);
                var roads = int.Parse(info[1]);
                var libraryCost = int.Parse(info[2]);
                var roadCost = int.Parse(info[3]);

                var cityRoadConnections = new int[roads][];
                for (var road = 0; road < roads; road++)
                {
                    cityRoadConnections[road] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                }

                var result = GetResult(cities, libraryCost, roadCost, cityRoadConnections);

                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}
