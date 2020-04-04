using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetComponent
{
    class Program
    {
        static int GetSetBits(ulong number)
        {
            var result = 0;
            while (number > 0)
            {
                if ((number & 1) == 1)
                {
                    result++;
                }
                number >>= 1;
            }

            return result;
        }
        static ulong GetConnectedAmount(ulong[] components, int numberOfComponents)
        {
            var bitsSet = new Dictionary<ulong, int>();
            foreach (var component in components)
            {
                if (!bitsSet.ContainsKey(component))
                {
                    bitsSet.Add(component, GetSetBits(component));
                }
            }
            
            var allSubsets = GetAllSubsets(components.ToList(), 0);
            var result = 0UL;

            foreach (var subSet in allSubsets)
            {
                if (subSet.Count == 0)
                {
                    result += 64;
                    continue;
                }

                var lastCombination = subSet[0];
                var connections = bitsSet[lastCombination] >= 2 ? 1UL : 0UL;
                for (var i = 1; i < subSet.Count; i++)
                {
                    if (bitsSet[subSet[i]] < 2)
                    {
                        continue;
                    }

                    var newCombination = lastCombination | subSet[i];
                    if (!bitsSet.TryGetValue(newCombination, out var newBitsSet))
                    {
                        newBitsSet = GetSetBits(newCombination);
                        bitsSet.Add(newCombination, newBitsSet);
                    }

                    if (bitsSet[lastCombination] + bitsSet[subSet[i]] == newBitsSet)
                    {
                        connections++;
                    }
                    lastCombination = newCombination;
                }

                var newConnections = connections == 0 ? 64UL : 64UL - (ulong)bitsSet[lastCombination] + connections;
                result += newConnections;
            }

            return result;
        }

        static List<List<ulong>> GetAllSubsets(List<ulong> set, int index)
        {
            if (set.Count == index)
            {
                return new List<List<ulong>>
                {
                    new List<ulong>()
                };
            }

            var allSubsets = GetAllSubsets(set, index + 1);
            var item = set[index];
            var moreSubsets = new List<List<ulong>>();

            foreach (var subset in allSubsets)
            {
                var newSubset = new List<ulong>();
                newSubset.AddRange(subset);
                newSubset.Add(item);
                moreSubsets.Add(newSubset);
            }

            allSubsets.AddRange(moreSubsets);
            return allSubsets;
        }

        static void Main(string[] args)
        {
            var numberOfComponents = int.Parse(Console.ReadLine());

            var components = Array.ConvertAll(Console.ReadLine().Split(' '), ulong.Parse);

            var result = GetConnectedAmount(components, numberOfComponents);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
