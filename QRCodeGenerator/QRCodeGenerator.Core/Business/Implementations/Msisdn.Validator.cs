using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class MsisdnHandler
{
    private void EnsureGenerateAllowed(string msisdn)
    {
        var configuration = _configuration.FirstOrDefault(x => x.QrCodeType == QrCodeType.PhoneNumber);
        
        if (configuration is null)
        {
            _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.PhoneNumber);
            throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.PhoneNumber);
        }
        
        if (string.IsNullOrWhiteSpace(msisdn))
            throw new InvalidMsisdnException();
        
        var phoneNumber = _phoneNumberUtil.Parse(msisdn, null);

        if (!_phoneNumberUtil.IsValidNumber(phoneNumber))
            throw new InvalidMsisdnException();
    }
}