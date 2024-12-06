using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Core.Business.Constants;
using QRCodeGenerator.Core.Business.Interfaces;
using QRCodeGenerator.Core.Business.Models;

namespace QRCodeGenerator.API.Controllers;

[ApiController]
[Route("api/generate")]
public class SmsQrCodeController : ControllerBase
{
    private readonly ISmsHandler _smsHandler;
    
    public SmsQrCodeController(ISmsHandler smsHandler)
        => _smsHandler = smsHandler;
    
    [HttpPost("sms")]
    public async Task<IActionResult> Generate(SmsQrCodeRequest request)
    {
        var byteArray = await _smsHandler.GenerateQrCode(request);
        return File(byteArray, MediaType.Png);
    }
}