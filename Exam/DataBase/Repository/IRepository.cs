using System.Threading.Tasks;

namespace DataBase.Repository
{
    public interface IRepository<T>
    {
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T entity);
    }
}