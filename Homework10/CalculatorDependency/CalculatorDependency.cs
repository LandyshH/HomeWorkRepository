using System.Collections.Generic;
using System.Linq.Expressions;

namespace Homework10.CalculatorDependency
{
    public class CalculatorDependency : ExpressionVisitor, ICalculatorDependency
    {
        private readonly Dictionary<Expression, Expression[]> _dependencies = new();

        public Dictionary<Expression, Expression[]> GetGraphDependencies(Expression expression)
        {
            Visit(expression);
            return _dependencies;
        }
        
        protected override Expression VisitBinary(BinaryExpression node)
        {
            _dependencies.Add(node, new []{ node.Left, node.Right });
            Visit(node.Left);
            Visit(node.Right);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _dependencies.Add(node, null);
            return node;
        }
    }
}