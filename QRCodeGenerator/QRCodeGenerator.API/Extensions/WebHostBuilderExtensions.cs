using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace QRCodeGenerator.API.Extensions;

public static class WebHostBuilderExtensions
{
    private static void ConfigureKestrel(KestrelServerOptions options) 
    {
        options.AllowSynchronousIO = true;
    }

    public static IWebHostBuilder Configure(this IWebHostBuilder builder) =>
        builder.ConfigureKestrel(ConfigureKestrel)
            .ConfigureLogging((_, loggingBuilder) => loggingBuilder.ClearProviders());
}
