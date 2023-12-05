using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace PTWiseAppV2.Data.Entities
{
    public class Client 
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
        [EmailAddress]
        public string? Email { get; set; }
        public string? TelephoneNumber { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public int TrainerId { get; set; }

        public ICollection<Appointment> Appointments { get; } = new List<Appointment>();


    }
}
