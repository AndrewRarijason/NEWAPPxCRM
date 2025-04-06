using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_app_dotnet.Models;
using new_app_dotnet.Service;

[Authorize]
[Authorize(Roles = "ROLE_MANAGER")]
public class HomeController : Controller
{
    private readonly StatistiqueBudgetService _statistiqueService;
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger, StatistiqueBudgetService statistiqueService)
    {
        _logger = logger;
        _statistiqueService = statistiqueService;
    }

    // Action principale qui affiche le tableau de bord
    public async Task<IActionResult> IndexAsync()
    {
        var (statistiques, depenseStat) = await _statistiqueService.GetStatistiquesAsync();

        var viewModel = new DashboardViewModel
        {
            StatistiqueBudgets = statistiques,
            DepenseStat = depenseStat
        };

        return View(viewModel);
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


public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddHttpClient<StatistiqueBudgetService>(); //  Ajoute HttpClient pour les appels API
    }
}