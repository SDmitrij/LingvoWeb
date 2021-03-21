using Microsoft.AspNetCore.Identity;

namespace LingvoWeb.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
