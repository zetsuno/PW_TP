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
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("RegisterUserTypeClient", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", ClientPrivilege);
            cmd.Parameters.AddWithValue("@param2", ClientVerified);
            cmd.Parameters.AddWithValue("@param3", username);
            cmd.Parameters.AddWithValue("@param4", password);
            cmd.Parameters.AddWithValue("@param5", email);
            cmd.Parameters.AddWithValue("@param6", usernif);

            SqlCon.Open();
            cmd.ExecuteNonQuery();
            SqlCon.Close();

        }

        public static void RegisterUserTypeWorkshop(string email, string password, string workshopname, string workshopnif, string workshopowner, string workshopownernif)
        {
            int ClientPrivilege = 2, ClientVerified = 0;
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("RegisterUserTypeWorkshop", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", ClientPrivilege);
            cmd.Parameters.AddWithValue("@param2", ClientVerified);
            cmd.Parameters.AddWithValue("@param3", password);
            cmd.Parameters.AddWithValue("@param4", email);
            cmd.Parameters.AddWithValue("@param5", workshopname);
            cmd.Parameters.AddWithValue("@param6", workshopnif);
            cmd.Parameters.AddWithValue("@param7", workshopowner);
            cmd.Parameters.AddWithValue("@param8", workshopownernif);
            
            SqlCon.Open();
            cmd.ExecuteNonQuery();
            SqlCon.Close();
        }
    }
}