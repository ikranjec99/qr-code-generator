using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.Core.Business.Interfaces;

public interface IWiFiHandler
{
    /// <summary>
    /// Generates WiFi QR code
    /// </summary>
    /// <param name="request">WiFi QR code request object</param>
    /// <returns></returns>
    Task<byte[]> GenerateQrCode(WiFiQrCodeRequest request);
}