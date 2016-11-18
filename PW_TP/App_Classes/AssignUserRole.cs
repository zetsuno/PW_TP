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

        public void AddUserToRole(string email, string roleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                var user = UserManager.FindByEmail(email);
                UserManager.AddToRole(user.Id, roleName);
                AddUserAspNetID(user.Id, email);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddUserAspNetID(string id, string email)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCon.Open();
            SqlCommand cmd = SqlCon.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@param1", id);
            cmd.Parameters.AddWithValue("@email", email);
          

            cmd.CommandText = "UPDATE Users SET AspNetUserID=@param1 WHERE Email=@email";
            cmd.ExecuteNonQuery();
            SqlCon.Close();

        }
    }
}