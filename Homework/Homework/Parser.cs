using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal enum HundledExceptions : byte
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
            if (!CheckArgLength(args)) return (int)HundledExceptions.WrongArgLength;
            if (!TryParseOperationOrQuit(args[1], out operation)) return (int)HundledExceptions.WrongOperation;
            if (!TryParseArgOrQuit(args[0], out val1) || !TryParseArgOrQuit(args[2], out val2)) 
                return (int)HundledExceptions.WrongArgFormatInt;
            
            return (int)HundledExceptions.Success;
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

        private static bool CheckArgLength(IReadOnlyCollection<string> args)
        {
            var length = args.Count;
            if (length == 3) return true;
            Console.WriteLine($"The program requires 3 arguments, but was {length}");
            return false;
        }
        
        private static bool TryParseArgOrQuit(string arg, out int val)
        {
            if (int.TryParse(arg, out val)) return true;
            Console.WriteLine($"Value is not int: {arg}");
            return false;
        }
    }
}