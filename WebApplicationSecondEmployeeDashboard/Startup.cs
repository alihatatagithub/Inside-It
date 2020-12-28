using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplicationSecondEmployeeDashboard.Models;

[assembly: OwinStartupAttribute(typeof(WebApplicationSecondEmployeeDashboard.Startup))]
namespace WebApplicationSecondEmployeeDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var adminuser = new Admin();
            var adminrole = new ApplicationRole();
            if (!roleManager.RoleExists("Admin"))
            {
                adminrole.Name = "Admin";
                roleManager.Create(adminrole);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                var Check = userManager.Create(user, "ASDzxc123$@");
                if (Check.Succeeded)
                {
                    adminuser.AdminId = user.Id;
                    adminuser.UserID = user.Id;
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

        }
    }
}
