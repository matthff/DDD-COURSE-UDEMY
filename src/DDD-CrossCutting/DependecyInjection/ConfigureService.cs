using DDD_Domain.Interfaces.Services;
using DDD_Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DDD_CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
