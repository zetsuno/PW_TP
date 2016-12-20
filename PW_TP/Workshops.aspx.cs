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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               
            }
        }

        protected void ddlOficinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOficinas.SelectedValue != "0")
            {
                double rating;
                string workshopid, rating_string;

                workshopid = Users.GetWorkshopId(ddlOficinas.SelectedValue);
                if(workshopid == "") { Response.Redirect("Error.aspx"); }
                rating = Commissions.GetAvgRating(workshopid);
                if(rating == -1) { Response.Redirect("Error.aspx"); }

                rating_string = rating.ToString();
                StringBuilder strB = new StringBuilder(rating_string);
                strB[1] = '.';
                starrating.Value = strB.ToString();
                starrating.Visible = true;
                labelstar.Text = strB.ToString();
                
            }


        }
    }
}