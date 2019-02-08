using AppEntity.Models;
using AppEntity.Models.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AppEntity
{
    public class DBInitializer
    {
        public static async Task InitializeAsync(IApplicationBuilder app,
            EntityContext context,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            context.Database.EnsureCreated();

            //app.ApplicationServices
            //    .GetRequiredService<BrainStormDbContext>().Database.Migrate();

            string roleADMIN = UserStatus.ADMIN;
            string descADMIN = "This is adminstrator role";

            string roleTEACHER = UserStatus.TEACHER;
            string descTEACHER = "This is TEACHER role";

            string roleUSER = UserStatus.USER;
            string descUSER = "This is USER role";

            if (await roleManager.FindByNameAsync(roleADMIN) == null)
            {
                await roleManager.CreateAsync(new AppRole(roleADMIN, descADMIN, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(roleTEACHER) == null)
            {
                await roleManager.CreateAsync(new AppRole(roleTEACHER, descTEACHER, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(roleUSER) == null)
            {
                await roleManager.CreateAsync(new AppRole(roleUSER, descUSER, DateTime.Now));
            }

            if (await userManager.FindByEmailAsync("Kamran@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "Kamran@gmail.com",
                    Email = "Kamran@gmail.com",
                    Image = "images/user/default_user.png"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, "Kamran123456");
                    await userManager.AddToRoleAsync(user, UserStatus.ADMIN);
                }
            }
        }
    }
}
