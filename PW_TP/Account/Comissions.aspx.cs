using System;
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
            Random rnd = new Random();

            if (LbOficinas.GetSelectedIndices().Count() > 1)
            {
                int groupno = rnd.Next(1, 10000);

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
                    if (Commissions.CreateComission(TbModelo.Text, DdlTipo.SelectedValue, LbOficinas.Items[i].Value, Ano, TbDetails.Text, user) == false)
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

            if (e.CommandName == "ShowGroupDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument), groupno;
                GridViewRow row = GridViewGroupComissions.Rows[index];
                int.TryParse(row.Cells[0].Text, out groupno);

                Populate_Details(groupno);
            }

            PopulateGridViews();
            GetRatings();
            GetPrices();
            UpdateBadges();
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

    }
}