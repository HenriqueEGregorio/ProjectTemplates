using Microsoft.AspNetCore.Builder;
using TemplateEntity.Api.Service.Middlewares;

namespace TemplateEntity.Api.Service.Extensions;

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}
