namespace QRCodeGenerator.Core.Business.Exceptions;

public class InvalidMsisdnException : BusinessException
{
    public InvalidMsisdnException() : base("Invalid msisdn") { }
}