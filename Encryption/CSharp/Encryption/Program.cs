using System;
using System.Text;

class Solution
{

    static string Encryption(string s)
    {
        var spacelessString = s.Replace(" ", string.Empty);
        var spacelessStringLength = spacelessString.Length;
        var squareRoot = Math.Sqrt(spacelessStringLength);

        var rows = (int)Math.Floor(squareRoot);
        var columns = (int)Math.Ceiling(squareRoot);

        var sb = new StringBuilder();
        for (var row = 0; row <= rows; row++)
        {
            for (var column = row; column < spacelessStringLength; column += columns)
            {
                if (column < spacelessStringLength && sb.Length < spacelessStringLength + rows)
                {
                    sb.Append(spacelessString[column]);
                }
            }

            sb.Append(" ");
        }

        return sb.ToString();
    }

    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        string result = Encryption(s);
        Console.WriteLine(result);
    }
}