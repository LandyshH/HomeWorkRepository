using Homework11.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework11.Database
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