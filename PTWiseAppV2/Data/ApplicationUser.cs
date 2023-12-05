using Microsoft.AspNetCore.Identity;
using PTWiseAppV2.Data.Entities;

namespace PTWiseAppV2.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Surname{ get; set; }
        public DateTime? DOB { get; set; }
        public DateTime LastLoginDateTime { get; set; }
    }

}
