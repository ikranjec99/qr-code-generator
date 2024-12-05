using static QRCoder.PayloadGenerator.WiFi;

namespace QRCodeGenerator.Core.Business.Constants;

public static class WiFiAuthenticationTypeMapping
{
    public static Dictionary<Authentication, WiFiAuthenticationType> Mapping =
        new Dictionary<Authentication, WiFiAuthenticationType>()
        {
            { Authentication.WEP, WiFiAuthenticationType.Wep },
            { Authentication.WPA, WiFiAuthenticationType.Wpa },
            { Authentication.WPA2, WiFiAuthenticationType.Wpa2 },
            { Authentication.nopass, WiFiAuthenticationType.None }
        };
}