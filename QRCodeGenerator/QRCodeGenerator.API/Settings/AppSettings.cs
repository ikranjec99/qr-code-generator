using System.ComponentModel.DataAnnotations;

namespace QRCodeGenerator.API.Settings;

public class AppSettings
{
    [Required]
    public required QrCodeConfigurationElement[] QrCodeConfigurations { get; init; }
}
