using System;
using Homework2IL;



namespace Homework2
{
    class Program
    {
        static int Main(string[] args)
        {
            var resultIs = Parser.ParseArguments(args, out var problem);
            if (resultIs != HundledExceptions.Success) return (int)resultIs;
            var result = Calculator.Calculate(problem.Val1, problem.Operation, problem.Val2);
            Console.WriteLine($"Answer is: {result}");
            return 0;
        }
    }
}