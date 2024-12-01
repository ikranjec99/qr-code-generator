using System.Net;

namespace QRCodeGenerator.Core.Business.Exceptions;

public class HttpRequestStatusException : Exception
{
    public HttpRequestStatusException(HttpStatusCode statusCode, string responseMessage = "")
    {
        ResponseMessage = responseMessage;
        StatusCode = statusCode;
    }

    public string ResponseMessage { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}