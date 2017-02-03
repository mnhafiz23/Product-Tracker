using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ProductTracker.DataAccess
{
    public class TempApplicationContext : IDbContextFactory<ApplicationContext>
    {
        public ApplicationContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            string connectionString = "DataSource=C:\\Dev\\Personal\\Product-Tracker\\ProductTracker.db";
            builder.UseSqlite(connectionString);
            return new ApplicationContext(builder.Options);
        }


    }
}
