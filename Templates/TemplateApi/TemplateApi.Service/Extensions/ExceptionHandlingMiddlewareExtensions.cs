using Microsoft.AspNetCore.Builder;
using TemplateApi.Service.Middleware;

namespace TemplateApi.Service.Extensions;

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}
