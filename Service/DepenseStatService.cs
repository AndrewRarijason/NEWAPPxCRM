using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using new_app_dotnet.Models;

namespace new_app_dotnet.Services
{
    public class DepenseStatService
    {
        private readonly HttpClient _httpClient;

        public DepenseStatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DepenseStatDTO?> GetDepenseStatsAsync()
        {
            return await _httpClient.GetFromJsonAsync<DepenseStatDTO>("http://localhost:8080/api/depense-stat");
        }
    }
}
