using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PW_TP.App_Classes
{
    public static class DeleteUser
    {
        public static void RemoverUserFromDB(string id)
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
            catch
            {
                throw;
            }

        }
    }
}