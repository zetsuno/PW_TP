﻿using Microsoft.AspNet.Identity;
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
    public class Commissions
    {
        public static bool CreateComission(string model, string type, string workshop, int year, string details, string userid)
        {

            string workshopid = Users.GetWorkshopId(workshop);
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
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to create a commission.");
                return false;
            }

            return true;

        }



        public static bool ActivateComission(int id)
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
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to activate a commission.");
                return false;
            }

            return true;

        }

        public static bool RejectComission(int id)
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
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to mark a commission as rejected.");
                return false;
            }

            return true;

        }

        public static bool ConcludeComission(int id)
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
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to mark a commission as concluded.");
                return false;
            }

            return true;
        }
        public static int FillRatings(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("GetRatings", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to get the workshop's ratings.");
                return -1;
            }


            return value;
        }

        public static bool SetRating(int id, int rating)
        {

            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("SetRating", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);
            cmd.Parameters.AddWithValue("@param2", rating);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to set a commission rating.");
                return false;
            }

            return true;
        }

        public static bool DeleteComission(string id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("DeleteComission", SqlCon);
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
                Console.WriteLine("An error occurred when trying to delete a commission.");
                return false;
            }

            return true;
        }

        public static bool UpdateComission(string id, string ClientId, string WorkshopId, string Concluded, DateTime CreationDate, string BicycleModel, string BicycleType,
                 string YearOfAquisition, string Details, string Accepted, string ComissionNo, string Rating)
        {
            int id_num, year_num, comission_num, rating_num;
            int.TryParse(id, out id_num); int.TryParse(YearOfAquisition, out year_num); int.TryParse(ComissionNo, out comission_num); int.TryParse(Rating, out rating_num);

            SqlConnection SqlCon = GetSqlCon.GetCon();
            SqlCommand cmd = new SqlCommand("UpdateComission", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id_num);
            cmd.Parameters.AddWithValue("@param2", ClientId);
            cmd.Parameters.AddWithValue("@param3", WorkshopId);
            cmd.Parameters.AddWithValue("@param4", Concluded);
            cmd.Parameters.AddWithValue("@param5", CreationDate);
            cmd.Parameters.AddWithValue("@param6", BicycleModel);
            cmd.Parameters.AddWithValue("@param7", BicycleType);
            cmd.Parameters.AddWithValue("@param8", year_num);
            cmd.Parameters.AddWithValue("@param9", Details);
            cmd.Parameters.AddWithValue("@param10", Accepted);
            cmd.Parameters.AddWithValue("@param11", comission_num);
            cmd.Parameters.AddWithValue("@param12", rating_num);


            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to update a commission.");
                return false;
            }

            return true;
        }

        public static double GetAvgRating(string id)
        {
            double rating;

            SqlConnection SqlCon = GetSqlCon.GetCon();
            SqlCommand cmd = new SqlCommand("CalcAvgRating", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);


            try
            {
                SqlCon.Open();
                rating = (double)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to get a workshop's rating.");
                return -1;
            }

            return rating;
        }

        public static int IsRejected(string id)
        {
            bool rejected;
            int value;

            SqlConnection SqlCon = GetSqlCon.GetCon();
            SqlCommand cmd = new SqlCommand("CheckIfComissionRejected", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                rejected = (bool)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to check if the commission was rejected.");
                return -1;
            }

            value = Convert.ToInt32(rejected);
            return value;
        }

        public static bool AddPrice(int commissionid, int price)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();

            SqlCommand cmd = new SqlCommand("AddPrice", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", commissionid);
            cmd.Parameters.AddWithValue("@param2", price);

            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to add a price to a commission.");
                return false;
            }

            return true;

        }

        public static int GetPrice(int id)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("GetComissionPrice", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", id);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to get the comission's price.");
                return -1;
            }

            return value;
        }

        public static bool CreateComissionGroup(string model, string type, string workshop, int year, string details, string userid, int groupno)
        {

            string workshopid = Users.GetWorkshopId(workshop);
            SqlConnection SqlCon = GetSqlCon.GetCon();
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand("NewComissionGroup", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@param1", model);
            cmd.Parameters.AddWithValue("@param2", type);
            cmd.Parameters.AddWithValue("@param3", workshop);
            cmd.Parameters.AddWithValue("@param4", year);
            cmd.Parameters.AddWithValue("@param5", details);
            cmd.Parameters.AddWithValue("@param6", workshopid);
            cmd.Parameters.AddWithValue("@param7", userid);
            cmd.Parameters.AddWithValue("@param8", now);
            cmd.Parameters.AddWithValue("@param9", groupno);


            try
            {
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to create a commission.");
                return false;
            }

            return true;

        }

        public static int CheckIfGroupExists(int groupno)
        {
            SqlConnection SqlCon = GetSqlCon.GetCon();
            int value;
            SqlCommand cmd = new SqlCommand("CheckGroupNoDuplicate", SqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", groupno);

            try
            {
                SqlCon.Open();
                value = (int)cmd.ExecuteScalar();
                SqlCon.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to get the comission's price.");
                return -1;
            }

            return value;
        }

    }
}
        