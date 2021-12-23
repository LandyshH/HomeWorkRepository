using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Homework11.Controllers;
using Homework11.Database;
using Homework11.Database.Models;
using Homework11.ParallelCalculator;
using Microsoft.EntityFrameworkCore;

namespace Homework11.Calculator
{
    public class ParallelCalculatorCache : IParallelCalculator
    {
        public ParallelCalculatorCache(ParallelCalculator.ParallelCalculator calculator)
        {
            Calculator = calculator;
        }

        private readonly ConcurrentDictionary<string, double> _cache = new();
        private ParallelCalculator.ParallelCalculator Calculator { get; }
        
        public Task<double> CalculateAsync(Dictionary<Expression, Expression[]> dependencies)
        {
            return CalculateAsync(dependencies.First().Key, dependencies);
        }

        public async Task<double> CalculateAsync(Expression current,
            IReadOnlyDictionary<Expression, Expression[]> dependencies)
        {
            var result = _cache.GetOrAdd(current.ToString(), await Calculator.CalculateAsync(current, dependencies));
            return result;
        }
    }
}