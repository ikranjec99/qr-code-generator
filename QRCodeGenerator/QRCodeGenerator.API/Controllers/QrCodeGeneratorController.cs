using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/generate")]
public class QrCodeGeneratorController : ControllerBase
{
    private readonly IMsisdnHandler _msisdnHandler;
    private readonly ISmsHandler _smsHandler;
    private readonly IUrlHandler _urlHandler;
    private readonly IWhatsAppMessageHandler _whatsAppMessageHandler;
    private readonly IWiFiHandler _wiFiHandler;

    public QrCodeGeneratorController(
        IMsisdnHandler msisdnHandler,
        ISmsHandler smsHandler,
        IUrlHandler urlHandler,
        IWhatsAppMessageHandler whatsAppMessageHandler,
        IWiFiHandler wiFiHandler
    )
    {
        _msisdnHandler = msisdnHandler;
        _smsHandler = smsHandler;
        _urlHandler = urlHandler;
        _whatsAppMessageHandler = whatsAppMessageHandler;
        _wiFiHandler = wiFiHandler;
    }

    [HttpPost("msisdn")]
    public async Task<IActionResult> Generate(MsisdnQrCodeRequest request)
    {
        var byteArray = await _msisdnHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
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