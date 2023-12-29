using Microsoft.AspNetCore.Identity;

namespace ArcticBook.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public int Name { get; set; }
    }
}
