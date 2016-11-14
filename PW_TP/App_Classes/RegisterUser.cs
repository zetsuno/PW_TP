using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PW_TP.App_Classes
{
    public static class RegisterUser
    {
        
        public static void RegisterUserTypeClient(string username, string password, string email, string usernif) {

            int ClientPrivilege = 3, ClientVerified = 1;
            string StrCon = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection SqlCon = new SqlConnection(StrCon);

            SqlCon.Open();
            SqlCommand cmd = SqlCon.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@param1", ClientPrivilege);
            cmd.Parameters.AddWithValue("@param2", ClientVerified);
            cmd.Parameters.AddWithValue("@param3", username);
            cmd.Parameters.AddWithValue("@param4", password);
            cmd.Parameters.AddWithValue("@param5", email);
            cmd.Parameters.AddWithValue("@param6", usernif);

            cmd.CommandText = "INSERT INTO Users(Privilege, Verified, UserName, Password, Email, UserNIF) VALUES(@param1, @param2, @param3, @param4, @param5, @param6)";
            cmd.ExecuteNonQuery();
            SqlCon.Close();

        }

        public static void RegisterUserTypeWorkshop(string email, string password, string workshopname, string workshopnif, string workshopowner, string workshopownernif)
        {
            int ClientPrivilege = 2, ClientVerified = 0;
            string StrCon = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection SqlCon = new SqlConnection(StrCon);

            SqlCon.Open();
            SqlCommand cmd = SqlCon.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@param1", ClientPrivilege);
            cmd.Parameters.AddWithValue("@param2", ClientVerified);
            cmd.Parameters.AddWithValue("@param3", password);
            cmd.Parameters.AddWithValue("@param4", email);
            cmd.Parameters.AddWithValue("@param5", workshopname);
            cmd.Parameters.AddWithValue("@param6", workshopnif);
            cmd.Parameters.AddWithValue("@param7", workshopowner);
            cmd.Parameters.AddWithValue("@param8", workshopownernif);

            cmd.CommandText = "INSERT INTO Users(Privilege, Verified, Password, Email, WorkshopName, WorkshopNIF, WorkshopOwner, WorkshopOwnerNIF) VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";
            cmd.ExecuteNonQuery();
            SqlCon.Close();
        }
    }
}