using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLongFactorials
{
    class Program
    {
        static List<int> NumberToDigitList (int number) => number
            .ToString()
            .Select(digit => int.Parse(digit.ToString()))
            .Reverse()
            .ToList();
        
        static void ExtraLongFactorials(int n)
        {
            var solutionTracker = NumberToDigitList(n);

            while (--n > 1)
            {
                var tempList = new List<int>();
                var carry = 0;
                foreach(var num in solutionTracker)
                {
                    var tempSum = (num * n) + carry;
                    var newNums = NumberToDigitList(tempSum);
                    if (newNums.Count == 1)
                    {
                        tempList.AddRange(newNums);
                        carry = 0;
                        continue;
                    }

                    var tempSumAsString = tempSum.ToString();
                    tempList.Add(int.Parse(tempSumAsString[tempSumAsString.Length - 1].ToString()));
                    carry = int.Parse(tempSumAsString.Substring(0, tempSumAsString.Length - 1));
                }

                if (carry > 0)
                {
                    tempList.AddRange(NumberToDigitList(carry));
                }
                solutionTracker = tempList;
            }


            solutionTracker.Reverse();

            Console.WriteLine(string.Join("", solutionTracker));

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            ExtraLongFactorials(n);
        }
    }
}
