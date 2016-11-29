using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PW_TP.App_Classes
{
    public static class RegisterUser
    {
        
        public static void RegisterUserTypeClient(string username, string email, string telephone) {

            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("RegisterUserTypeClient", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", username);
            cmd.Parameters.AddWithValue("@param2", telephone);
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void RegisterUserTypeWorkshop(string email, string workshopname, string workshopnif, string workshopowner, string workshopownernif)
        {
            
            SqlConnection SqlCon = GetSqlCon.GetCon();
           
            SqlCommand cmd = new SqlCommand("RegisterUserTypeWorkshop", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@param1", workshopname);
            cmd.Parameters.AddWithValue("@param2", workshopnif);
            cmd.Parameters.AddWithValue("@param3", workshopowner);
            cmd.Parameters.AddWithValue("@param4", workshopownernif);
            cmd.Parameters.AddWithValue("@param5", 0);
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}