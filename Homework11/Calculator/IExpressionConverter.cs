using System.Linq.Expressions;

namespace Homework11.Calculator
{
    public interface IExpressionConverter
    {
        public string TryCalculateExpressionTree(string expression);
    }
}