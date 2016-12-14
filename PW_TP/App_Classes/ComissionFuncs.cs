using Microsoft.AspNet.Identity;
using PW_TP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Security.Principal;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PW_TP.App_Classes
{
    public class ComissionFuncs
    {
        public static void CreateComission(string model, string type, string workshop, int year, string details, string userid)
        {

            string workshopid = GetWorkshopID(workshop);
            SqlConnection SqlCon = GetSqlCon.GetCon();
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand("NewComission", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", model);
            cmd.Parameters.AddWithValue("@param2", type);
            cmd.Parameters.AddWithValue("@param3", workshop);
            cmd.Parameters.AddWithValue("@param4", year);
            cmd.Parameters.AddWithValue("@param5", details);
            cmd.Parameters.AddWithValue("@param6", workshopid);
            cmd.Parameters.AddWithValue("@param7", userid);
            cmd.Parameters.AddWithValue("@param8", now);


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

        protected static string GetWorkshopID(string workshopname)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            string workshopid;
            SqlCommand cmd = new SqlCommand("GetWorkshopID", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", workshopname);

            try
            {
                SqlCon.Open();
                workshopid = (string)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }

            return workshopid;
        }

        public static int CountActiveComissions(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("CountActiveComissions", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }

            return value;
        }

        public static int CountPendingComissions(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("CountPendingComissions", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }

            return value;
        }

        public static int CountActiveComissionsWorkshop(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("CountActiveComissionsWorkshop", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }

            return value;

        }

        public static int CountPendingComissionsWorkshop(string id)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("CountPendingComissionsWorkshop", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch
            {
                throw;
            }

            return value;

        }

        public static void ActivateComission(int id)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("ActivateComission", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);


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

        public static void RejectComission(int id)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("RejectComission", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);

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

        public static void ConcludeComission(int id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("ConcludeComission", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);

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