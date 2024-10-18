using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using TemplateApi.Domain.Entities;
using TemplateApi.Domain.Interfaces;
using TemplateApi.Domain.Interfaces.Data;
using TemplateApi.Domain.Interfaces.Repository.Repositories;
using TemplateApi.Domain.Interfaces.Services;
using TemplateApi.Infrastructure.Data;
using TemplateApi.Infrastructure.Repositories.Data;
using TemplateApi.Service.Services;
using TemplateApi.Service.Validators;

namespace TemplateApi.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Services
        services.AddScoped<IExampleEntityService, ExampleEntityService>();
        #endregion

        #region Repository
        IConfigurationSection dbConnectionSettings = configuration.GetSection("ConnectionStrings");

        services.Configure<Settings>(dbConnectionSettings);
        services.AddScoped<IFactory, Factory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IExampleEntityRepository, ExampleEntityRepository>();
        #endregion

        #region Validator
        services.AddFluentValidationAutoValidation();
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-br");

        services.AddValidatorsFromAssemblyContaining<ExamplePostValidator>();
        #endregion

        return services;
    }
}