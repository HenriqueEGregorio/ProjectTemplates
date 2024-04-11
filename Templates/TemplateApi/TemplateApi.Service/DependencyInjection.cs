using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateApi.Domain.Interfaces.Repository.Repositories;
using TemplateApi.Domain.Interfaces.Services;
using TemplateApi.Infrastructure.Repositories.Data;
using TemplateApi.Service.Services;

namespace TemplateApi.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<IExampleEntityService, ExampleEntityService>();
            #endregion

            #region Repository
            services.AddScoped<IExampleEntityRepository, ExampleEntityRepository>();
            #endregion

            return services;
        }
    }
}