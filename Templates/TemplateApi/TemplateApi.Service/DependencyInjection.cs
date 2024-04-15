using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using TemplateApi.Domain.Interfaces.Repository.Repositories;
using TemplateApi.Domain.Interfaces.Services;
using TemplateApi.Infrastructure.Repositories.Data;
using TemplateApi.Service.Services;
using TemplateApi.Service.Validators;

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

            #region
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ExampleValidator>();

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-br");
            #endregion

            return services;
        }
    }
}