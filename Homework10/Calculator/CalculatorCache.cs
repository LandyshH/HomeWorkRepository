using System.Linq;
using System.Linq.Expressions;
using Homework10.Controllers;
using Homework10.Database;
using Homework10.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework10.Calculator
{
    public class CalculatorCache : ICacheCalculator
    {
        public IExpressionConverter ExpressionConverter { get; }
        public ApplicationContext ApplicationContext { get; }
        public CalculatorCache(ApplicationContext applicationContext, IExpressionConverter expressionConverter)
        {
            ApplicationContext = applicationContext;
            ExpressionConverter = expressionConverter;
        }

        public string TryCalculateWithCache(string expression)
        {
            var calculation = ApplicationContext.Calculations
                .FirstOrDefault(c => c.Expression == expression);
            if (calculation != null)
            {
                var res = double.Parse(calculation.Result);
                var result = Expression.Constant(res);
                return result.ToString();
            }
            else
            {
                var result = ExpressionConverter.TryCalculateExpressionTree(expression);
                var dbResult = new Calculation{Expression = expression, Result = result};
                if (result != "Error") ApplicationContext.Calculations.Add(dbResult);
                ApplicationContext.SaveChanges();
                return result;
            }
        }
    }
}