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
using System.Data.SqlClient;

namespace PW_TP.App_Classes
{
    public class Security
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public bool AddUserToRole(string email, string roleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                var user = UserManager.FindByEmail(email);
                UserManager.AddToRole(user.Id, roleName);
                context.SaveChanges();
                
            }
            catch(Exception)
            {
                Console.WriteLine("An error occurred when trying to add a user to a role.");
                return false;
            }

            return true;
        }

        public bool AddUserToRoleByID(string id, string roleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                var user = UserManager.FindById(id);
                UserManager.AddToRole(user.Id, roleName);
                context.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to add a user to a role.");
                return false;
            }

            return true;
        }
    }
}