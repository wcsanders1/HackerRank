using System;
using System.Linq;

namespace SherlockAndValidString
{
    class Program
    {
        private const string Yes = "YES";
        private const string No = "NO";

        static void Main(string[] args)
        {
            var testCase = Console.ReadLine();

            var clusteredOccurrences = testCase
                .GroupBy(letter => letter)
                .GroupBy(g => g.Count())
                .ToDictionary(g => g.Key, g => g.Count());

            if (clusteredOccurrences.Count == 1)
            {
                Console.WriteLine(Yes);
                return;
            }

            if (clusteredOccurrences.Count > 2)
            {
                Console.WriteLine(No);
                return;
            }

            if (clusteredOccurrences.TryGetValue(1, out var occurrenceCount))
            {
                if (occurrenceCount == 1)
                {
                    Console.WriteLine(Yes);
                    return;
                }
            }

            var frequencies = clusteredOccurrences.Keys.ToList();

            if (Math.Abs(frequencies[0] - frequencies[1]) > 1)
            {
                Console.WriteLine(No);
                return;
            }

            var higherFrequency = Math.Max(frequencies[0], frequencies[1]);
            if (clusteredOccurrences[higherFrequency] > 1)
            {
                Console.WriteLine(No);
                return;
            }

            Console.WriteLine(Yes);
        }
    }
}
