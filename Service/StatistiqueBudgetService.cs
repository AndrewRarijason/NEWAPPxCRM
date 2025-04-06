// 📌 Service pour récupérer les statistiques depuis l'API
using System.Text.Json;
using new_app_dotnet.Models;

namespace new_app_dotnet.Service;
public class StatistiqueBudgetService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "http://localhost:8080/api/statistiques"; // 🔹 Changer si nécessaire

    public StatistiqueBudgetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // 🔹 Récupère les statistiques sous forme de liste fusionnée
    public async Task<(List<StatistiqueBudgetDto>, DepenseStatDTO)> GetStatistiquesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(ApiUrl);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            // 🔹 Désérialisation complète du JSON en objet dynamique
            var result = JsonSerializer.Deserialize<JsonElement>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var budgets = JsonSerializer.Deserialize<List<StatistiqueBudgetDto>>(result.GetProperty("statistiqueBudgets").GetRawText()) ?? new();
            var depenseStat = JsonSerializer.Deserialize<DepenseStatDTO>(result.GetProperty("depenseStat").GetRawText()) ?? new();

            return (budgets, depenseStat);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la récupération des statistiques : {ex.Message}");
            return (new List<StatistiqueBudgetDto>(), new DepenseStatDTO());
        }
    }
}
