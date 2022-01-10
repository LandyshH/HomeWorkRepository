using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repository
{
    public class Repository<T> where T : class
    {
        protected readonly ApplicationContext ApplicationContext;

        protected readonly DbSet<T> DbSet;

        public Repository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DbSet = applicationContext.Set<T>();
        }

        public async Task<T> FindModelAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> AddModelAsync(T entity)
        {
            var t = await DbSet.AddAsync(entity);
            await ApplicationContext.SaveChangesAsync();
            return t.Entity;
        }
    }
    
}