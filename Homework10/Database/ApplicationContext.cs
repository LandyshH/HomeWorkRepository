using Homework10.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework10.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Calculation> Calculations { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) 
            : base(contextOptions)
        {
        }
    }
}