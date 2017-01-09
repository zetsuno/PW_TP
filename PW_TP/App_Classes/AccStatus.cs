using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PW_TP.App_Classes
{
    public class AccStatus
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
                Console.WriteLine("An error occurred when trying verify the status of a user account.");
                return false;
            }

            if (value == true) return true;
          
            return false;
        }

        public static bool EnableAccount(string id)
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
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to enable a user account.");
                return false;
            }

            return true;

        }

        public static bool LockAccount(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("LockAccount", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to lock a user account.");
                return false;
            }

            return true;

        }

    }
}