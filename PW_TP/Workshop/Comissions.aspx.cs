using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PW_TP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PW_TP.App_Classes;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace PW_TP.Workshop
{
    public partial class Comissions : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }

            if((User.IsInRole("client") && User.IsInRole("workshop"))){

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

        protected void PopulateGridViews()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //Active
            string storedprocedure = "GetActiveComissionsWorkshop";
            SqlConnection cn = GetSqlCon.GetCon();
            if(cn == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(storedprocedure, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ActiveComissions.DataSource = dt;
            ActiveComissions.DataBind();

            //Pending
            string storedprocedure2 = "GetPendingComissionsWorkshop";
            SqlConnection cn2 = GetSqlCon.GetCon();
            if (cn2 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt2 = new DataTable();
            SqlCommand cmd2 = new SqlCommand(storedprocedure2, cn2);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            PendingComissions.DataSource = dt2;
            PendingComissions.DataBind();

            //History
            string storedprocedure3 = "GetHistoryOfComissionsWorkshop";
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

            //Clients
            string storedprocedure4 = "GetWorkshopClients";
            SqlConnection cn4 = GetSqlCon.GetCon();
            if (cn4 == null) { Response.Redirect("~/Error.aspx"); }

            DataTable dt4 = new DataTable();
            SqlCommand cmd4 = new SqlCommand(storedprocedure4, cn4);
            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(dt4);
            Clientes.DataSource = dt4;
            Clientes.DataBind();

        }

        protected void UpdateBadges()
        {

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();

            int value = Badges.CountActiveComissionsWorkshop(user);
            if(value == -1) { Response.Redirect("~/Error.aspx"); }
            LabelComissoesAtivas.Text = value.ToString();
            int value2 = Badges.CountPendingComissionsWorkshop(user);
            if(value2 == -1) { Response.Redirect("~/Error.aspx"); }
            LabelComissoesPendentes.Text = value2.ToString();

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
                if (!int.TryParse(Price.Text, out Price_int))
                {
                    PriceServerValidator.IsValid = false;
                    ValSum.ValidationGroup = "ComissionPrice";
                }
                else if (PriceServerValidator.IsValid == false) { PriceServerValidator.IsValid = true; }
                if (Commissions.AddPrice(id, Price_int) == false) { Response.Redirect("~/Error.aspx"); }

            }
            if (e.CommandName == "RejectComission")
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
                if (Price.Text == "N/A")
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

            UpdateBadges();
            PopulateGridViews();
            GetRatings();
            GetPrices();
            
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
                    txtPrice.ReadOnly = false;
                    txtPrice.Text = "N/A";
                    txtPrice.ReadOnly = true;
                }

            }
        }

        protected void GetRatings()
        {
            int value;

            foreach (GridViewRow row in HistoryOfComissions.Rows)
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
    }
}