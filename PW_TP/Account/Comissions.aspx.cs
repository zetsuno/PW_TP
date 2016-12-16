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

namespace PW_TP.Account
{
    public partial class Comissions : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            UpdateBadges();
            
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");     
            }

            if (!Page.IsPostBack)
            {

                GridViewActiveComissions.DataBind();
                GridViewComissionsPending.DataBind();
                HistoryOfComissions.DataBind();
                UpdateBadges();
                
                
            }

            PopulateGridViews();
            UpdateBadges();
        }

        protected void BtnCreateComission_Click(object sender, EventArgs e)
        {
            
            int Ano;
            int.TryParse(TbAno.Text, out Ano);
            
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();
            
            ComissionFuncs.CreateComission(TbModelo.Text, DdlTipo.SelectedValue, DdlOficinas.SelectedValue, Ano, TbDetails.Text, user);
            Response.Redirect("ComissionCreated.aspx");
        }

        protected void UpdateBadges()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string user = User.Identity.GetUserId();

            int value = ComissionFuncs.CountActiveComissions(user);
            BadgeCountActiveComissions.Text  = value.ToString();
            int value2 = ComissionFuncs.CountPendingComissions(user);
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

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(storedprocedure, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridViewActiveComissions.DataSource = dt;
            GridViewActiveComissions.DataBind();

            //Pending
            string storedprocedure2 = "GetPendingComissions";
            SqlConnection cn2 = GetSqlCon.GetCon();

            DataTable dt2 = new DataTable();
            SqlCommand cmd2 = new SqlCommand(storedprocedure2, cn2);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            GridViewComissionsPending.DataSource = dt2;
            GridViewComissionsPending.DataBind();

            //History
            string storedprocedure3 = "HistoryOfcomissions";
            SqlConnection cn3 = GetSqlCon.GetCon();

            DataTable dt3 = new DataTable();
            SqlCommand cmd3 = new SqlCommand(storedprocedure3, cn3);
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@param1", user.Id);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dt3);
            HistoryOfComissions.DataSource = dt3;
            HistoryOfComissions.DataBind();
        }
    }
}