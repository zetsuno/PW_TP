﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PW_TP.App_Classes;
using PW_TP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

namespace PW_TP.Account
{
    public partial class Comissions : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || User.IsInRole("workshop"))
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }

            PopulateGridViews();
            GetRatings();
            GetPrices();
            UpdateBadges();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }               
        }
        protected void GetPrices()
        {
            foreach (GridViewRow row in GridViewComissionsPending.Rows)
            {
                int id, price;
                int.TryParse(row.Cells[1].Text, out id);
                price = Commissions.GetPrice(id);
                Label LabelPrice = row.FindControl("LabelPrice") as Label;
                if (price != 0)
                {
                    LabelPrice.Text = price.ToString();
                }
                else
                {
                    Button BtnAcceptComission = row.FindControl("BtnAcceptComission") as Button;
                    Button BtnRejectComission = row.FindControl("BtnRejectComission") as Button;
                    BtnAcceptComission.Visible = false;
                    BtnRejectComission.Visible = false;
                    LabelPrice.Text = "N/A";
                    
                }

            }

        }
        protected void GetRatings()
        {
            int value, rejected;
           

            foreach (GridViewRow row in HistoryOfComissions.Rows)
            {
                value = Commissions.FillRatings(row.Cells[0].Text);
                if (value == -1) { Response.Redirect("~/Error.aspx"); }
                rejected = Commissions.IsRejected(row.Cells[0].Text);
                if (rejected == -1) { Response.Redirect("~/Error.aspx"); }

                if (value != -2)
                {
                    ((HtmlInputGenericControl)row.FindControl("starating")).Value = value.ToString();
                    ((HtmlInputGenericControl)row.FindControl("starating")).Attributes.Add("readonly", "true");
                    ((Button)row.FindControl("BtnSubmitRating")).Visible = false;
                    BadgeCountActiveComissions.Text = rejected.ToString();
                   
                }
                if (rejected == 0)
                {
                    ((HtmlInputGenericControl)row.FindControl("starating")).Visible = false;
                    ((Label)row.FindControl("labelrejected")).Visible = true;
                    ((Button)row.FindControl("BtnSubmitRating")).Visible = false;
                }

            }
        }

        protected void BtnCreateComission_Click(object sender, EventArgs e)
        {     
            int Ano;
            int.TryParse(TbAno.Text, out Ano);
            
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();

            BtnCreateComission.Enabled = false; //Prevenir Flood

            if(Commissions.CreateComission(TbModelo.Text, DdlTipo.SelectedValue, DdlOficinas.SelectedValue, Ano, TbDetails.Text, user) == false){
                Response.Redirect("~/Error.aspx");
            }
            Response.Redirect("ComissionCreated.aspx");     
        }

        protected void UpdateBadges()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();

            int value = CountTableEntries.CountActiveComissions(user);
            if(value == -1) { Response.Redirect("~/Error.aspx"); }    
            BadgeCountActiveComissions.Text  = value.ToString();
            int value2 = CountTableEntries.CountPendingComissions(user);
            if(value == -1) { Response.Redirect("~/Error.aspx"); }
            BadgeCountPendingComissions.Text = value2.ToString();
            BadgeComissions.Text = (value2 + value).ToString();
        }

        protected void PopulateGridViews()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //Active
            string storedprocedure = "GetActiveComissions";
            SqlConnection cn = GetSqlCon.GetCon();
            if(cn == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(storedprocedure, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridViewActiveComissions.DataSource = dt;
            GridViewActiveComissions.DataBind();
            cn.Close();

            //Pending
            string storedprocedure2 = "GetPendingComissions";
            SqlConnection cn2 = GetSqlCon.GetCon();
            if(cn2 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt2 = new DataTable();
            SqlCommand cmd2 = new SqlCommand(storedprocedure2, cn2);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            GridViewComissionsPending.DataSource = dt2;
            GridViewComissionsPending.DataBind();
            cn2.Close();

            //History
            string storedprocedure3 = "HistoryOfcomissions";
            SqlConnection cn3 = GetSqlCon.GetCon();
            if (cn3 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt3 = new DataTable();
            SqlCommand cmd3 = new SqlCommand(storedprocedure3, cn3);
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dt3);
            HistoryOfComissions.DataSource = dt3;
            HistoryOfComissions.DataBind();
            cn3.Close();
        }

        protected void Comissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SubmitRating")
            {
                int index = Convert.ToInt32(e.CommandArgument), id, rating;
                GridViewRow row = HistoryOfComissions.Rows[index];
                int.TryParse(row.Cells[0].Text, out id);
                int.TryParse(((HtmlInputGenericControl)row.FindControl("starating")).Value, out rating);
                if (Commissions.SetRating(id, rating) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("~/Account/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }

            if (e.CommandName == "AcceptComission")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = GridViewComissionsPending.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                if(Commissions.ActivateComission(id) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("~/Account/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }

            if (e.CommandName == "RejectComission")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = GridViewComissionsPending.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                if(Commissions.RejectComission(id) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("~/Account/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }

            PopulateGridViews();
            GetRatings();
            GetPrices();
            UpdateBadges();
        }

    }
}