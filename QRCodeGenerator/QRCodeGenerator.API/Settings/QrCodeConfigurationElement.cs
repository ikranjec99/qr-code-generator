using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Configuration;

namespace QRCodeGenerator.API.Settings;

public class QrCodeConfigurationElement : IQrCodeConfiguration
{
    public required int PixelPerModule { get; init; }
    
    public required QrCodeType QrCodeType { get; init; }
}