using Apotek.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apotek.Startup))]
namespace Apotek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();

        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "andrea.konig@nackademin.se",
                    Email = "andrea.konig@nackademin.se"
                };
                var userPassword = "Apotekpass123";
                var checkUser = userManager.Create(user, userPassword);

                if (checkUser.Succeeded)
                    userManager.AddToRole(user.Id, "Admin");

            }

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "Joy.Relom@yh.nackademin.se",
                    Email = "Joy.Relom@yh.nackademin.se"
                };
                var userPassword = "Apotekpass123";
                var checkUser = userManager.Create(user, userPassword);

                if (checkUser.Succeeded)
                    userManager.AddToRole(user.Id, "Admin");

            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole { Name = "ProductManager" };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "Joy_Rlm@gmail.com",
                    Email = "Joy_Rlm@gmail.com"
                };
                var userPassword = "Apotekpass123";
                var checkUser = userManager.Create(user, userPassword);

                if (checkUser.Succeeded)
                    userManager.AddToRole(user.Id, "ProductManager");

            }
        }

    }

    
}
