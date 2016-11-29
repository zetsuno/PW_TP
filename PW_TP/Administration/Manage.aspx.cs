using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PW_TP.App_Classes;

namespace PW_TP.Administration
{
    public partial class Manage : System.Web.UI.Page
    {
        

        protected void Page_Init(object sender, EventArgs e)
        {
            UpdateBadges();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonActivateAcc_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridViewToValidate_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ActivateAcc")
            { 
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);
                
                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridViewToValidate.Rows[index];

                // Add code here to add the item to the shopping cart.
                string id = row.Cells[1].Text;
                CheckVerified.EnableAccount(id);
                GridViewToValidate.DataBind();
                UpdateBadges();

            }
            if (e.CommandName == "EditData")
            {


            }

                EditTablesUpdatePanel.Update();
        }
        
        protected void UpdateBadges()
        {
            int value = CountTableEntries.GetToVerifyCount();
            BadgeCountToVerify.Text = value.ToString();
            int value2 = CountTableEntries.AllAccsCount();
            BadgeCountAll.Text = value2.ToString();
        }

    }
}
