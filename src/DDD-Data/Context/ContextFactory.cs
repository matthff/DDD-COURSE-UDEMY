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
            var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=DDD-DB-Udemy-Course;Uid=root;Pwd=451236";
            var optionsBuilder = new DbContextOptionsBuilder<MySQLContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new MySQLContext(optionsBuilder.Options);
        }
    }
}
