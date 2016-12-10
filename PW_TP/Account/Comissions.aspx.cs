using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PW_TP.App_Classes;

namespace PW_TP.Account
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

            }
        }

        protected void BtnCreateComission_Click(object sender, EventArgs e)
        {
            int Ano;
            int.TryParse(TbAno.Text, out Ano);
            ComissionFuncs.CreateComission(TbModelo.Text, DdlTipo.SelectedValue, DdlOficinas.SelectedValue, Ano, TbDetails.Text);
        }
    }
}