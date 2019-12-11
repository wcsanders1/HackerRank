using System;

namespace CountStrings
{
    public enum RegularExpressionElement
    {
        A,
        B,
        Astrisk
    }

    public static class RegularExpressionUtility
    {
        public static RegularExpressionElement ConvertCharToRegularExpressionElement(char character)
        {
            return character switch
            {
                'a' => RegularExpressionElement.A,
                'b' => RegularExpressionElement.B,
                _ => RegularExpressionElement.Astrisk,
            };
        }
    }

    class RegularExpression
    {
        public RegularExpressionElement FirstElement { get; set; }
        public RegularExpressionElement SecondElement { get; set; }
        public RegularExpression NestedRegularExpression { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
