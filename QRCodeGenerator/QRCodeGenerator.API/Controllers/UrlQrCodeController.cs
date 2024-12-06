using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/generate")]
public class UrlQrCodeController : ControllerBase
{
    private readonly IUrlHandler _urlHandler;
    
    public UrlQrCodeController(IUrlHandler urlHandler)
        => _urlHandler = urlHandler;

    [HttpPost("url")]
    public async Task<IActionResult> Generate(UrlQrCodeRequest request)
    {
        var byteArray = await _urlHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
}
