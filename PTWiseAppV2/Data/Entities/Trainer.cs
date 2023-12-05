using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PTWiseAppV2.Data.Entities
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Country { get; set; }
        public string? Postcode { get; set; }
        public string? GymName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? TelephoneNumber { get; set; }
        [JsonIgnore]
        public ICollection<Client> Clients { get; } = new List<Client>();
        public ICollection<Appointment> Appointments { get; } = new List<Appointment>();
    }
}
