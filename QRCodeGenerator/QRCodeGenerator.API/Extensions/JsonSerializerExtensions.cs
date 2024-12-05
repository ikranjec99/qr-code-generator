using System.Text.Json;

namespace QRCodeGenerator.API.Extensions;

public static class JsonSerializerExtensions
{
    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions()
        {
            WriteIndented = true
        };
    }
}