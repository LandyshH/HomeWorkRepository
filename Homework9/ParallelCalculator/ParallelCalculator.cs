using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Homework9.ParallelCalculator
{
    public class ParallelCalculator : IParallelCalculator
    {
        private readonly ILogger<ParallelCalculator> _logger;

        public ParallelCalculator(ILogger<ParallelCalculator> logger)
        {
            _logger = logger;
        }
        
        public Task<double> CalculateAsync(Dictionary<Expression, Expression[]> dependencies)
        {
            return CalculateAsync(dependencies.First().Key, dependencies);
        }

        public async Task<double> CalculateAsync(Expression current,
            IReadOnlyDictionary<Expression, Expression[]> dependencies)
        {
            if (dependencies[current] == null)
            {
                return double.Parse(current.ToString());
            }

            var left = Task.Run(() => CalculateAsync(dependencies[current][0], dependencies));
            var right = Task.Run(() => CalculateAsync(dependencies[current][1], dependencies));


            _logger.LogInformation(current.ToString());
            
            Thread.Sleep(1000);
            var arr = await Task.WhenAll(left, right);
            return Calculate(arr[0], current.NodeType, arr[1]);
        }

        public static double Calculate(double v1, ExpressionType expressionType, double v2)
        {
            return expressionType switch
            {
                ExpressionType.Add => v1 + v2,
                ExpressionType.Subtract => v1 - v2,
                ExpressionType.Divide => v1 / v2,
                ExpressionType.Multiply => v1 * v2,
                _ => throw new NotImplementedException()
            };
        }
    }
}