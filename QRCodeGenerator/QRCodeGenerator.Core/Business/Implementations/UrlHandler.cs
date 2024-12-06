using Microsoft.Extensions.Logging;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Exceptions;
using QRCodeGenerator.Core.Business.Extensions;
using QRCodeGenerator.Core.Business.Helpers;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;
using QRCodeGenerator.Core.Configuration;
using static QRCoder.PayloadGenerator;

namespace QRCodeGenerator.Core.Business.Implementations;

public partial class UrlHandler : IUrlHandler
{
    private readonly IQrCodeConfiguration[] _configuration;
    private readonly ILogger _logger;

    public UrlHandler(ILogger<IUrlHandler> logger, IQrCodeConfiguration[] configuration)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<byte[]> GenerateQrCode(UrlQrCodeRequest request)
    {
        try
        {
            _logger.LogTryGenerateUrlQrCode(request.Url);

            EnsureGenerateAllowed(request.Url);

            var url = new Url(request.Url);

            var configuration = _configuration.FirstOrDefault(x => x.QrCodeType == QrCodeType.Url);

            string payload = url.ToString();

            var result = QrCodeGeneratorHelper.GenerateCode(payload, configuration.PixelPerModule);

            _logger.LogUrlQrCodeGenerated(request.Url);

            return await Task.FromResult(result);
        }
        catch (BusinessException)
        {
            throw;
        }
    }
}
