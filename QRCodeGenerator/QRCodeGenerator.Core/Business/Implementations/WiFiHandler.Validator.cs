using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class WiFiHandler
{
    private void EnsureGenerateAllowed()
    {
        var configuration = _configuration.FirstOrDefault(x => x.QrCodeType == QrCodeType.WiFi);
        
        if (configuration is null)
        {
            _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.WiFi);
            throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.WiFi);
        }
    }
}
