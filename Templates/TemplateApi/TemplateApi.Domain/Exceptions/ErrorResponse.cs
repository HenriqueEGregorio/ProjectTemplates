using System.Net;
using System.Text.Json;

namespace TemplateApi.Domain.Exceptions
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public required string Message { get; set; }

        public IDictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
