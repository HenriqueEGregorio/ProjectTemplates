using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TemplateApi.Domain.Exceptions
{
    public class CustomError : ProblemDetails
    {
        public IDictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public CustomError(
            HttpStatusCode statusCode = HttpStatusCode.BadRequest
            , string? detail = null
            , IDictionary<string, List<string>>? errors = null
            )
        {
            Status = (int)statusCode;
            Detail = detail;
            Title = statusCode switch
            {
                HttpStatusCode.BadRequest => "One or more validations errors occured.",
                HttpStatusCode.InternalServerError => "Internal server error.",
                _ => "An error has occured."
            };

            if (errors is not null)
            {
                Errors = errors;
            }
        }
    }
}
