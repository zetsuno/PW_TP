﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PW_TP.DualRole
{
    public partial class ComissionCreated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || (!User.IsInRole("workshop") && !User.IsInRole("client")))
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");
            }
        }
    }
}