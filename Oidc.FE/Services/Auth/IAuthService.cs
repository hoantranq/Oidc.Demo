using Oidc.FE.Models.Requests;
using Oidc.FE.Models.Responses;

namespace Oidc.FE.Services.Auth;

public interface IAuthService
{
    Task<QrCodeDataResponse> GenerateLoginWithQrCodePage(AuthRequest authRequest);
}