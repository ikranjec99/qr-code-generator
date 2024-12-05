using Microsoft.Extensions.Logging;

namespace QRCodeGenerator.Core.Business.Extensions;

public static class LoggerExtensions
{
    public static void LogTryGenerateWiFiQrCode(this ILogger logger, string ssid)
        => logger.LogInformation($"Trying to generate Wi-Fi QR code for SSID {ssid}");

    public static void LogWiFiQrCodeGenerated(this ILogger logger, string ssid)
        => logger.LogInformation($"Wi-Fi QR code generated for SSID {ssid}");
}