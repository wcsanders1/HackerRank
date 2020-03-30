using System;

namespace TheMaximumSubarray
{
    public class Result
    {
        public int MaxSubArray { get; set; }
        public int MaxSubSequence { get; set; }
    }

    class Program
    {
        static Result GetResult(int[] problem)
        {
            var result = new Result
            {
                MaxSubSequence = GetMaxSubSequence(problem)
                
            };

            var maxSubArray = GetMaxSubArray(problem);
            result.MaxSubArray = maxSubArray == 0 ? result.MaxSubSequence : maxSubArray;

            return result;
        }

        //Kadane's algorithm (not Bill's)
        static int GetMaxSubArray(int[] problem)
        {
            var best = 0;
            var current = 0;
            for (var i = 0; i < problem.Length; i++)
            {
                current = Math.Max(0, current + problem[i]);
                best = Math.Max(best, current);
            }

            return best;
        }

        static int GetMaxSubSequence(int[] problem)
        {
            var greatestElement = problem[0];
            int maxSequence;
            if (greatestElement > 0)
            {
                maxSequence = greatestElement;
            }
            else
            {
                maxSequence = 0;
            }

            for (int i = 1; i < problem.Length; i++)
            {
                if (problem[i] > greatestElement)
                {
                    greatestElement = problem[i];
                }
                if (problem[i] > 0)
                {
                    maxSequence += problem[i];
                }
            }

            if (maxSequence == 0)
            {
                return greatestElement;
            }

            return maxSequence;
        }

        static void Main(string[] args)
        {
            var numberOfCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfCases; i++)
            {
                var elementAmount = int.Parse(Console.ReadLine());

                var problem = Array.ConvertAll(Console.ReadLine().Split(' '), arr => int.Parse(arr));

                var result = GetResult(problem);

                Console.WriteLine($"{result.MaxSubArray} {result.MaxSubSequence}");
            }

            Console.ReadLine();
        }
    }
}
