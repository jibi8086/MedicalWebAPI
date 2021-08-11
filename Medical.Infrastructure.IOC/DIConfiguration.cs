using Medical.Data.Configurations;
using Medical.Data.Contract.Configurations;
using Medical.Data.Contract.Core;
using Medical.Data.Contract.UserLogin;
using Medical.Data.Core;
using Medical.Data.UserLogin;
using Medical.Domain;
using Medical.Domain.Contract;
using Medical.Domain.Contract.UserLogin;
using Medical.Domain.UserLogin;
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

            services.AddTransient<IMedicalDbSqlHelper, MedicalDbSqlHelper>();
            services.AddTransient<ISqlServerDataAccessConfiguration, SqlServerDataAccessConfiguration>();
            services.AddTransient<ISqlFactory, SqlFactory>();
            services.AddTransient<IDataRecordMappingHelper, DataRecordMappingHelper>();
            services.AddTransient<IConnectionStringConfiguration, ConnectionStringConfiguration>();

            
           
            services.AddTransient<IUserLoginDomainService, UserLoginDomainService>();
            services.AddTransient<IUserLoginDataAccess, UserLoginDataAccess>();
            services.AddTransient<IUserLoginDataMapper, UserLoginDataMapper>();
        }
    }
}
