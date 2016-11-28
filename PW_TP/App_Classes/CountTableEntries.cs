using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PW_TP.App_Classes
{
    public class CountTableEntries
    {
        public static int GetToVerifyCount()
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("CountEntriesToVerify", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@var", 0);

            SqlCon.Open();
            int value = (int)cmd.ExecuteScalar();
            SqlCon.Close();

            return value;
        }
        public static int AllAccsCount()
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("CountTotalTableEntries", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlCon.Open();
            int value = (int)cmd.ExecuteScalar();
            SqlCon.Close();

            return value;

        }
    }
}