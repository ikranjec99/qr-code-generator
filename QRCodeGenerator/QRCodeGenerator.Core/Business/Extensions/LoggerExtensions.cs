using Microsoft.Extensions.Logging;
using QRCodeGenerator.Core.Business.Constants;

namespace QRCodeGenerator.Core.Business.Extensions;

public static class LoggerExtensions
{
    public static void LogInvalidMsisdn(this ILogger logger)
        => logger.LogInformation("Invalid msisdn");

    public static void LogInvalidUrl(this ILogger logger, string url)
        => logger.LogInformation($"Invalid URL {url}");

    public static void LogTryGenerateQrCode(this ILogger logger, QrCodeType type)
        => logger.LogInformation($"Trying to generate {type} QR code");

    public static void LogQrCodeGenerated(this ILogger logger, QrCodeType type)
        => logger.LogInformation($"{type} QR code generated");

    public static void LogQrCodeConfigurationNotImplemented(this ILogger logger, int id)
        => logger.LogInformation($"QR code configuration not implemented for id {id}");
}