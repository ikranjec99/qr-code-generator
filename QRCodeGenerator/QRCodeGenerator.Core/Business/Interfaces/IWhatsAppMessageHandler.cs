using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.Core.Business.Interfaces;

public interface IWhatsAppMessageHandler
{
    /// <summary>
    /// Generates WhatsApp message QR code
    /// </summary>
    /// <param name="request">WhatsApp message QR code request object</param>
    /// <returns></returns>
    Task<byte[]> GenerateQrCode(WhatsAppMessageQrCodeRequest request);
}