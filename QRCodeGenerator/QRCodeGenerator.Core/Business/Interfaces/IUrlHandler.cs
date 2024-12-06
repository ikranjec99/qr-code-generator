using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.Core.Business.Interfaces;

public interface IUrlHandler
{
    /// <summary>
    /// Generates URL link
    /// </summary>
    /// <param name="request">URL link QR code request object</param>
    /// <returns></returns>
    Task<byte[]> GenerateQrCode(UrlQrCodeRequest request);
}
