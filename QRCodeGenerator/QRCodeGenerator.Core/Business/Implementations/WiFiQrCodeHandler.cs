using Microsoft.Extensions.Logging;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Helpers;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;
using QRCodeGenerator.Core.Configuration;
using QRCoder;

namespace QRCodeGenerator.Core.Business.Implementations;

public class WiFiQrCodeHandler : IWiFiQrCodeHandler
{
    private readonly IQrCodeConfiguration[] _configuration;
    private readonly ILogger _logger;

    public WiFiQrCodeHandler(ILogger<IQrCodeConfiguration> logger, IQrCodeConfiguration[] configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    
    public async Task<byte[]> GenerateWiFiQrCode(WiFiQrCodeRequest request)
    {
        var generator = new PayloadGenerator.WiFi(request.Ssid, request.Password, 
            PayloadGenerator.WiFi.Authentication.WPA2);

        var configuration = _configuration.First(x => x.QrCodeType == QrCodeType.WiFiCode);
        
        string payload = generator.ToString();

        return await Task.FromResult(QrCodeGeneratorHelper.GenerateCode(payload, configuration.PixelPerModule));
    }
}