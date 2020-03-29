using System;
using System.Numerics;

namespace FibonacciModified
{
    class Program
    {
        static BigInteger FibonacciModified(int t1, int t2, int n)
        {
            if (n == 1)
            {
                return t1;
            }

            if (n == 2)
            {
                return t2;
            }

            var newT1 = new BigInteger(t1);
            var newT2 = new BigInteger(t2);

            while (n > 2)
            {
                n--;
                var oldT2 = newT2;
                newT2 = newT1 + newT2 * newT2;
                newT1 = oldT2;
            }

            return newT2;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var t1 = int.Parse(input[0]);
            var t2 = int.Parse(input[1]);
            var n = int.Parse(input[2]);

            var result = FibonacciModified(t1, t2, n);

            Console.WriteLine(result);
        }
    }
}
