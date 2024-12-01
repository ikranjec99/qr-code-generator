namespace QRCodeGenerator.Core.Business.Models;

public record WiFiQrCodeRequest(
    string Ssid,
    string Password,
    bool HiddenSsid = false,
    bool EscapeHexStrings = true
);