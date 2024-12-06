using Microsoft.Extensions.Logging;

namespace QRCodeGenerator.Core.Business.Extensions;

public static class LoggerExtensions
{
    public static void LogInvalidMsisdn(this ILogger logger)
        => logger.LogInformation("Invalid msisdn");

    public static void LogInvalidUrl(this ILogger logger, string url)
        => logger.LogInformation($"Invalid URL {url}");

    public static void LogTryGenerateUrlQrCode(this ILogger logger, string url)
        => logger.LogInformation($"Trying to generate URL QR code for URL {url}");

    public static void LogTryGenerateWhatsAppMessageQrCode(this ILogger logger)
        => logger.LogInformation("Trying to generate WhatsApp message QR code");
    
    public static void LogTryGenerateWiFiQrCode(this ILogger logger, string ssid)
        => logger.LogInformation($"Trying to generate Wi-Fi QR code for SSID {ssid}");

    public static void LogUrlQrCodeGenerated(this ILogger logger, string url)
        => logger.LogInformation($"QR code generated for URL {url}");

    public static void LogWhatsAppMessageQrCodeGenerated(this ILogger logger)
        => logger.LogInformation("WhatsApp message QR code generated");
    
    public static void LogWiFiQrCodeGenerated(this ILogger logger, string ssid)
        => logger.LogInformation($"Wi-Fi QR code generated for SSID {ssid}");

    public static void LogQrCodeConfigurationNotImplemented(this ILogger logger, int id)
        => logger.LogInformation($"QR code configuration not implemented for id {id}");
}