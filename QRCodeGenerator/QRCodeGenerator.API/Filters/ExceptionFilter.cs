﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MediaType = QRCodeGenerator.Core.Business.Constants.MediaType;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;
using System.Text.Json;

namespace QRCodeGenerator.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly Serilog.ILogger _logger;

    public ExceptionFilter(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        int statusCode = (int)MapExceptionToStatusCode(context.Exception);

        context.Result = new ObjectResult(context.Exception.Message)
        {
            StatusCode = statusCode,
            ContentTypes = new MediaTypeCollection { new MediaTypeHeaderValue(MediaType.TextPlain) },
        };


        if (statusCode >= 500)
            _logger.Error("Exception: {Exception}", JsonSerializer.Serialize(context.Exception, BuildSerializerSettings()));

        context.ExceptionHandled = true;
    }

    internal static HttpStatusCode MapExceptionToStatusCode(Exception e) => e switch
    {
        NotImplementedException => HttpStatusCode.NotImplemented,

        _ => HttpStatusCode.InternalServerError
    };

    private static JsonSerializerOptions BuildSerializerSettings()
    {
        var settings = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return settings;
    }
}