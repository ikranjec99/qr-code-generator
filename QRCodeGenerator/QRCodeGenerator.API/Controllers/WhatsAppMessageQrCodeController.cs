using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/generate")]
public class WhatsAppMessageQrCodeController : ControllerBase
{
    private readonly IWhatsAppMessageHandler _whatsAppMessageHandler;

    public WhatsAppMessageQrCodeController(IWhatsAppMessageHandler whatsAppMessageHandler)
        => _whatsAppMessageHandler = whatsAppMessageHandler;

    [HttpPost("whatsapp")]
    public async Task<IActionResult> Generate(WhatsAppMessageQrCodeRequest request)
    {
        var byteArray = await _whatsAppMessageHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
}