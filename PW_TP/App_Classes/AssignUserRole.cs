using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using PW_TP.Models;
using System.Web.Security;

namespace PW_TP.App_Classes
{
    public class Security
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void AddUserToRole(string email, string roleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                var user = UserManager.FindByEmail(email);
                UserManager.AddToRole(user.Id, roleName);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}