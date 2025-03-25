using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newApp.Models;
using Microsoft.AspNetCore.Http; // Pour utiliser HttpContext

namespace newApp.Controllers;

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

    public IActionResult Accueil()
    {
        if (HttpContext.Session.GetString("isAuthenticated") != "true")
        {
            return RedirectToAction("Index", "Login"); // Redirige vers la page de login si non authentifié
        }

        return View();
    }

    public IActionResult Test()
    {
        if (HttpContext.Session.GetString("isAuthenticated") != "true")
        {
            return RedirectToAction("Test"); // Redirige vers la page de login si non authentifié
        }

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
}
