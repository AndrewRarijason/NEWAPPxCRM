using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace new_app_dotnet.Models
{
    public class TicketDepenseDTO
    {
        [JsonPropertyName("ticketId")]
        [Required]
        public int TicketId { get; set; }

        [JsonPropertyName("subject")]
        [Required]
        [StringLength(255)]
        public string? Subject { get; set; }

        [JsonPropertyName("description")]
        [Required]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        [Required]
        public string? Status { get; set; }

        [JsonPropertyName("priority")]
        [Required]
        public string? Priority { get; set; }

        [JsonPropertyName("customerId")]
        [Required]
        public int CustomerId { get; set; }

        [JsonPropertyName("customerName")]
        [Required]
        public string? CustomerName { get; set; }

        [JsonPropertyName("managerId")]
        public int ManagerId { get; set; }

        [JsonPropertyName("managerName")]
        public string? ManagerName { get; set; }

        [JsonPropertyName("employeeId")]
        [Required]
        public int EmployeeId { get; set; }

        [JsonPropertyName("employeeName")]
        [Required]
        public string? EmployeeName { get; set; }

        [JsonPropertyName("createdAt")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("depenseId")]
        [Required]
        public int DepenseId { get; set; }

        [JsonPropertyName("valeurDepense")]
        [Required]
        [Range(0, double.MaxValue)]
        public double ValeurDepense { get; set; }

        [JsonPropertyName("dateDepense")]
        [Required]
        public DateTime DateDepense { get; set; }

        [JsonPropertyName("etat")]
        [Required]
        public string? Etat { get; set; }

        [JsonPropertyName("leadId")]
        public int? LeadId { get; set; }
    }
}
namespace new_app_dotnet.Models
{
    public class LeadDepenseDTO
    {
        [JsonPropertyName("leadId")]
        [Required]
        public int LeadId { get; set; }

        [JsonPropertyName("customerId")]
        [Required]
        public int CustomerId { get; set; }

        [JsonPropertyName("customerName")]
        [Required]
        public string? CustomerName { get; set; }

        [JsonPropertyName("userId")]
        [Required]
        public int UserId { get; set; }

        [JsonPropertyName("userName")]
        [Required]
        public string? UserName { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string? Name { get; set; }

        [JsonPropertyName("phone")]
        [Required]
        [Phone]
        public string? Phone { get; set; }

        [JsonPropertyName("employeeId")]
        [Required]
        public int EmployeeId { get; set; }

        [JsonPropertyName("employeeName")]
        [Required]
        public string? EmployeeName { get; set; }

        [JsonPropertyName("status")]
        [Required]
        public string? Status { get; set; }

        [JsonPropertyName("meetingId")]
        public int? MeetingId { get; set; }

        [JsonPropertyName("googleDrive")]
        public string? GoogleDrive { get; set; }

        [JsonPropertyName("googleDriveFolderId")]
        public string? GoogleDriveFolderId { get; set; }

        [JsonPropertyName("leadCreatedAt")]
        [Required]
        public DateTime LeadCreatedAt { get; set; }

        [JsonPropertyName("depenseId")]
        [Required]
        public int DepenseId { get; set; }

        [JsonPropertyName("valeurDepense")]
        [Required]
        [Range(0, double.MaxValue)]
        public double ValeurDepense { get; set; }

        [JsonPropertyName("dateDepense")]
        [Required]
        public DateTime DateDepense { get; set; }

        [JsonPropertyName("etat")]
        [Required]
        public string? Etat { get; set; }

        [JsonPropertyName("ticketId")]
        public int? TicketId { get; set; }
    }
}