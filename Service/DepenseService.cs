using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using new_app_dotnet.Models;

namespace new_app_dotnet.Services
{
    public class TicketLeadService
    {
        private readonly HttpClient _httpClient;

        public TicketLeadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all tickets from Spring Boot API
        public async Task<List<TicketDepenseDTO>> GetTicketsAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:8080/api/tickets-depenses");
            return JsonSerializer.Deserialize<List<TicketDepenseDTO>>(response);
        }

        // Get all leads from Spring Boot API
        public async Task<List<LeadDepenseDTO>> GetLeadsAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:8080/api/leads-depenses");
            return JsonSerializer.Deserialize<List<LeadDepenseDTO>>(response);
        }

        // Get tickets by customerId from Spring Boot API
        public async Task<List<TicketDepenseDTO>> GetTicketsByCustomerIdAsync(long customerId)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:8080/api/tickets-depenses/customer/{customerId}");
            return JsonSerializer.Deserialize<List<TicketDepenseDTO>>(response);
        }

        // Get leads by customerId from Spring Boot API
        public async Task<List<LeadDepenseDTO>> GetLeadsByCustomerIdAsync(long customerId)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:8080/api/leads-depenses/customer/{customerId}");
            return JsonSerializer.Deserialize<List<LeadDepenseDTO>>(response);
        }

        public async Task<bool> UpdateDepenseAsync(int id, decimal nouvelleValeur)
        {
            var url = $"http://localhost:8080/api/depenses/update/{id}/{nouvelleValeur}";
            Console.WriteLine("URL");  
            Console.WriteLine(url);  
            var response = await _httpClient.GetAsync(url); 
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> DeleteDepenseAsync(int id)
        {
            var url = $"http://localhost:8080/api/depenses/delete/{id}";
            Console.WriteLine("URL");  
            Console.WriteLine(url);  
            var response = await _httpClient.GetAsync(url); 
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
