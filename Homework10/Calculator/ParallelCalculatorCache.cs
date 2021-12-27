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

        private static readonly ConcurrentDictionary<string, double> Cache = new();
        private ParallelCalculator.ParallelCalculator Calculator { get; }

        public Task<double> CalculateAsync(Dictionary<Expression, Expression[]> dependencies)
        {
            return CalculateAsync(dependencies.First().Key, dependencies);
        }

        public async Task<double> CalculateAsync(Expression current,
            IReadOnlyDictionary<Expression, Expression[]> dependencies)
        {
            var isExist = Cache.ContainsKey(current.ToString());
            if (!isExist)
            {
                var result = Cache
                    .GetOrAdd(current.ToString(), await Calculator.CalculateAsync(current, dependencies));
                return result;
            }
            
            var cacheCalculation = Cache
                .FirstOrDefault(x =>x.Key == current.ToString()).Value;
            
         return cacheCalculation;
        }
    }
}