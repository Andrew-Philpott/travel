// using System.IO;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;

// namespace TravelClient.Models
// {
//     public class TravelApiContextFactory : IDesignTimeDbContextFactory<TravelApiContext>
//     {

//         TravelApiContext IDesignTimeDbContextFactory<TravelApiContext>.CreateDbContext(string[] args)
//         {
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetCurrentDirectory())
//               .AddJsonFile("appsettings.json")
//               .Build();

//             var builder = new DbContextOptionsBuilder<TravelApiContext>();
//             var connectionString = configuration.GetConnectionString("DefaultConnection");

//             builder.UseMySql(connectionString);

//             return new TravelApiContext(builder.Options);
//         }
//     }
// }