
using System.Net.Http.Headers;
using System.Text;

namespace new_app_dotnet.Services
{
    public class ImportCsvService
    {
        private readonly HttpClient _httpClient;

        public ImportCsvService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ImportComplexCsvAsync(string filePath)
        {
            try
            {
                string csvContent = await File.ReadAllTextAsync(filePath);
                Console.WriteLine("Contenu du fichier CSV:");
                Console.WriteLine(csvContent);

                // Nettoyer les espaces superflus
                csvContent = csvContent.Replace(", ", ",");

                using (var formData = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes(csvContent));
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
                    formData.Add(fileContent, "file", "import.csv");

                    var response = await _httpClient.PostAsync("http://localhost:8080/api/import/dotnet", formData);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"Statut: {response.StatusCode}");
                    Console.WriteLine("Réponse complète:");
                    Console.WriteLine(responseContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Erreur détaillée: {responseContent}");
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception complète:");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}