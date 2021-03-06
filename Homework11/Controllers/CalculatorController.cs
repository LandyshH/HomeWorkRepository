using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Homework11.Calculator;
using Homework11.CalculatorDependency;
using Homework11.ExceptionHandler;
using Homework11.ParallelCalculator;
using Homework11.StringExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Homework11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorDependency _calculatorDependency;
        private readonly IParallelCalculator _parallelCalculator;
        private readonly IExceptionHandler _exceptionHandler;
        
        [HttpGet]
        public async Task<string> Calculate(string expression)
        {
            try
            {
                var exp = ConvertToExpressionTree(expression);
                var dependencies = _calculatorDependency.GetGraphDependencies(exp);
                var result = await _parallelCalculator.CalculateAsync(dependencies);
                return result.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
                return e.ToString();
            }
        }

        private readonly Dictionary<string, byte> _priority = new()
        {
            {"-", 1},
            {"+", 1},
            {"/", 2},
            {"*", 2}
        };

        public CalculatorController(ICalculatorDependency calculatorDependency, IParallelCalculator parallelCalculator, IExceptionHandler exceptionHandler)
        {
            _calculatorDependency = calculatorDependency;
            _parallelCalculator = parallelCalculator;
            _exceptionHandler = exceptionHandler;
        }

        public void GenerateExpression(string op, Stack<Expression> stack)
        {
            var val1 = stack.Pop();
            var val2 = stack.Pop();
            switch (op)
            {
                case "+":
                    stack.Push(Expression.Add(val2, val1));
                    break;
                case "-":
                    stack.Push(Expression.Subtract(val2, val1));
                    break;
                case "*":
                    stack.Push(Expression.Multiply(val2, val1));
                    break;
                case "/":
                    stack.Push(Expression.Divide(val2, val1));
                    break;
            }
        }
        
        public Expression ConvertToExpressionTree(string expression)
        {
            var outputStack = new Stack<Expression>();
            var operationStack = new Stack<string>();
            var tokens = expression
                    .LeadToCorrectView()
                    .ParseBySpace();
                
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out var number))
                {
                    outputStack.Push(Expression.Constant(number));
                }
                else if (token.IsOperation())
                {
                    while (operationStack.Count != 0 && operationStack.Peek() != "(" 
                                                     && _priority[operationStack.Peek()] >= _priority[token])
                    {
                        GenerateExpression(operationStack.Pop(), outputStack);
                    }
                    
                    operationStack.Push(token);
                }
                else if (token == "(")
                {
                    operationStack.Push(token);
                }
                else if (token == ")")
                {
                    var op = operationStack.Pop();
                    while (op != "(")
                    {
                        GenerateExpression(op, outputStack);
                        op = operationStack.Pop();
                    }
                }
            }

            foreach (var op in operationStack)
            {
                GenerateExpression(op, outputStack);
            }

            if (outputStack.Count != 1) throw new ArgumentException();
            
            return outputStack.Pop();
        }
    }
}