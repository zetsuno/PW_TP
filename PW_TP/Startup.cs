using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PW_TP.Models;

[assembly: OwinStartupAttribute(typeof(PW_TP.Startup))]
namespace PW_TP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // Quando for preciso criar um admin
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
   
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.UserName = "admin@pweb.com";
                user.Email = "admin@pweb.com";

                string userPWD = "PWEB7!";
            
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "administrator");

                }
            

            }
        }
    }

