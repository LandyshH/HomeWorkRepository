using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Monster> Monsters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var firstMonster = new Monster
            {
                Id = 1,
                Name = "Tree Blight",
                HitPoints = 92,
                AttackModifier = 3,
                AttackPerRound = 1,
                Damage = 23,
                DamageModifier = 6,
                Weapon = 9,
                ArmorClass = 15
            };
            
            var secondMonster = new Monster
            {
                Id = 2,
                Name = "Banshee",
                HitPoints = 58,
                AttackModifier = 2,
                AttackPerRound = 1,
                Damage = 6,
                DamageModifier = 2,
                Weapon = 12,
                ArmorClass = 12
            };

            var thirdMonster = new Monster
            {
                Id = 3,
                Name = "Hell Hound",
                HitPoints = 45,
                AttackModifier = 2,
                AttackPerRound = 1,
                Damage = 14,
                DamageModifier = 21,
                Weapon = 5,
                ArmorClass = 15
            };
            
            modelBuilder.Entity<Monster>().HasData(firstMonster, secondMonster, thirdMonster);
            base.OnModelCreating(modelBuilder);
        }
    }
}