using Microsoft.AspNetCore.Http;
using TemplateApi.Domain.Exceptions;

namespace TemplateApi.Service.Middleware
{
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
            var errorResponse = new ErrorResponse()
            {
                Message = exception.Message
            };

            if (exception is HttpException httpException)
            {
                errorResponse.StatusCode = httpException.StatusCode;
                errorResponse.Errors = httpException.Errors;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            await context.Response.WriteAsync(errorResponse.ToJsonString());
        }
    }
}
