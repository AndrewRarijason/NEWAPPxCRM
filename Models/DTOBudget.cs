using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace new_app_dotnet.Models{
public class BudgetDTO
{
    [Required]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required]
    [JsonPropertyName("valeur")]
    public decimal Valeur { get; set; }

    [Required]
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [Required]
    [JsonPropertyName("customer")]
    public CustomerDTO? Customer { get; set; }
}

public class CustomerDTO
{
    [Required]
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public string? CustomerName { get; set; }

    [Required]
    [JsonPropertyName("email")]
    public string? CustomerMail { get; set; }
}
}