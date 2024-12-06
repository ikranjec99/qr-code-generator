using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class WiFiHandler
{
    private void EnsureGenerateAllowed()
    {
        if (_configuration is null)
        {
            _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.WiFi);
            throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.WiFi);
        }
    }
}
