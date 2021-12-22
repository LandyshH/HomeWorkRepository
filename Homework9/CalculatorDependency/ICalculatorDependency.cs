using System.Collections.Generic;
using System.Linq.Expressions;

namespace Homework9.CalculatorDependency
{
    public interface ICalculatorDependency
    {
        Dictionary<Expression, Expression[]> GetGraphDependencies(Expression expression);
    }
}