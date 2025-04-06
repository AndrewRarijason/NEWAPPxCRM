using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_app_dotnet.Models;
using System.Text.Json;

[Authorize] // 🔹 Restreint l'accès aux utilisateurs authentifiés
[Authorize(Roles = "ROLE_MANAGER")] // 🔹 Seulement pour les managers
public class BudgetController : Controller
{
    private readonly HttpClient _httpClient;

    public BudgetController()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Index(int customerId)
    {
        string apiUrl = $"http://localhost:8080/api/budgets/customer/{customerId}";
        var response = await _httpClient.GetStringAsync(apiUrl);
        var budgets = JsonSerializer.Deserialize<List<BudgetDTO>>(response);
        return View(budgets);
    }
}
