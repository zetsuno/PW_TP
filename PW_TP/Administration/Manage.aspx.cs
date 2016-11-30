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

            EditTablesUpdatePanel.Update();
        }

        protected void GridViewTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewTotal.EditIndex = index;

                /*operações de edição*/

                GridViewTotal.DataBind();

            }

            if (e.CommandName == "DeleteData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTotal.Rows[index];
                string id = row.Cells[1].Text;
                DeleteUser.RemoverUserFromDB(id);
                GridViewTotal.DataBind();
                UpdateBadges();
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
