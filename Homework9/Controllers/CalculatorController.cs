using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Homework9.Controllers
{
    public static class StringExtensions
    {
        public static string LeadToCorrectView(this string expression)
        {
            return expression.ToLower()
                .Replace("plus", "+")
                .Replace("minus", "-")
                .Replace("divide", "/")
                .Replace("multiply", "*")
                .Replace("lb", "(")
                .Replace("rb", ")");
        }

        public static IEnumerable<string> ParseBySpace(this string expression)
        {
            return expression.Split();
        }
        
        public static bool IsOperation(this string arg)
        {
            return arg is "+" or "-" or "/" or "*";
        }
    }
       //var first = Task.Run(() => Visit(node.Left));
       //var second = Task.Run(() => Visit(node.Right));
    // Task.Delay(1000);
    // Task.WhenAll(first, second);

    // var firstResult =(ConstantExpression) first.Result;
    // var secondResult = (ConstantExpression) second.Result;
    public class CalculatorVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var first = Visit(node.Left);
            var second = Visit(node.Right);
            var firstResult = (ConstantExpression) first;
            var secondResult = (ConstantExpression) second;
            var val1 = (double) firstResult.Value;
            var val2 = (double) secondResult.Value;

            var res = node.NodeType switch
            {
                ExpressionType.Add        => val1 + val2,
                ExpressionType.Subtract   => val1 - val2,
                ExpressionType.Multiply   => val1 * val2,
                ExpressionType.Divide     => val1 / val2,
            };

            return Expression.Constant(res);
        }
    }

    public class CalculatorController : Controller
    {
        private static readonly Expression<Func<string>> Error = () => "Error";
        [HttpGet]
        public string Calculate(string expression)
        {
            var exp = ConvertToExpressionTree(expression);
            var res = exp == Error ? Error.ToString() : new CalculatorVisitor().Visit(exp).ToString();
            return res;
        }

        public Dictionary<string, byte> Priority = new()
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
        
        public Expression ConvertToExpressionTree(string expression)
        {
            var outputStack = new Stack<Expression>();
            var operationStack = new Stack<string>();
            try
            {
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
                
                return outputStack.Pop();
            }
            catch (Exception)
            {
                Expression<Func<string>> e = () => "Error";
                return e;
            }
        }
    }
}