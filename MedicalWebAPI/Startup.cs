using AutoMapper;
using Medical.Data.Contract.UserLogin;
using Medical.Domain.Contract.UserLogin;
using Medical.Infrastructure.Configurations;
using Medical.Infrastructure.IOC;
using MedicalWebAPI.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapper = GetAutoMapperConfiguration();
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddDependency(Configuration);
            //services.Configure<ConnectionStringSettings>(Configuration.GetSection(""));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalWebAPI", Version = "v1" });
            });
            services.Configure<ConnectionStringSettings>(Configuration.GetSection("ConnectionStrings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() ||env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static IMapper GetAutoMapperConfiguration() {
            var configuration = new MapperConfiguration(config => {
                config.CreateMap<UserLoginViewModel, UserLoginDomainDto>();
                config.CreateMap<UserLoginDomainDto, UserLoginViewModel>();
                config.CreateMap<UserLoginData, UserLoginDomainDto>();
                config.CreateMap<UserLoginDomainDto, UserLoginData>();
            });
            return configuration.CreateMapper();
        }
    }
}
