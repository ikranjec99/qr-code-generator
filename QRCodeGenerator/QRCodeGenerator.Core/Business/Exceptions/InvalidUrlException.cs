namespace QRCodeGenerator.Core.Business.Exceptions;

public class InvalidUrlException : BusinessException
{
    public InvalidUrlException(string url) : base($"Invalid URL {url}") { }
}
