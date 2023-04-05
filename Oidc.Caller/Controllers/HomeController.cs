using Microsoft.AspNetCore.Mvc;
using Oidc.Caller.Models;
using System.Diagnostics;

namespace Oidc.Caller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            var targetUrl = "https://localhost:7777/Authorize" +
                            "?client_id=123" +
                            "&redirect_uri=https://localhost:7777/Home/Privacy" +
                            "&response_type=id_token" +
                            "scope=" +
                            "state=af0ifjsldkj" +
                            "&nonce=jxdlsjfi0fa";

            return Redirect(targetUrl);
        }
    }
}