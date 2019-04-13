using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MigrationInRuntime
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
                        Content = "初始化...",
                        Time = DateTime.Now
                    });

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
