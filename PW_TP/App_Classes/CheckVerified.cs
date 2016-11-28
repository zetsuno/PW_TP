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
           
            SqlCommand cmd = new SqlCommand("CheckVerifiedAccount", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);

            SqlCon.Open();
            bool value = (bool)cmd.ExecuteScalar();
            SqlCon.Close();

            if (value == true) return true;
          
            return false;
        }

        public static bool EnableAccount(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("ActivateUser", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlCon.Open();
            int value = cmd.ExecuteNonQuery();
            SqlCon.Close();

            if (value == 1) return true;

            return false;
        }

    }
}