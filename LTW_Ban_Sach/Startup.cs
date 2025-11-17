using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(LTW_Ban_Sach.Startup))]

namespace LTW_Ban_Sach
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Login")
            });
            this.CreateRolesAndUser();
        }
        public void CreateRolesAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new Identity.AppDbContext()));
            var appDBContext = new Identity.AppDbContext();
            var appUserStore = new UserStore<Identity.AppUser>(appDBContext);
            var userManager = new UserManager<Identity.AppUser>(appUserStore);
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (userManager.FindByName("admin") == null)
            {
                var user = new Identity.AppUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPWD = "Admin@123";
                var chkUser = userManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
