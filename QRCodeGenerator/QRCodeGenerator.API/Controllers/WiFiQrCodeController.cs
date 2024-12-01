using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WiFiQrCodeController : ControllerBase
{
    private readonly IWiFiQrCodeHandler _wiFiQrCodeHandler;
    
    public WiFiQrCodeController(IWiFiQrCodeHandler wiFiQrCodeHandler)
        => _wiFiQrCodeHandler = wiFiQrCodeHandler;

    [HttpPost]
    public async Task<IActionResult> Generate(WiFiQrCodeRequest request)
    {
        var qrCodeAsPngByteArr = await _wiFiQrCodeHandler.GenerateWiFiQrCode(request);
        return File(qrCodeAsPngByteArr, MediaType.Png);
    }
}