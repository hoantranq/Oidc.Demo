using Microsoft.AspNetCore.Mvc;
using Oidc.FE.Models.Requests;
using Oidc.FE.Services.Auth;

namespace Oidc.FE.Controllers;

public class AuthorizeController : Controller
{ 
    private readonly IAuthService _authService;

    public AuthorizeController(IAuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Index([FromQuery] AuthRequest authRequest)
    {
        var response = _authService.GenerateLoginWithQrCodePage(authRequest).Result;

        TempData["qrCodeImageAsBase64"] = response.QrCodeImageAsBase64;
        TempData["imgType"] = response.ImageType;

        return View();
    }

    [HttpGet]
    public IActionResult ClientLoginWithoutQrCode()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ClientLoginWithoutQrCode(UserLoginRequest userLoginRequest)
    {
        // TODO: Call BE for get token => return token in redirect uri

        // Fake token
        var id_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        return Redirect($"https://localhost:7776/Home/Privacy#{id_token}");
    }
}
