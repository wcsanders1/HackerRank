using System;

namespace HighestValuePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawAmount = Console.ReadLine().Split(' ');
            var changesAllowed = int.Parse(rawAmount[1]);
            var changeRecord = new bool[int.Parse(rawAmount[0])];

            var testCase = Console.ReadLine();

            var frontPosition = 0;
            var backPosition = testCase.Length - 1;
            var success = true;
            var result = testCase.ToCharArray();

            while (frontPosition < backPosition)
            {
                if (testCase[frontPosition] != testCase[backPosition])
                {
                    if (changesAllowed == 0)
                    {
                        success = false;
                        break;
                    }

                    var leftValue = int.Parse(testCase[frontPosition].ToString());
                    var rightValue = int.Parse(testCase[backPosition].ToString());

                    var maxValue = Math.Max(leftValue, rightValue);
                    var maxValueAsChar = maxValue.ToString().ToCharArray()[0];

                    if (result[frontPosition] != maxValueAsChar)
                    {
                        result[frontPosition] = maxValueAsChar;
                        changeRecord[frontPosition] = true;
                    }

                    if (result[backPosition] != maxValueAsChar)
                    {
                        result[backPosition] = maxValueAsChar;
                        changeRecord[backPosition] = true;
                    }

                    changesAllowed--;
                }
                frontPosition++;
                backPosition--;
            }

            if (!success)
            {
                Console.WriteLine("-1");
                return;
            }
            
            if (changesAllowed == 0)
            {
                Console.WriteLine(result);
                return;
            }

            frontPosition = 0;
            backPosition = testCase.Length - 1;

            while(changesAllowed > 0)
            {
                if (backPosition - frontPosition < 0)
                {
                    break;
                }

                if (backPosition - frontPosition == 0)
                {
                    var middlePosition = (int)Math.Floor((decimal)(result.Length / 2));
                    result[middlePosition] = '9';
                    break;
                }

                if (changesAllowed == 1)
                {
                    if (result[frontPosition] == '9' && result[backPosition] == '9')
                    {
                        frontPosition++;
                        backPosition--;
                        continue;
                    }

                    if (!changeRecord[frontPosition] &&
                        result[frontPosition] != '9' &&
                        !changeRecord[backPosition] &&
                        result[backPosition] != '9')
                    {
                        frontPosition++;
                        backPosition--;
                        continue;
                    }


                    result[frontPosition] = '9';
                    result[backPosition] = '9';
                    break;
                }

                if (result[frontPosition] != '9')
                {
                    result[frontPosition] = '9';
                    if (!changeRecord[frontPosition])
                    {
                        changesAllowed--;
                    }
                }

                if (result[backPosition] != '9')
                {
                    result[backPosition] = '9';
                    if (!changeRecord[backPosition])
                    {
                        changesAllowed--;
                    }
                }

                frontPosition++;
                backPosition--;
            }

            Console.WriteLine(result);
        }
    }
}
