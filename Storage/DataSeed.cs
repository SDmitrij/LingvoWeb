using LingvoWeb.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LingvoWeb.Storage
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Alex Egorov",
                        UserName = "shura",
                        Email = "shura@gmai.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Sidelev Dmitry",
                        UserName = "sdima",
                        Email = "sidelevdima@yandex.ru"
                    }
                };
                foreach (var user in users)
                    await userManager.CreateAsync(user, "qazwsX123@");
            }
        }
    }
}
