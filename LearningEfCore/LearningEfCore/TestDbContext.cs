using Microsoft.EntityFrameworkCore;

namespace LearningEfCore
{
    public class TestDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>()
                .Property(s => s.FirstName).IsConcurrencyToken();

            //builder.Entity<Person>()
            //    .Property(s => s.Timestamp).IsRowVersion();
        }
    }
}
