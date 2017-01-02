using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PW_TP.DualRole
{
    public partial class RoleChangeSuccess : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!User.IsInRole("cliente") && !User.IsInRole("workshop"))
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
            else if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}