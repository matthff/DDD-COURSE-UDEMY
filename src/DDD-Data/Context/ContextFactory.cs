using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDD_Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MySQLContext>
    {
        public MySQLContext CreateDbContext(string[] args)
        {
            //Used to create migrations
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING").ToLower();
            var optionsBuilder = new DbContextOptionsBuilder<MySQLContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new MySQLContext(optionsBuilder.Options);
        }
    }
}
