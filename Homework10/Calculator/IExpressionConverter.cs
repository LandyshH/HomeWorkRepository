using System.Linq.Expressions;

namespace Homework10.Calculator
{
    public interface IExpressionConverter
    {
        public string TryCalculateExpressionTree(string expression);
    }
}