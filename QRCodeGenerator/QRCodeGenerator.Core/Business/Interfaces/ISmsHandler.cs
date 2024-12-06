using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.Core.Business.Interfaces;

public interface ISmsHandler
{
    /// <summary>
    /// Generates SMS QR code
    /// </summary>
    /// <param name="request">Sms QR code request object</param>
    /// <returns></returns>
    Task<byte[]> GenerateQrCode(SmsQrCodeRequest request);
}
