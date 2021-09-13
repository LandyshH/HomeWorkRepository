using System;

namespace HomeWork1
{
    public static class Parser
    {
          private const int WrongOperation = 1;
          private const int WrongArgLength = 2;
          private const int WrongArgFormatInt = 3;
        
        public static int ParseArguments(string[] args, out int val1, out CalculatorOperation operation, out int val2)
        {
            var isInt1 = int.TryParse(args[0], out val1);
            var isInt2 = int.TryParse(args[2], out val2);
            
            if (!TryParseOperationOrQuit(args[1], out operation)) return WrongOperation;
            if (!CheckArgLength(args.Length)) return WrongArgLength;
            if (!TryParseOrQuit(args[0], isInt1) || !TryParseOrQuit(args[2], isInt2)) return WrongArgFormatInt;
            
            return 0;
        }

        private static bool TryParseOperationOrQuit(string arg, out CalculatorOperation operation)
        {
            operation = arg switch
            {
                "+" => CalculatorOperation.Plus,
                "-" => CalculatorOperation.Minus,
                "*" => CalculatorOperation.Multiply,
                "/" => CalculatorOperation.Divide,
                _ => 0
            };

            return operation != 0;
        }

        private static bool CheckArgLength(int length)
        {
            if (length == 3) return true;
            Console.WriteLine($"The program requires 3 arguments, but was {length}");
            return false;
        }
        
        private static bool TryParseOrQuit(string arg, bool isInt)
        {
            if (isInt) return true;
            Console.WriteLine($"Value is not int: {arg}");
            return false;
        }
    }
}