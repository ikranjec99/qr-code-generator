using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/generate")]
public class QrCodeGeneratorController : ControllerBase
{
    private readonly ISmsHandler _smsHandler;
    private readonly IUrlHandler _urlHandler;
    private readonly IWhatsAppMessageHandler _whatsAppMessageHandler;
    private readonly IWiFiHandler _wiFiHandler;

    public QrCodeGeneratorController(ISmsHandler smsHandler,
        IUrlHandler urlHandler,
        IWhatsAppMessageHandler whatsAppMessageHandler,
        IWiFiHandler wiFiHandler)
    {
        _smsHandler = smsHandler;
        _urlHandler = urlHandler;
        _whatsAppMessageHandler = whatsAppMessageHandler;
        _wiFiHandler = wiFiHandler;
    }
    
    [HttpPost("sms")]
    public async Task<IActionResult> Generate(SmsQrCodeRequest request)
    {
        var byteArray = await _smsHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
    
    [HttpPost("url")]
    public async Task<IActionResult> Generate(UrlQrCodeRequest request)
    {
        var byteArray = await _urlHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
    
    [HttpPost("whatsapp")]
    public async Task<IActionResult> Generate(WhatsAppMessageQrCodeRequest request)
    {
        var byteArray = await _whatsAppMessageHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
    
    [HttpPost("wifi")]
    public async Task<IActionResult> Generate(WiFiQrCodeRequest request)
    {
        var byteArray = await _wiFiHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
}