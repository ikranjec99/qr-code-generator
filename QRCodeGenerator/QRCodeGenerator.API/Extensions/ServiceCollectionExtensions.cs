using Serilog.Events;
using Serilog;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.API.Filters;
using QRCodeGenerator.API.Helpers;
using QRCodeGenerator.API.Settings;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Implementations;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Configuration;

namespace QRCodeGenerator.API.Extensions;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {

        services
            .AddScoped<IWiFiHandler, WiFiHandler>()
            .AddScoped<IWhatsAppMessageHandler, WhatsAppMessageHandler>();
        
        return services;
    }

    private static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
    {
        /*
        services
            .AddSingleton<IDisposableDomainService, DisposableDomainService>();
        */
        //throw new NotImplementedException();
        return services;
    }

    private static IServiceCollection AddSettings(this IServiceCollection services, AppSettings appSettings)
    {

        appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));

        services.AddSingleton<IQrCodeConfiguration[]>(appSettings.QrCodeConfigurations);
        
        return services;
    }

    private static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override(nameof(Microsoft), LogEventLevel.Information)
            .MinimumLevel.Override(nameof(System), LogEventLevel.Information)
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Destructure.With<NullIgnoringDestructuringPolicy>()
            .CreateLogger();

        return services;
    }

    public static void AddServices(this IServiceCollection services, IConfiguration configuration, AppSettings appSettings)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Ivan Kranjec"
                },
                Title = "QRCodeGenerator API",
                Version = "1.0"
            });
        });

        services.AddLogging(options => options.SetMinimumLevel(LogLevel.Debug));

        services
            .AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(new ExceptionFilter(Log.Logger));
            });

        services
            .AddCors(options =>
            {
                options.AddPolicy(nameof(CorsPolicy), builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services
            .AddApiVersioning(setup =>
            {
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.DefaultApiVersion = new ApiVersion(1, 0);
            })
            .AddRouting(options => options.LowercaseUrls = true)
            .AddSettings(appSettings)
            .AddBusinessLayer()
            .AddDataAccessLayer()
            .AddHttpContextAccessor();
    }
}
