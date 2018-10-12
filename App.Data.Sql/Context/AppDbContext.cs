using App.DomainModels.Entities.Models; 
using Microsoft.EntityFrameworkCore; 

namespace App.Data.Sql.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options) { }
        

        public DbSet<Person> Person { get; set; }
    }
}
