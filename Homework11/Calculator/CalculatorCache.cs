﻿using System.Collections.Generic;
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
        public ParallelCalculatorCache(ApplicationContext applicationContext, 
            ParallelCalculator.ParallelCalculator calculator)
        {
            ApplicationContext = applicationContext;
            Calculator = calculator;
        }

        private ApplicationContext ApplicationContext { get; }
        private ParallelCalculator.ParallelCalculator Calculator { get; }
        
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