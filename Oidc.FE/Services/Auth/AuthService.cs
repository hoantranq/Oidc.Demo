using Oidc.FE.Models.Requests;
using Oidc.FE.Models.Responses;
using QRCoder;

namespace Oidc.FE.Services.Auth;

public class AuthService : IAuthService
{
    public async Task<QrCodeDataResponse> GenerateLoginWithQrCodePage(AuthRequest authRequest)
    {
        var data = $"{authRequest.redirect_uri}";


        using var qRCodeGenerator = new QRCodeGenerator();

        var qrCodeData = qRCodeGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

        var imageType = Base64QRCode.ImageType.Png;

        var qrCode = new Base64QRCode(qrCodeData);

        var qrCodeImageAsBase64 = qrCode.GetGraphic(20, SixLabors.ImageSharp.Color.Black, SixLabors.ImageSharp.Color.White, true, imageType);

        var qrCodeDataResponse = new QrCodeDataResponse
        {
            QrCodeImageAsBase64 = qrCodeImageAsBase64,
            ImageType = imageType.ToString().ToLower(),
        };

        return await Task.FromResult(qrCodeDataResponse);
    }
}