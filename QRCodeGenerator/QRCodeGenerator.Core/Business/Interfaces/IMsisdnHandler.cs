using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.Core.Business.Interfaces;

public interface IMsisdnHandler
{
    /// <summary>
    /// Generates msisdn QR code
    /// </summary>
    /// <param name="request">Msisdn QR code request object</param>
    /// <returns></returns>
    Task<byte[]> GenerateQrCode(MsisdnQrCodeRequest request);
}