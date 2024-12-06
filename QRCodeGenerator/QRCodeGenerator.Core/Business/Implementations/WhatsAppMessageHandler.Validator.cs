﻿using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class WhatsAppMessageHandler
{
    private void EnsureGenerateAllowed(string msisdn)
    {
        if (_configuration is null)
        {
            _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.WhatsApp);
            throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.WhatsApp);
        }

        _phoneNumberUtil.Parse(msisdn, null);
    }
}