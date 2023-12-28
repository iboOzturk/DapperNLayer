using DapperNLayer.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DapperNLayer.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApiService _apiService;

        public LoginController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            string token = await _apiService.LoginAsync(username, password);

            if (token != null)
            {
                HttpContext.Session.SetString("JwtToken", token);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("MyItems","Default");
            }

            ViewBag.ErrorMessage = "Invalid credentials";
            return View();
        }
    }
}
