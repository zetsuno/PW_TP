using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PW_TP.App_Classes;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace PW_TP.Administration
{
    public partial class Manage : System.Web.UI.Page
    {
        int _counter = -1;
      

        protected void Page_Init(object sender, EventArgs e)
        {
            UpdateBadges();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void GridViewToValidate_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ActivateAcc")
            { 
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewToValidate.Rows[index];
                string id = row.Cells[1].Text;

                CheckVerified.EnableAccount(id);
            }
 
           UpdateBadges();
           GridViewTotal.DataBind();
           GridViewToValidate.DataBind();
           EditTablesUpdatePanel.Update();   
        }

        protected void GridViewTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewTotal.EditIndex = index;
                _counter = index;    
            }

            if (e.CommandName == "DeleteData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTotal.Rows[index];
                string id = row.Cells[1].Text;
                DeleteUser.RemoverUserFromDB(id);   
            }

            if(e.CommandName == "CancelEdit")
            {
                _counter = -1;
                GridViewTotal.EditIndex = _counter;
            }

            if (e.CommandName == "UpdateData")
            {   
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTotal.Rows[index];

                string id = row.Cells[1].Text;
                TextBox email = row.FindControl("txtEmail") as TextBox;
                DropDownList emailconfirmed = row.FindControl("ddlEmailConfirmed") as DropDownList;
                TextBox passwordhash = row.FindControl("txtPasswordHash") as TextBox;
                TextBox securitystamp = row.FindControl("txtSecurityStamp") as TextBox;
                TextBox phonenumber = row.FindControl("txtPhoneNumber") as TextBox;
                DropDownList phonenumberconfirmed = row.FindControl("ddlPhoneNumberConfirmed") as DropDownList;
                DropDownList twofactorenabled = row.FindControl("ddlTwoFactorEnabled") as DropDownList;
                TextBox lockoutenddateutc = row.FindControl("txtLockoutEndDateUtc") as TextBox;
                DateTime LockoutDateEnd = DateTime.Parse(lockoutenddateutc.Text);
                DropDownList lockoutenabled = row.FindControl("ddlLockoutEnabled") as DropDownList;
                TextBox accessfailedcount = row.FindControl("txtAccessFailedCount") as TextBox;
                TextBox username = row.FindControl("txtUserName") as TextBox;
                TextBox workshopname = row.FindControl("txtWorkshopName") as TextBox;
                TextBox workshopnif = row.FindControl("txtWorkshopNIF") as TextBox;
                TextBox workshopowner = row.FindControl("txtWorkshopOwner") as TextBox;
                TextBox workshopownernif = row.FindControl("txtWorkshopOwnerNIF") as TextBox;
                DropDownList isenabled = row.FindControl("ddlIsEnabled") as DropDownList;
                TextBox displayname = row.FindControl("txtDisplayName") as TextBox;

                RegisterUser.UpdateUserInfo(id, email.Text, emailconfirmed.SelectedValue, passwordhash.Text, securitystamp.Text, phonenumber.Text, phonenumberconfirmed.SelectedValue,
                twofactorenabled.SelectedValue, LockoutDateEnd, lockoutenabled.SelectedValue, accessfailedcount.Text, username.Text, workshopname.Text, workshopnif.Text,
                workshopowner.Text, workshopownernif.Text, isenabled.SelectedValue, displayname.Text);   
 
                GridViewTotal.EditIndex = -1;
            }

            UpdateBadges();
            GridViewTotal.DataBind();
            GridViewToValidate.DataBind();
            EditTablesUpdatePanel.Update();
        }


         protected void GridViewTotal_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 if(_counter == e.Row.RowIndex){ 

                     Button btnEdit = e.Row.FindControl("ButtonEdit") as Button;
                     Button btnDelete = e.Row.FindControl("ButtonDelete") as Button;
                     Button btnConfirm = e.Row.FindControl("ButtonConfirmEdit") as Button;
                     Button btnCancel = e.Row.FindControl("ButtonCancelEdit") as Button;

                     btnCancel.Visible = true;
                     btnConfirm.Visible = true;
                     btnDelete.Visible = false;
                     btnEdit.Visible = false;

                                      

                }
            }
        }

        protected void UpdateBadges()
        {
            int value = CountTableEntries.GetToVerifyCount();
            BadgeCountToVerify.Text = value.ToString();
            int value2 = CountTableEntries.AllAccsCount();
            BadgeCountAll.Text = value2.ToString();
        }

        protected void GridViewTotal_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            
        }

        protected void GridViewTotal_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridViewTotal.EditIndex = -1;
            GridViewTotal.DataBind();
        }

    }
}
