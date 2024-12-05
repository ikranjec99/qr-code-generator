namespace QRCodeGenerator.Core.Business.Exceptions;

public class BusinessException : Exception
{
    protected BusinessException() { }
    
    protected BusinessException(string message) : base(message) { }

    protected BusinessException(string message, Exception exception) : base(message, exception) { }
}