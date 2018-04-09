using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProveVarie.Models;

[assembly: OwinStartupAttribute(typeof(ProveVarie.Startup))]
namespace ProveVarie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        // In this method we will create default "Segreteria" and "Cassa" roles + "Admin" role with super-user
        private void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            // Create first "Admin" role + Default Admin user
            if (!roleManager.RoleExists("Admin"))
            {
                // Creating "Admin" role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Creating Admin super-user (all privileges)
                var user = new ApplicationUser();

                user.UserName = "admin";
                user.Email = "admin@contoso.com";
                string userPWD = "Ciao12345!";

                var chkUser = UserManager.Create(user, userPWD);

                // Add default user to "Admin" role
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // Creating "Segreteria" role
            if (!roleManager.RoleExists("Segreteria"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Segreteria";
                roleManager.Create(role);
            }

            // Creating "Cassa" role
            if (!roleManager.RoleExists("Cassa"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Cassa";
                roleManager.Create(role);
            }
        }
    }
}
