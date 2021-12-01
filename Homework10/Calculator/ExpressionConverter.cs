using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Homework10.Controllers;
using Homework10.StringExtensions;

namespace Homework10.Calculator
{
    public class ExpressionConverter : IExpressionConverter
    {
        private Dictionary<string, byte> Priority = new()
        {
            {"-", 1},
            {"+", 1},
            {"/", 2},
            {"*", 2}
        };

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

        public static string LeadToCorrectView(string expression)
        {
            return expression.ToLower()
                .Replace("plus", "+")
                .Replace("minus", "-")
                .Replace("divide", "/")
                .Replace("multiply", "*")
                .Replace("lb", "(")
                .Replace("rb", ")");
        }
        
        public string TryCalculateExpressionTree(string expression)
        {
            var outputStack = new Stack<Expression>();
            var operationStack = new Stack<string>();
            try
            {
                var tokens = LeadToCorrectView(expression)
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
                                                         && Priority[operationStack.Peek()] >= Priority[token])
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
                
                var expressionResult = outputStack.Pop();
                var result = new CalculatorVisitor().Visit(expressionResult).ToString();
                return result;
            }

            catch (Exception)
            {
                return "Error";
            }
        }
    }
}