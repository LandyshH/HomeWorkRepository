using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Homework10.Controllers;
using Homework10.Database;
using Homework10.Database.Models;
using Homework10.ParallelCalculator;
using Microsoft.EntityFrameworkCore;

namespace Homework10.Calculator
{
    public class ParallelCalculatorCache : IParallelCalculator
    {
        public ParallelCalculatorCache(ApplicationContext applicationContext, ParallelCalculator.ParallelCalculator calculator)
        {
            ApplicationContext = applicationContext;
            Calculator = calculator;
        }

        private ApplicationContext ApplicationContext { get; set; }
        public ParallelCalculator.ParallelCalculator Calculator { get; set; }
        
        public Task<double> CalculateAsync(Dictionary<Expression, Expression[]> dependencies)
        {
            return CalculateAsync(dependencies.First().Key, dependencies);
        }

        public async Task<double> CalculateAsync(Expression current,
            IReadOnlyDictionary<Expression, Expression[]> dependencies)
        {
            var result = Calculator.CalculateAsync(current, dependencies);
            var calculation = new Calculation
            {
                Expression = current.ToString(),
                Result = (await result).ToString(CultureInfo.InvariantCulture)
            };
            
            ApplicationContext.Calculations.Add(calculation);
            await ApplicationContext.SaveChangesAsync();
            return await result;
        }
    }
}