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

namespace PW_TP.Workshop
{
    public partial class Comissions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
            if (!Page.IsPostBack)
            {
                UpdateBadges();
                PopulateGridViews();

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

            int value = ComissionFuncs.CountActiveComissionsWorkshop(user);
            LabelComissoesAtivas.Text = value.ToString();
            int value2 = ComissionFuncs.CountPendingComissionsWorkshop(user);
            LabelComissoesPendentes.Text = value2.ToString();

        }

        protected void PendingComissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "AcceptComission")
            {
                int index = Convert.ToInt32(e.CommandArgument), id;
                GridViewRow row = PendingComissions.Rows[index];
                int.TryParse(row.Cells[1].Text, out id);
                
                ComissionFuncs.ActivateComission(id);
                
            }

            UpdateBadges();
            PopulateGridViews();
            WorkshopUpdatePanel.Update();
        }
    }
}