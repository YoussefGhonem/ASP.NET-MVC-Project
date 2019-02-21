using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Jop_Offers_Website.Models;

[assembly: OwinStartupAttribute(typeof(Jop_Offers_Website.Startup))]
namespace Jop_Offers_Website
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRole();
        }
        public void CreateRole()
        {
            
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!rolemanger.RoleExists("Admins"))
            {
                role.Name = "Admins";
                rolemanger.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                var check=usermanger.Create(user, "03@y@Y");
                if (check.Succeeded)
                {
                    usermanger.AddToRole(user.Id, "Admins");
                }
            }
        }
    }
}
