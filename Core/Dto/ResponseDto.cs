using System.Net;

namespace Core.Dto
{
    public class ResponseDto
    {
        public HttpStatusCode statusCode { get; set; }
        public bool isSuccess { get; set; }
        public object result { get; set; }
        public string message { get; set; }
    }
}
