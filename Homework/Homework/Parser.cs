using System;
using System.Collections.Generic;

namespace HomeWork
{
    public static class Parser
    {
        public static HundledExceptions ParseArguments(string[] args, out CalculatorProblem problem)
        {
            problem = new CalculatorProblem();
            if (!CheckArgLength(args)) return HundledExceptions.WrongArgLength;
            if (!TryParseOperationOrQuit(args[1], out var operation)) return HundledExceptions.WrongOperation;
            if (!TryParseArgOrQuit(args[0], out var val1) || !TryParseArgOrQuit(args[2], out var val2)) 
                return HundledExceptions.WrongArgFormatInt;
            problem = new CalculatorProblem(val1, operation, val2);
            return HundledExceptions.Success;
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