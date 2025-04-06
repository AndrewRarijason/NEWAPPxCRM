using System.Text.Json.Serialization;

namespace new_app_dotnet.Models{
public class StatistiqueBudgetDto
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("customerName")]
    public string? CustomerName { get; set; }

    [JsonPropertyName("totalBudget")]
    public double TotalBudget { get; set; }

    [JsonPropertyName("totalDepense")]
    public double TotalDepense { get; set; }

    [JsonPropertyName("budgetRestant")]
    public double BudgetRestant { get; set; }

    [JsonPropertyName("totalDepenseTicket")]
    public double TotalDepenseTicket { get; set; }

    [JsonPropertyName("totalDepenseLead")]
    public double TotalDepenseLead { get; set; }
}

/// <summary>
/// DTO pour les statistiques de dépenses globales.
/// </summary>

public class DepenseStatDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("totalLeadDepense")]
    public double TotalLeadDepense { get; set; }

    [JsonPropertyName("totalTicketDepense")]
    public double TotalTicketDepense { get; set; }

    [JsonPropertyName("totalDepense")]
    public double TotalDepense { get; set; }

    [JsonPropertyName("pourcentageLead")]
    public double PourcentageLead { get; set; }

    [JsonPropertyName("pourcentageTicket")]
    public double PourcentageTicket { get; set; }
}

}