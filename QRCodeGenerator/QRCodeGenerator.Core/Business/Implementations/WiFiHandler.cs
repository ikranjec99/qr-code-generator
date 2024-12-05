using Microsoft.Extensions.Logging;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;
using QRCodeGenerator.Core.Business.Helpers;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;
using QRCodeGenerator.Core.Configuration;
using QRCoder;

namespace QRCodeGenerator.Core.Business.Implementations;

public class WiFiHandler : IWiFiHandler
{
    private readonly IQrCodeConfiguration[] _configuration;
    private readonly ILogger _logger;

    public WiFiHandler(ILogger<IQrCodeConfiguration> logger, IQrCodeConfiguration[] configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    
    public async Task<byte[]> GenerateQrCode(WiFiQrCodeRequest request)
    {
        try
        {
            _logger.LogTryGenerateWiFiQrCode(request.Ssid);
        
            var generator = new PayloadGenerator.WiFi(request.Ssid, request.Password, 
                PayloadGenerator.WiFi.Authentication.WPA2);

            var configuration = _configuration.FirstOrDefault(x => x.QrCodeType == QrCodeType.WiFi);

            if (configuration is null)
            {
                _logger.LogQrCodeConfigurationNotImplemented((int)QrCodeType.WiFi);
                throw new QrCodeConfigurationNotImplementedException((int)QrCodeType.WiFi);   
            }
        
            string payload = generator.ToString();

            var result = QrCodeGeneratorHelper.GenerateCode(payload, configuration.PixelPerModule);
        
            _logger.LogWiFiQrCodeGenerated(request.Ssid);

            return await Task.FromResult(result);
        }
        catch (BusinessException)
        {
            throw;
        }
    }
}