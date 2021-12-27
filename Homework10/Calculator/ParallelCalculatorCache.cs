using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Homework10.ParallelCalculator;

namespace Homework10.Calculator
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
            var isExist = _cache.ContainsKey(current.ToString());
            if (!isExist)
            {
                var result = _cache
                    .GetOrAdd(current.ToString(), await Calculator.CalculateAsync(current, dependencies));
                return result;
            }
            
            var cacheCalculation = _cache
                .FirstOrDefault(x =>x.Key == current.ToString()).Value;
            
         return cacheCalculation;
        }
    }
}