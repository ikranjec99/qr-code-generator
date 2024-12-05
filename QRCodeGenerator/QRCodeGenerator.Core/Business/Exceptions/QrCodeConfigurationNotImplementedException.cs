namespace QRCodeGenerator.Core.Business.Exceptions;

public class QrCodeConfigurationNotImplementedException : BusinessException
{
    public QrCodeConfigurationNotImplementedException(int id) : base($"QR code configuration not implemented for id {id}") { }
}