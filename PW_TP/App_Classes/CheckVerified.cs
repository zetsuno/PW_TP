using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PW_TP.App_Classes
{
    public class CheckVerified
    {
        public static bool CheckAccount(string email)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            bool value;
            SqlCommand cmd = new SqlCommand("CheckVerifiedAccount", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                SqlCon.Open();
                value = (bool)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }

            if (value == true) return true;
          
            return false;
        }

        public static void EnableAccount(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
           
            SqlCommand cmd = new SqlCommand("ActivateUser", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

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