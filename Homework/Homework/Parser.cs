using System;

namespace HomeWork
{
    enum HundleExceptions : byte
    {
          Success,
          WrongOperation,
          WrongArgLength,
          WrongArgFormatInt,
    }
    public static class Parser
    {
        public static int ParseArguments(string[] args, out int val1, out CalculatorOperation operation, out int val2)
        {
            val1 = val2 = 0;
            operation = 0;
            if (!CheckArgLength(args)) return (int)HundleExceptions.WrongArgLength;
            var isInt1 = int.TryParse(args[0], out val1);
            var isInt2 = int.TryParse(args[2], out val2);
            
            if (!TryParseOperationOrQuit(args[1], out operation)) return (int)HundleExceptions.WrongOperation;
            if (!ArgumentIsInt(args[0], isInt1) || !ArgumentIsInt(args[2], isInt2)) 
                return (int)HundleExceptions.WrongArgFormatInt;
            
            return (int)HundleExceptions.Success;
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

        private static bool CheckArgLength(string[] args)
        {
            var length = args.Length;
            if (length == 3) return true;
            Console.WriteLine($"The program requires 3 arguments, but was {length}");
            return false;
        }
        
        private static bool ArgumentIsInt(string arg, bool isInt)
        {
            if (isInt) return true;
            Console.WriteLine($"Value is not int: {arg}");
            return false;
        }
    }
}