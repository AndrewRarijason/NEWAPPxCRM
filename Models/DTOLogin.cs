using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace new_app_dotnet.Models
{
    public class UserDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("hireDate")]
        public DateTime? HireDate { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("oauthUser")]
        public string? OauthUser { get; set; }

        [JsonPropertyName("roles")]
        public List<RoleDTO>? Roles { get; set; }

        [JsonPropertyName("userProfile")]
        public UserProfileDTO? UserProfile { get; set; }

        [JsonPropertyName("passwordSet")]
        public bool PasswordSet { get; set; }

        [JsonPropertyName("inactiveUser")]
        public bool InactiveUser { get; set; }
    }

    public class RoleDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class UserProfileDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("department")]
        public string? Department { get; set; }

        [JsonPropertyName("salary")]
        public decimal? Salary { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("facebook")]
        public string? Facebook { get; set; }

        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }

        [JsonPropertyName("youtube")]
        public string? Youtube { get; set; }

        [JsonPropertyName("oathUserImageLink")]
        public string? OathUserImageLink { get; set; }

        [JsonPropertyName("userImage")]
        public string? UserImage { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }
    }
}
