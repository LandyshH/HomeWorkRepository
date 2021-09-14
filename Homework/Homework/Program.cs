using System;

namespace HomeWork
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var resultIs = Parser.ParseArguments(args, 
                out var val1, 
                out var operation, 
                out var val2);
            if (resultIs != 0) return resultIs;
            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Answer is: {result}");
            return 0;
        }
    }
}