using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PW_TP.App_Classes
{
    public static class Users
    {
        
        public static bool RegisterUserTypeClient(string username, string email, string telephone) {

            
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
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to add a user to the database.");
                return false;
            }

            return true;
        }

        public static bool RegisterUserTypeWorkshop(string email, string workshopname, string workshopphone, string workshopowner, string workshopownernif, string workshopaddress, string regiao)
        {
            
            SqlConnection SqlCon = GetSqlCon.GetCon();
           
            SqlCommand cmd = new SqlCommand("RegisterUserTypeWorkshop", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@param1", workshopname);
            cmd.Parameters.AddWithValue("@param2", workshopphone);
            cmd.Parameters.AddWithValue("@param3", workshopowner);
            cmd.Parameters.AddWithValue("@param4", workshopownernif);
            cmd.Parameters.AddWithValue("@param5", 0);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@param6", workshopaddress);
            cmd.Parameters.AddWithValue("@param7", regiao);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to add a user to the database.");
                return false;
            }

            return true;
        }

        public static bool UpdateUserInfo(string id, string email, string emailconfirmed, string passwordhash, string securitystamp, string phonenumber,
                 string phonenumberconfirmed, string twofactorenabled, DateTime lockoutenddateutc, string lockoutenabled, string accessfailedcount, string username, string workshopname, string workshopphone,
                 string workshopowner, string workshopownernif, string workshopaddress, string workshopregion, string isenabled, string displayname)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();
            SqlCommand cmd = new SqlCommand("UpdateUser", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);
            cmd.Parameters.AddWithValue("@param2", email);
            cmd.Parameters.AddWithValue("@param3", emailconfirmed);
            cmd.Parameters.AddWithValue("@param4", passwordhash);
            cmd.Parameters.AddWithValue("@param5", securitystamp);
            cmd.Parameters.AddWithValue("@param6", phonenumber);
            cmd.Parameters.AddWithValue("@param7", phonenumberconfirmed);
            cmd.Parameters.AddWithValue("@param8", twofactorenabled);
            cmd.Parameters.AddWithValue("@param9", lockoutenddateutc);
            cmd.Parameters.AddWithValue("@param10", lockoutenabled);
            cmd.Parameters.AddWithValue("@param11", accessfailedcount);
            cmd.Parameters.AddWithValue("@param12", username);
            cmd.Parameters.AddWithValue("@param13", workshopname);
            cmd.Parameters.AddWithValue("@param14", workshopphone);
            cmd.Parameters.AddWithValue("@param15", workshopowner);
            cmd.Parameters.AddWithValue("@param16", workshopownernif);
            cmd.Parameters.AddWithValue("@param17", isenabled);
            cmd.Parameters.AddWithValue("@param18", displayname);
            cmd.Parameters.AddWithValue("@param19", workshopaddress);
            cmd.Parameters.AddWithValue("@param20", workshopregion);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to update a user's info.");
                return false;
            }

            return true;
        }

        public static bool RemoverUserFromDB(string id)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("DeleteUser", SqlCon);
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
                Console.WriteLine("An error occurred when trying to remove a user from the database.");
                return false;
            }

            return true;

        }
        public static string GetWorkshopId(string nome)
        {
            string id;

            SqlConnection SqlCon = GetSqlCon.GetCon();
            SqlCommand cmd = new SqlCommand("GetWorkshopID", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", nome);


            try
            {
                SqlCon.Open();
                id = (string)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to get a workshop's id.");
                return "";
            }

            return id;   
        }
    }
}