using System.Collections.Generic;
using System.Linq.Expressions;

namespace Homework10.CalculatorDependency
{
    public interface ICalculatorDependency
    {
        Dictionary<Expression, Expression[]> GetGraphDependencies(Expression expression);
    }
}