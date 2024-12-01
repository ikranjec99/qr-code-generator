using QRCoder;

namespace QRCodeGenerator.Core.Business.Helpers;

public static class QrCodeGeneratorHelper
{
    public static byte[] GenerateCode(string payload, int pixelPerModule)
    {
        var qrGenerator = new QRCoder.QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(payload, QRCoder.QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(pixelPerModule);
    }
}