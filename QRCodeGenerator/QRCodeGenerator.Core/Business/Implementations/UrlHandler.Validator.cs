using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;
using QRCodeGenerator.Core.Business.Helpers;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class UrlHandler
{
    private void EnsureGenerateAllowed(string url)
    {
        if (_configuration is null)
        {
            _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.Url);
            throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.Url);
        }

        if (string.IsNullOrEmpty(url) || !UrlHelper.IsValidUrl(url))
        {
            _logger.LogInvalidUrl(url);
            throw new InvalidUrlException(url);
        }
    }
}
