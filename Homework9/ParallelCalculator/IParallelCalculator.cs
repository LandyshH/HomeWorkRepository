using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework9.ParallelCalculator
{
    public interface IParallelCalculator
    {
        Task<double> CalculateAsync(Dictionary<Expression, Expression[]> dependencies);
    }
}