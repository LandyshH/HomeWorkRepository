using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework10.ParallelCalculator
{
    public interface IParallelCalculator
    {
        Task<double> CalculateAsync(Dictionary<Expression, Expression[]> dependencies);

        Task<double> CalculateAsync(Expression current,
            IReadOnlyDictionary<Expression, Expression[]> dependencies);
    }
}