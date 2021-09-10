using System;
using DDD_Data.Context;
using DDD_Data.Repository;
using DDD_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD_CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            if (Environment.GetEnvironmentVariable("DB_PROVIDER").ToLower() == "MYSQL".ToLower())
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING").ToLower();
                serviceCollection.AddDbContext<MySQLContext>(
                    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                );
            }
            else
            {
                //If you want to use another database, put here the configuration with the matching condition
            }
        }
    }
}
