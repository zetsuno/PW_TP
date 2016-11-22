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
            int value = (int)cmd.ExecuteScalar();
            SqlCon.Close();

            if (value == 1) return true;

            return false;
        }
    }
}