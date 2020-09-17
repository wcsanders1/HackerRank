using System.Collections.Generic;
using System;

class Solution
{
    static string IsBalanced(string s)
    {
        var bracketStack = new Stack<char>();

        foreach (var bracket in s)
        {
            if (bracket == '(' || bracket == '[' || bracket == '{')
            {
                bracketStack.Push(bracket);
            }
            else
            {
                if (bracketStack.Count == 0)
                {
                    return "NO";
                }

                var openBracket = bracketStack.Pop();
                if ((openBracket == '(' && bracket != ')') ||
                    (openBracket == '[' && bracket != ']') ||
                    (openBracket == '{' && bracket != '}'))
                {
                    return "NO";
                }
            }
        }

        if (bracketStack.Count > 0)
        {
            return "NO";
        }

        return "YES";
    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = IsBalanced(s);

            Console.WriteLine(result);
        }

        Console.ReadKey();
    }
}
