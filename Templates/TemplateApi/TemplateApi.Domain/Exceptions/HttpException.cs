using System.Net;

namespace TemplateApi.Domain.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public IDictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public HttpException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpException(HttpStatusCode statusCode, CustomError error)
            : base()
        {
            StatusCode = statusCode;
            Errors = error.Errors;
        }

        public HttpException(HttpStatusCode statusCode, string message, CustomError error)
            : base(message)
        {
            StatusCode = statusCode;
            Errors = error.Errors;
        }
    }
}
