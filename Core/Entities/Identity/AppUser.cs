using Microsoft.AspNetCore.Identity;

namespace Core.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string PictureUrl { get; set; }

        public Address Address { get; set; }
    }
}