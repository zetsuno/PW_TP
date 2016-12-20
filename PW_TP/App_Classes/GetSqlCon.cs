using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PW_TP.App_Classes
{
    public class GetSqlCon
    {
        public static SqlConnection GetCon()
        {
            try
            {
                string StrCon = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection SqlCon = new SqlConnection(StrCon);
                return SqlCon;
            }
            catch(Exception)
            {
                return null;
            }
           
        }
    }
}