using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TemplateApi.Domain.Exceptions
{
    public class CustomError : ProblemDetails
    {
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    }
}
