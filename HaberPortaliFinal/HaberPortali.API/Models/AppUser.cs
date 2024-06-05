using Microsoft.AspNetCore.Identity;

namespace HaberPortali.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
