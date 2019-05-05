using System;

namespace OrganizingContainersOfBalls
{
    class Program
    {
        static string OrganizingContainers(int[][] container)
        {
            var numberOfBucketsAndColors = container.Length;
            var amountOfEachColor = new int[numberOfBucketsAndColors];
            var ballsInEachContainer = new int[numberOfBucketsAndColors];

            for (var bucketIndex = 0; bucketIndex < numberOfBucketsAndColors; bucketIndex++)
            {
                var amountOfThisColor = 0;
                for (var colorIndex = 0; colorIndex < numberOfBucketsAndColors; colorIndex++)
                {
                    amountOfEachColor[colorIndex] += container[bucketIndex][colorIndex];
                    amountOfThisColor += container[bucketIndex][colorIndex];
                }
                ballsInEachContainer[bucketIndex] = amountOfThisColor;
            }

            Array.Sort(amountOfEachColor);
            Array.Sort(ballsInEachContainer);

            for (int index = 0; index < numberOfBucketsAndColors; index++)
            {
                if (amountOfEachColor[index] != ballsInEachContainer[index])
                {
                    return "Impossible";
                }
            }

            return "Possible";
        }

        static void Main(string[] args)
        {
            var q = Convert.ToInt32(Console.ReadLine());

            for (var qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[][] container = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
                }

                string result = OrganizingContainers(container);

                Console.WriteLine(result);
            }
        }
    }
}
