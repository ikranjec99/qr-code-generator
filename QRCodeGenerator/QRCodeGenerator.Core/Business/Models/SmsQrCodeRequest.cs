namespace QRCodeGenerator.Core.Business.Models;

public record SmsQrCodeRequest(string Message, string Msisdn);