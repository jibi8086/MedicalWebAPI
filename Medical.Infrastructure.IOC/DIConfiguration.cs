using Medical.Domain;
using Medical.Domain.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Infrastructure.IOC
{
    public static class DIConfiguration
    {
        public static void AddDependency(this IServiceCollection services,IConfiguration configuration) 
        {
            AddDomainDependency(services, configuration);

        }
        private static void AddDomainDependency(IServiceCollection services, IConfiguration configuration) 
        {

            services.AddScoped<IUserService, UserService>();
        }
    }
}
