using Microsoft.EntityFrameworkCore;

namespace MigrationInRuntime
{
    public class SimpleDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        //public SimpleDbContext(DbContextOptions<SimpleDbContext> options)
        //    : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SimpleDb;Persist Security Info=True;User ID=sa;Password=1qaz2WSX");
        }
    }
}
