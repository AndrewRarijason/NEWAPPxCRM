using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using new_app_dotnet.Models;

namespace new_app_dotnet.Service
{
    public class LoginService
    {
        private readonly HttpClient _client;

        public LoginService()
        {
            _client = new HttpClient();
        }

        public async Task<UserDTO?> LoginAsync(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            try
            {
                var response = await _client.PostAsync("http://localhost:8080/api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    var user = JsonSerializer.Deserialize<UserDTO>(json);

                    return user;
                }
                else
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorJson);

                    Console.WriteLine($"Erreur: {errorResponse?.Error ?? "Échec de l'authentification"}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }
    }

    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
