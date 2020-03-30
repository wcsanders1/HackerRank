using System;

namespace CounterGame
{
    class Program
    {
        const string Louise = "Louise";
        const string Richard = "Richard";

        static string GetWinner(ulong number)
        {
            var player = Louise;

            if (number == 1)
            {
                return Richard;
            }
            
            while ((number & (number - 1)) != 0)
            {
                var nextLowerPowerOfTwo = 2UL;
                while (true)
                {
                    var next = nextLowerPowerOfTwo * 2;
                    if (next > number)
                    {
                        break;
                    }
                    nextLowerPowerOfTwo = next;
                }
                player = player == Richard ? Louise : Richard;
                number -= nextLowerPowerOfTwo;
            }
                      
            if (number == 1)
            {
                return player == Richard ? Louise : Richard;
            }

            while (number > 1)
            {
                number >>= 1;
                if (number != 1)
                {
                    player = player == Richard ? Louise : Richard;
                }
            }

            return player;
        }

        static void Main(string[] args)
        {
            var caseNumber = int.Parse(Console.ReadLine());
            for (var i = 0; i < caseNumber; i++)
            {
                var number = ulong.Parse(Console.ReadLine());
                var result = GetWinner(number);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
