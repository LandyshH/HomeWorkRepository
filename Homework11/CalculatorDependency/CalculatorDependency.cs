using System.Collections.Generic;
using System.Linq.Expressions;

namespace Homework11.CalculatorDependency
{
    public class CalculatorDependency : ICalculatorDependency
    {
        private readonly Dictionary<Expression, Expression[]> _dependencies = new();

        public Expression Visit(Expression node)
        {
            return Visit((dynamic) node);
        }
        
        public Dictionary<Expression, Expression[]> GetGraphDependencies(Expression expression)
        {
            Visit(expression);
            return _dependencies;
        }

        private Expression Visit(BinaryExpression node)
        {
            _dependencies.Add(node, new []{ node.Left, node.Right });
            Visit(node.Left);
            Visit(node.Right);
            return node;
        }

        private Expression Visit(ConstantExpression node)
        {
            _dependencies.Add(node, null);
            return node;
        }
    }
}