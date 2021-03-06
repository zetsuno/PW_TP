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

namespace PW_TP.DualRole
{
    public partial class Comissions : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!(User.IsInRole("client") && User.IsInRole("workshop")))
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
            else if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
            else {

                PopulateGridViews();
                GetPrices();
                UpdateBadges();
                GetRatings();
                
            }          
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GridViewActiveComissions.DataBind();
                GridViewComissionsPending.DataBind();
                HistoryOfComissions.DataBind();
                ActiveComissions.DataBind();
                PendingComissions.DataBind();
                HistoryOfComissions.DataBind();
                Clientes.DataBind();
                GetRatings();
                GetPrices();
                UpdateBadges();
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

            foreach (GridViewRow row in HistoryOfComissionsWorkshop.Rows)
            {

                value = Commissions.FillRatings(row.Cells[0].Text);
                if (value != -2)
                {
                    ((HtmlInputGenericControl)row.FindControl("starating")).Value = value.ToString();
                    LabelComissoesAtivas.Text = value.ToString();

                }
                else
                {
                    ((HtmlInputGenericControl)row.FindControl("starating")).Visible = false;
                    ((Label)row.FindControl("ratinglabel")).Visible = true;
                }
            }
        }

        protected void BtnCreateComission_Click(object sender, EventArgs e)
        {
            int Ano;
            int.TryParse(TbAno.Text, out Ano);


            if (!Page.IsValid) { return; }
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();

            BtnCreateComission.Enabled = false; //Prevenir Flood
            Random rnd = new Random();

            if(LbOficinas.GetSelectedIndices().Count() > 1)
            {
                int var, groupno;

                do
                {
                    groupno = rnd.Next(1, 10000);
                    var = Commissions.CheckIfGroupExists(groupno);
                    if (var == -1) { Response.Redirect("~/Error.aspx"); }
                } while (var != 0);
              
                foreach (int i in LbOficinas.GetSelectedIndices())
                {

                    if (Commissions.CreateComissionGroup(TbModelo.Text, DdlTipo.SelectedValue, LbOficinas.Items[i].Value, Ano, TbDetails.Text, user, groupno) == false)
                    {
                        Response.Redirect("~/Error.aspx");
                    }

                }
            }
            else
            {
                foreach (int i in LbOficinas.GetSelectedIndices())
                {

                    if (Commissions.CreateComission(TbModelo.Text, DdlTipo.SelectedValue, LbOficinas.Items[i].Value, Ano, TbDetails.Text, user ) == false)
                    {
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }

            Response.Redirect("ComissionCreated.aspx");
        }

        protected void UpdateBadges()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();

            int value = Badges.CountActiveComissions(user);
            if (value == -1) { Response.Redirect("~/Error.aspx"); }
            BadgeCountActiveComissions.Text = value.ToString();
            int value2 = Badges.CountPendingComissions(user);
            if (value == -1) { Response.Redirect("~/Error.aspx"); }
            BadgeCountPendingComissions.Text = value2.ToString();
            BadgeComissions.Text = (value2 + value).ToString();

            int value3 = Badges.CountActiveComissionsWorkshop(user);
            if (value3 == -1) { Response.Redirect("~/Error.aspx"); }
            LabelComissoesAtivas.Text = value3.ToString();
            int value4 = Badges.CountPendingComissionsWorkshop(user);
            if (value4 == -1) { Response.Redirect("~/Error.aspx"); }
            LabelComissoesPendentes.Text = value4.ToString();
        }

        protected void PopulateGridViews()
        {
            //-----Client------//

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //Active
            string storedprocedure = "GetActiveComissions";
            SqlConnection cn = GetSqlCon.GetCon();
            if (cn == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(storedprocedure, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridViewActiveComissions.DataSource = dt;
            GridViewActiveComissions.DataBind();
            cn.Close();

            //Pending - Singles
            string storedprocedure2 = "GetPendingComissions";
            SqlConnection cn2 = GetSqlCon.GetCon();
            if (cn2 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt2 = new DataTable();
            SqlCommand cmd2 = new SqlCommand(storedprocedure2, cn2);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            GridViewComissionsPending.DataSource = dt2;
            GridViewComissionsPending.DataBind();
            cn2.Close();

            //Pending - Group
            string storedprocedure8 = "GetPendingGroupComissions";
            SqlConnection cn8 = GetSqlCon.GetCon();
            if (cn8 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt8 = new DataTable();
            SqlCommand cmd8 = new SqlCommand(storedprocedure8, cn8);
            cmd8.CommandType = System.Data.CommandType.StoredProcedure;
            cmd8.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da8 = new SqlDataAdapter(cmd8);
            da8.Fill(dt8);
            GridViewGroupComissions.DataSource = dt8;
            GridViewGroupComissions.DataBind();
            cn8.Close();

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


            //-----Workshop-----//

            //Active
            string storedprocedure4 = "GetActiveComissionsWorkshop";
            SqlConnection cn4 = GetSqlCon.GetCon();
            if (cn4 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt4 = new DataTable();
            SqlCommand cmd4 = new SqlCommand(storedprocedure4, cn4);
            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(dt4);
            ActiveComissions.DataSource = dt4;
            ActiveComissions.DataBind();

            //Pending
            string storedprocedure5 = "GetPendingComissionsWorkshop";
            SqlConnection cn5 = GetSqlCon.GetCon();
            if (cn5 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt5 = new DataTable();
            SqlCommand cmd5 = new SqlCommand(storedprocedure5, cn5);
            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
            cmd5.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            da5.Fill(dt5);
            PendingComissions.DataSource = dt5;
            PendingComissions.DataBind();

            //History
            string storedprocedure6 = "GetHistoryOfComissionsWorkshop";
            SqlConnection cn6 = GetSqlCon.GetCon();
            if (cn6 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt6 = new DataTable();
            SqlCommand cmd6 = new SqlCommand(storedprocedure6, cn6);
            cmd6.CommandType = System.Data.CommandType.StoredProcedure;
            cmd6.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
            da6.Fill(dt6);
            HistoryOfComissionsWorkshop.DataSource = dt6;
            HistoryOfComissionsWorkshop.DataBind();

            //Clients
            string storedprocedure7 = "GetWorkshopClients";
            SqlConnection cn7 = GetSqlCon.GetCon();
            if (cn7 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt7 = new DataTable();
            SqlCommand cmd7 = new SqlCommand(storedprocedure7, cn7);
            cmd7.CommandType = System.Data.CommandType.StoredProcedure;
            cmd7.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da7 = new SqlDataAdapter(cmd7);
            da7.Fill(dt7);
            Clientes.DataSource = dt7;
            Clientes.DataBind();
        }

        protected void GetPrices()
        {
            foreach (GridViewRow row in PendingComissions.Rows)
            {
                int id, price;
                int.TryParse(row.Cells[1].Text, out id);
                price = Commissions.GetPrice(id);
                TextBox txtPrice = row.FindControl("txtPrice") as TextBox;
                Button BtnOrcamento = row.FindControl("BtnSetPrice") as Button;
                Button BtnReject = row.FindControl("BtnRejectComission") as Button;

                if (price != 0)
                {

                    BtnOrcamento.Visible = false;
                    BtnReject.Visible = false;
                    txtPrice.Text = price.ToString();
                   
                }
                else
                {
                    
                    txtPrice.Text = "N/A";
                } 
            }

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

        protected void Comissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SubmitRating")
            {

                int index = Convert.ToInt32(e.CommandArgument), id, rating;
                GridViewRow row = HistoryOfComissions.Rows[index];
                int.TryParse(row.Cells[0].Text, out id);
                int.TryParse(((HtmlInputGenericControl)row.FindControl("starating")).Value, out rating);
                if (Commissions.SetRating(id, rating) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("Comissions.aspx");
            }

            if (e.CommandName == "SetPrice")
            {
                int Price_int;
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = PendingComissions.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                TextBox Price = row.FindControl("txtPrice") as TextBox;
                if(!int.TryParse(Price.Text, out Price_int))
                {
                    PriceServerValidator.IsValid = false;
                    ValSum.ValidationGroup = "ComissionPrice";
                }
                else if(PriceServerValidator.IsValid == false) { PriceServerValidator.IsValid = true; }
                
                if (Commissions.AddPrice(id, Price_int) == false) { Response.Redirect("~/Error.aspx"); }

            }
            if (e.CommandName == "RejectComissionWorkshop")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = PendingComissions.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                if (Commissions.RejectComission(id) == false) { Response.Redirect("~/Error.aspx"); }

            }
            if (e.CommandName == "ConcludeComission")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = ActiveComissions.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                LabelComissoesAtivas.Text = id.ToString();
                if (Commissions.ConcludeComission(id) == false) { Response.Redirect("~/Error.aspx"); }

            }
            if (e.CommandName == "EditPrice")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = PendingComissions.Rows[index];
                TextBox Price = row.FindControl("txtPrice") as TextBox;  
                if(Price.Text == "N/A")
                {
                    Price.ReadOnly = false;
                    Price.Text = "";
                    Button BtnSetPrice = row.FindControl("BtnSetPrice") as Button;
                    BtnSetPrice.Visible = false;
                    Button BtnAcceptComission = row.FindControl("BtnAcceptComission") as Button;
                    BtnAcceptComission.Visible = true;
                }
                else
                {
                    return;
                }
                return;
            }

            if (e.CommandName == "AcceptComission")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = GridViewGroupDetails.Rows[index];
                int.TryParse(row.Cells[0].Text, out id);
                if (Commissions.ActivateComission(id) == false) { Response.Redirect("~/Error.aspx"); }

                RejectOthers(row.Cells[0].Text);

                Response.Redirect("~/DualRole/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }

            if (e.CommandName == "RejectComission")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = GridViewGroupDetails.Rows[index];
                int.TryParse(row.Cells[0].Text, out id);
                if (Commissions.RejectComission(id) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("~/DualRole/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }

            if (e.CommandName == "ShowGroupDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument), groupno;
                GridViewRow row = GridViewGroupComissions.Rows[index];
                int.TryParse(row.Cells[0].Text, out groupno);

                Populate_Details(groupno); 
            }

            if (e.CommandName == "AcceptComissionNonGroup")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = GridViewComissionsPending.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                if (Commissions.ActivateComission(id) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("~/DualRole/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }
            if (e.CommandName == "RejectComissionNonGroup")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = GridViewComissionsPending.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                if (Commissions.RejectComission(id) == false) { Response.Redirect("~/Error.aspx"); }

                Response.Redirect("~/DualRole/Comissions.aspx");//Errado, mas se não for feito, as avaliações não são carregadas. (erro desconhecido)
            }

            UpdateBadges();
            PopulateGridViews();
            GetRatings();
            GetPrices();
            EditTablesUpdatePanel.Update();
        }

        protected void DdlOficinasRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proc = "GetWorkshopsInRegionExceptSelf";

            if (DdlOficinasRegiao.SelectedValue == "0") { LbOficinas.Items.Clear(); return; }
            if (DdlOficinasRegiao.SelectedValue == "Total") { proc = "GetWorkshopNames"; }

            SqlConnection con = GetSqlCon.GetCon();
            SqlDataAdapter com = new SqlDataAdapter(proc, con);
            com.SelectCommand.CommandType = CommandType.StoredProcedure;
            com.SelectCommand.Parameters.AddWithValue("@param1", User.Identity.GetUserId());
            com.SelectCommand.Parameters.AddWithValue("@param2", DdlOficinasRegiao.SelectedValue);
            DataSet ds1 = new DataSet();
            if (com != null)
            { com.Fill(ds1); }
            con.Open();
            LbOficinas.DataSource = ds1;
            LbOficinas.DataTextField = "WorkshopName";
            LbOficinas.DataValueField = "WorkshopName";
            LbOficinas.DataBind();
            con.Close();
       }

        protected void Populate_Details(int groupno)
        {

            string storedprocedure = "GetComissionDetails";
            SqlConnection cn = GetSqlCon.GetCon();
            if (cn == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(storedprocedure, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", groupno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridViewGroupDetails.DataSource = dt;
            GridViewGroupDetails.DataBind();
            cn.Close();
            GridViewGroupDetails.Visible = true;

            foreach (GridViewRow row in GridViewGroupDetails.Rows)
            {
               
                    int id, price;
                    int.TryParse(row.Cells[0].Text, out id);
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

        protected void RejectOthers(string id)
        {

            foreach(GridViewRow row in GridViewGroupDetails.Rows)
            {
                

                if(row.Cells[0].Text != id)
                {
                    int comid;
                    int.TryParse(row.Cells[0].Text, out comid);
                    Commissions.RejectComission(comid);

                }

            }
        }


    }
}