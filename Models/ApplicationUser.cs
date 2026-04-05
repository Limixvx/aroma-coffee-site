using Microsoft.AspNetCore.Identity;

namespace AromaCoffee.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}