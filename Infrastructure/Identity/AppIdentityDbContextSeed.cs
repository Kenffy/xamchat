using System.Linq;
using System.Threading.Tasks;
using Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    FullName = "Marius Kenfack",
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    PictureUrl = "default-user.png",
                    Address = new Address
                    {
                        FirstName = "Marius",
                        LastName = "Kenfack",
                        Street = "Musterstrasse 10",
                        City = "Musterstadt",
                        State = "Baden",
                        ZipCode = "90210"
                    }
                };

                await userManager.CreateAsync(user, "Admin420*");
            }
        }
    }
}