﻿using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class WhatsAppMessageHandler
{
    private void EnsureGenerateAllowed(string msisdn)
    {
        var configuration = _configuration.FirstOrDefault(x => x.QrCodeType == QrCodeType.WhatsApp);
        
        if (configuration is null)
        {
            _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.WhatsApp);
            throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.WhatsApp);
        }

        if (string.IsNullOrWhiteSpace(msisdn))
            throw new InvalidMsisdnException();
        
        var phoneNumber = _phoneNumberUtil.Parse(msisdn, null);

        if (!_phoneNumberUtil.IsValidNumber(phoneNumber))
            throw new InvalidMsisdnException();
    }
}
