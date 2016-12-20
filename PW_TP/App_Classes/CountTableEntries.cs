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
            int value;
            SqlCommand cmd = new SqlCommand("CountEntriesToVerify", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@var", 0);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to count the users not yet verified.");
                return -1;
            }

            return value;
        }
        public static int AllAccsCount()
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("CountTotalTableEntries", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to count all the accounts.");
                return -1;
            }

            return value;

        }

        public static int CountComissions()
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("Count Comissions", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to count how many commissions existed.");
                return -1;
            }

            return value;
        }
    }
}