using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using new_app_dotnet.Models;

namespace new_app_dotnet.Services
{
    public class SeuilService
    {
        private readonly HttpClient _httpClient;

        public SeuilService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all tickets from Spring Boot API

        public async Task<bool> UpdateSeuilAsync(decimal nouvelleValeur)
        {
            var url = $"http://localhost:8080/api/seuil/update/{nouvelleValeur}";
            Console.WriteLine("URL");  
            Console.WriteLine(url);  
            var response = await _httpClient.GetAsync(url); 
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


        public async Task<double> getSeuilAsync()
        {
            var url = "http://localhost:8080/api/seuil/voirvaleur";
            Console.WriteLine("URL: " + url);

            try
            {
                var response = await _httpClient.GetAsync(url);
                
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Erreur HTTP: {response.StatusCode}");
                    return 0; // Retourne 0 en cas d'erreur HTTP
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: " + jsonString); // Débogage

                // Vérifier si la réponse commence bien par '{' pour éviter une erreur JSON
                if (!jsonString.TrimStart().StartsWith("{"))
                {
                    Console.WriteLine("Réponse invalide (non JSON)");
                    return 0;
                }

                using (var jsonDoc = JsonDocument.Parse(jsonString))
                {
                    var taux = jsonDoc.RootElement.GetProperty("taux").GetDecimal();
                    return (double)taux;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur: " + ex.Message);
                return 0; // Retourne 0 en cas d'exception
            }
        }

    }
}
