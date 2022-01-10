using System.Threading.Tasks;
using DataBase.Models;
using DataBase.Repository;

namespace DataBase.MonsterRepository
{
    public interface IMonsterRepository : IRepository<Monster>
    {
        Task<Monster> ReturnRandomMonster();
    }
}