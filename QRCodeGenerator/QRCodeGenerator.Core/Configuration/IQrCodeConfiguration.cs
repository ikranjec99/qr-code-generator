using QRCodeGenerator.Core.Business.Constants;

namespace QRCodeGenerator.Core.Configuration;

public interface IQrCodeConfiguration
{
    int PixelPerModule { get; init; }
    
    QrCodeType QrCodeType { get; init; }
}