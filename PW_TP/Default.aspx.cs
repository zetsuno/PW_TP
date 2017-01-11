using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PW_TP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Orcament_Click(object sender, ImageClickEventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("client"))
                {
                    if (HttpContext.Current.User.IsInRole("workshop"))
                    {
                        Response.Redirect("~/DualRole/Comissions.aspx");
                    }
                    Response.Redirect("~/Account/Comissions.aspx");
                }
                else if (HttpContext.Current.User.IsInRole("workshop"))
                {
                    if (HttpContext.Current.User.IsInRole("client"))
                    {
                        Response.Redirect("~/DualRole/Comissions.aspx");
                    }
                    Response.Redirect("~/Workshop/Comissions.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}