using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design; 
namespace App.Data.Sql.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        /// <summary>
        /// Just FOr Migration
        /// چون سازنده DbContext دارای پارامتر است باید یک کلاس که از اینترفیس IDesignTimeDbContextFactory ارثبری کرده است بسازیم و DbContext را با پارامترهایش پر کنیم و بازگردانیم. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(@"Data Source=DESKTOP-80FGNLP\POURIYA;Initial Catalog=NewAppTest;Persist Security Info=True;User ID=sa; Password=123; MultipleActiveResultSets=True");
            return new AppDbContext(builder.Options);
        }
    }
}
