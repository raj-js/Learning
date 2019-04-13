using System;

namespace MigrationInDocker
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedWork.SeedAsync().Wait();

            var db = new SimpleDbContext();

            do
            {
                Console.WriteLine("type some words to insert a new log :");

                var words = Console.ReadLine();
                db.Add(new Log
                {
                    Level = LogLevel.Info,
                    Content = words
                });
                db.SaveChanges();

                Console.WriteLine("press 'y' to continue...");
            }
            while ("y".Equals(Console.ReadLine()));

            Console.ReadKey();

            db.Dispose();
        }
    }
}
