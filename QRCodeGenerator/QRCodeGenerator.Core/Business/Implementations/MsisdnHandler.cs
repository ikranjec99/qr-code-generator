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

public partial class MsisdnHandler : IMsisdnHandler
{
    private readonly ILogger _logger;
    private readonly IQrCodeConfiguration[] _configuration;
    private readonly PhoneNumberUtil _phoneNumberUtil;

    public MsisdnHandler(
        ILogger<MsisdnHandler> logger,
        IQrCodeConfiguration[] configuration)
    {
        _configuration = configuration;
        _logger = logger;
        _phoneNumberUtil = PhoneNumberUtil.GetInstance();
    }
    
    public async Task<byte[]> GenerateQrCode(MsisdnQrCodeRequest request)
    {
        try
        {
            _logger.LogTryGenerateQrCode(QrCodeType.PhoneNumber);
            
            EnsureGenerateAllowed(request.Msisdn);
            
            var generator = new PayloadGenerator.PhoneNumber(request.Msisdn);
            
            var configuration = _configuration.First(x => x.QrCodeType == QrCodeType.PhoneNumber);
            
            string payload = generator.ToString();
            
            var result = QrCodeGeneratorHelper.GenerateCode(payload, configuration.PixelPerModule);

            _logger.LogQrCodeGenerated(QrCodeType.Sms);

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