using System;
using System.Linq;

namespace BiggerIsGreater
{
    class Program
    {
        private const string NoAnswer = "no answer";

        static string BiggerIsGreater(string problem)
        {
            if (problem.Length <= 1)
            {
                return NoAnswer;
            }

            var charArray = problem.ToCharArray();

            for (var index = charArray.Length - 1; index >= 0; index--)
            {
                if (index == 0)
                {
                    return NoAnswer;
                }

                if (charArray[index - 1] >= charArray[index])
                {
                    continue;
                }

                var replacementIndex = index - 1;
                var replacedChar = charArray[replacementIndex];
                var replacementList = charArray.Skip(replacementIndex + 1).OrderBy(c => c).ToList();
                var replacementChar = replacementList.First(c => c > replacedChar);
                
                charArray[replacementIndex] = replacementChar;

                replacementList.Remove(replacementChar);
                replacementList.Add(replacedChar);

                var sortedReplacementList = replacementList.OrderBy(c => c);

                var arrayAnswer = charArray.Take(replacementIndex + 1).Concat(sortedReplacementList).ToArray();

                return new string(arrayAnswer);
            }

            return NoAnswer;
        }


        static void Main()
        {
            var cases = Convert.ToInt32(Console.ReadLine());

            for (var @case = 0; @case < cases; @case++)
            {
                var problem = Console.ReadLine();

                var result = BiggerIsGreater(problem);

                Console.WriteLine(result);
            }
        }
    }
}
