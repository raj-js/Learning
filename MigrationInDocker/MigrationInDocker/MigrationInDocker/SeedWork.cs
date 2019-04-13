using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MigrationInDocker
{
    class SeedWork
    {
        public static async Task SeedAsync()
        {
            using (var db = new SimpleDbContext())
            {
                db.Database.Migrate();

                if (!await db.Logs.AnyAsync())
                {
                    db.Logs.Add(new Log
                    {
                        Level = LogLevel.Info,
                        Content = "初始化..."
                    });

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
