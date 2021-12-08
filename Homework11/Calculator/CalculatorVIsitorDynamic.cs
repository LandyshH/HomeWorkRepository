using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework11.Calculator
{
    public class CalculatorVisitor
    {
        public Expression Visit(Expression expression) => Visit((dynamic) expression);
        public Expression Visit(ConstantExpression constant) => constant;
        public Expression Visit(BinaryExpression node)
        {
            Task.Delay(1000);
            var first = Task.Run(() => Visit(node.Left));
            var second = Task.Run(() => Visit(node.Right));
            
            Task.WhenAll(first, second);

            var firstResult =(ConstantExpression) first.Result;
            var secondResult = (ConstantExpression) second.Result;

            var val1 = (double) firstResult.Value;
            var val2 = (double) secondResult.Value;

            var res = node.NodeType switch
            {
                ExpressionType.Add        => val1 + val2,
                ExpressionType.Subtract   => val1 - val2,
                ExpressionType.Multiply   => val1 * val2,
                ExpressionType.Divide     => val1 / val2,
            };

            return Expression.Constant(res);
        }
    }
}