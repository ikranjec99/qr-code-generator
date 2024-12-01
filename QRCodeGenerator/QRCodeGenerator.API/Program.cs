using QRCodeGenerator.API.Extensions;
using QRCodeGenerator.API.Settings;
using System.Text.Json;

namespace QRCodeGenerator.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add webhost config
        builder.WebHost.Configure();

        // Add host config
        builder.Host.Configure();

        var configuration = builder.Configuration;
        var appSettings = configuration.Get<AppSettings>();

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        Console.WriteLine(JsonSerializer.Serialize(appSettings, jsonSerializerOptions));

        // Add services to the contianer.
        builder.Services.AddServices(configuration, appSettings);

        var app = builder.ConfigureWebApplication();

        app.Run();
    }
}
