using QRCodeGenerator.API.Extensions;
using QRCodeGenerator.API.Settings;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        Console.WriteLine(JsonConvert.SerializeObject(appSettings, Formatting.Indented));

        // Add services to the contianer.
        builder.Services.AddServices(configuration, appSettings);

        var app = builder.ConfigureWebApplication();

        app.Run();
    }
}
