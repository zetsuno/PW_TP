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
using System.Text;

namespace PW_TP
{
    public partial class Workshops : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected int populate_DDL()
        {
            int val;
            SqlConnection con = GetSqlCon.GetCon();
            SqlDataAdapter com = new SqlDataAdapter("GetWorkshopNamesByRegion", con);
            com.SelectCommand.CommandType = CommandType.StoredProcedure;
            com.SelectCommand.Parameters.AddWithValue("@param1", DdlRegiao.SelectedValue);
            DataSet ds1 = new DataSet();
            if (com != null)
            { com.Fill(ds1); }
            con.Open();
            DdlOficinas.DataSource = ds1;
            DdlOficinas.DataTextField = "WorkshopName";
            DdlOficinas.DataValueField = "WorkshopName";
            DdlOficinas.DataBind();
            con.Close();

            val = CountTableEntries.CountWorkshopsInRegion(DdlRegiao.SelectedValue);
            if(val == -1) { Response.Redirect("~/Error.aspx"); }
            return val;
        }

        protected void DdlRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result;

            if(DdlRegiao.SelectedValue != "0")
            {
                
               
                result = populate_DDL();
                if(result == 0)
                {
                    DdlOficinas.Items.Insert(0, new ListItem("Não existem Oficinas na Região", "0"));
                    if(DdlOficinas.Enabled == true) { DdlOficinas.Enabled = false; }
                   
                }
                else
                {
                    DdlOficinas.Items.Insert(0, new ListItem("-- Selecione --", "0"));
                    DdlOficinas.Enabled = true;
                }
               
                
                
                    
            }
        }
    }
}