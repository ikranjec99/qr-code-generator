using Microsoft.Extensions.Logging;
using PhoneNumbers;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;
using QRCodeGenerator.Core.Business.Helpers;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;
using QRCodeGenerator.Core.Configuration;
using QRCoder;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class WhatsAppMessageHandler : IWhatsAppMessageHandler
{
    private readonly IQrCodeConfiguration[] _configuration;
    private readonly ILogger _logger;
    private readonly PhoneNumberUtil _phoneNumberUtil;
    
    public WhatsAppMessageHandler(ILogger<IWhatsAppMessageHandler> logger, IQrCodeConfiguration[] configuration)
    {
        _configuration = configuration;
        _logger = logger;
        _phoneNumberUtil = PhoneNumberUtil.GetInstance();
    }
    
    public async Task<byte[]> GenerateQrCode(WhatsAppMessageQrCodeRequest request)
    {
        try
        {
            _logger.LogTryGenerateWhatsAppMessageQrCode();

            EnsureGenerateAllowed(request.Msisdn);

            var generator = new PayloadGenerator.WhatsAppMessage(request.Msisdn, request.Message);

            var configuration = _configuration.FirstOrDefault(x => x.QrCodeType == QrCodeType.WhatsApp);

            string payload = generator.ToString();

            var result = QrCodeGeneratorHelper.GenerateCode(payload, configuration.PixelPerModule);

            _logger.LogWhatsAppMessageQrCodeGenerated();

            return await Task.FromResult(result);
        }
        catch (NumberParseException)
        {
            _logger.LogInvalidMsisdn();
            throw new InvalidMsisdnException();
        }
        catch (BusinessException)
        {
            throw;
        }
    }
}