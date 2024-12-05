using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/generate")]
public class WiFiQrCodeController : ControllerBase
{
    private readonly IWiFiHandler _wiFiHandler;
    
    public WiFiQrCodeController(IWiFiHandler wiFiHandler)
        => _wiFiHandler = wiFiHandler;

    [HttpPost("wifi")]
    public async Task<IActionResult> Generate(WiFiQrCodeRequest request)
    {
        var byteArray = await _wiFiHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
}