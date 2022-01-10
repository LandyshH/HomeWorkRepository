using System;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Models;
using DataBase.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase.MonsterRepository
{
    public class MonsterRepository : Repository<Monster>, IMonsterRepository
    {
        public MonsterRepository(ApplicationContext applicationContext) 
            : base(applicationContext)
        { }
        
        public async Task<Monster> FindAsync(int id)
        {
            return await FindModelAsync(id);
        }

        public async Task<Monster> AddAsync(Monster monster)
        {
            return await AddModelAsync(monster);
        }

        public async Task<Monster> ReturnRandomMonster()
        {
            var count = await ApplicationContext.Monsters.CountAsync();
            if (count == 0)
                throw new IndexOutOfRangeException();
            
            var rnd = new Random();
            var skip = rnd.Next(0, count);
            return await ApplicationContext.Monsters.Skip(skip).FirstAsync();
        }
    }
}