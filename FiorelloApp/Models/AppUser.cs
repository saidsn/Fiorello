using Microsoft.AspNetCore.Identity;

namespace FiorelloApp.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
