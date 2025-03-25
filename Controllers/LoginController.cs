using Microsoft.AspNetCore.Mvc;
using newApp.Service;
using Microsoft.AspNetCore.Http;

namespace newApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Supprime toutes les sessions
            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            bool isValid = await _loginService.IsValid(username, password);
            Console.WriteLine($"Login status: {isValid}");

            if (isValid)
            {
                HttpContext.Session.SetString("isAuthenticated", "true"); // Stocke la session
                return RedirectToAction("Accueil", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View("Index");
        }

    }
}