using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EF_SQLite
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dbName = "sqlitedb1.db";
            if (File.Exists(dbName)) File.Delete(dbName);

            await using var dbContext = new SqliteDbContext();
            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.Products.AddRangeAsync(new Product[]
            {
                new Product(){PuroductName = "Apple", Price = 10.99},
                new Product(){PuroductName = "Mango", Price = 15.99},
                new Product(){PuroductName = "Banana", Price = 20.99}
            });
            await dbContext.SaveChangesAsync();
            Console.WriteLine("getting database data");
            dbContext.Products?.ToList().ForEach(p =>
            {
                Console.WriteLine($"{p.PuroductName} Price: {p.Price}");
            });
            Console.ReadLine();
        }
    }
}