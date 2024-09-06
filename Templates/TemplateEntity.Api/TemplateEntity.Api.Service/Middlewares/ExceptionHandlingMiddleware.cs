using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using TemplateEntity.Api.Domain.Exceptions;

namespace TemplateEntity.Api.Service.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorResponse = new CustomError(
            statusCode: HttpStatusCode.InternalServerError
            , detail: exception.Message);

        if (exception is HttpException httpException)
        {
            errorResponse = new CustomError(
                statusCode: httpException.StatusCode
                , detail: exception.Message
                , errors: httpException.Errors);
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorResponse.Status ?? 500;
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
