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
        int _counter = -1, _counter2 = -1;
      

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

                if(AccStatus.EnableAccount(id) == false) { Response.Redirect("~/Error.aspx"); }
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
                if(App_Classes.Users.RemoverUserFromDB(id) == false) { Response.Redirect("~/Error.aspx"); }   
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
                TextBox workshopphone = row.FindControl("txtWorkshopPhone") as TextBox;
                TextBox workshopowner = row.FindControl("txtWorkshopOwner") as TextBox;
                TextBox workshopownernif = row.FindControl("txtWorkshopOwnerNIF") as TextBox;
                TextBox workshopaddress = row.FindControl("txtWorkshopAddress") as TextBox;
                TextBox workshopregion = row.FindControl("txtWorkshopRegion") as TextBox;
                DropDownList isenabled = row.FindControl("ddlIsEnabled") as DropDownList;
                TextBox displayname = row.FindControl("txtDisplayName") as TextBox;
                

                if (App_Classes.Users.UpdateUserInfo(id, email.Text, emailconfirmed.SelectedValue, passwordhash.Text, securitystamp.Text, phonenumber.Text, phonenumberconfirmed.SelectedValue,
                twofactorenabled.SelectedValue, LockoutDateEnd, lockoutenabled.SelectedValue, accessfailedcount.Text, username.Text, workshopname.Text, workshopphone.Text,
                workshopowner.Text, workshopownernif.Text, workshopaddress.Text, workshopregion.Text, isenabled.SelectedValue, displayname.Text) == false) { Response.Redirect("~/Error.aspx"); }   
 
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
            int value = Badges.GetToVerifyCount();
            if(value == -1) { Response.Redirect("~/Error.aspx"); }
            BadgeCountToVerify.Text = value.ToString();
            int value2 = Badges.AllAccsCount();
            if (value2 == -1) { Response.Redirect("~/Error.aspx"); }
            BadgeCountAll.Text = value2.ToString();
            int value3 = Badges.CountComissions();
            if(value3 == -1) { Response.Redirect("~/Error.aspx"); }
            BadgeCountComissions.Text = value3.ToString();
        }

        protected void GridViewTotal_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            
        }

        protected void GridViewTotal_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridViewTotal.EditIndex = -1;
            GridViewTotal.DataBind();
        }

        protected void GridViewComissions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (_counter2 == e.Row.RowIndex)
                {
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

        protected void GridViewComissions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridViewComissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewComissions.EditIndex = index;
                _counter2 = index;
            }

            if (e.CommandName == "DeleteData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComissions.Rows[index];
                string id = row.Cells[1].Text;
                if(Commissions.DeleteComission(id) == false) { Response.Redirect("~/Error.aspx"); }
            }

            if (e.CommandName == "CancelEdit")
            {
                _counter2 = -1;
                GridViewComissions.EditIndex = _counter;
            }

            if (e.CommandName == "UpdateData")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComissions.Rows[index];

                string id = row.Cells[1].Text;
                TextBox ClientId = row.FindControl("txtClientId") as TextBox;        
                TextBox WorkshopId = row.FindControl("txtWorkshopId") as TextBox;
                DropDownList Concluded = row.FindControl("ddlConcluded") as DropDownList;
                TextBox txtCreationDate = row.FindControl("txtCreationDate") as TextBox;
                DateTime CreationDate = DateTime.Parse(txtCreationDate.Text);
                TextBox BicycleModel = row.FindControl("txtBicycleModel") as TextBox;
                TextBox BicycleType = row.FindControl("txtBicycleType") as TextBox;
                TextBox YearOfAquisition = row.FindControl("txtYearOfAquisition") as TextBox;
                TextBox Details = row.FindControl("txtDetails") as TextBox;
                DropDownList Accepted = row.FindControl("ddlAccepted") as DropDownList;
                TextBox ComissionNo = row.FindControl("txtComissionNo") as TextBox;
                TextBox Rating = row.FindControl("txtDetails") as TextBox;

                if(Commissions.UpdateComission(id, ClientId.Text, WorkshopId.Text, Concluded.SelectedValue, CreationDate, BicycleModel.Text, BicycleType.Text,
                 YearOfAquisition.Text, Details.Text, Accepted.SelectedValue, ComissionNo.Text, Rating.Text) == false) { Response.Redirect("~/Error.aspx"); }

                GridViewComissions.EditIndex = -1;
            }

            UpdateBadges();
            GridViewComissions.DataBind();
            EditTablesUpdatePanel.Update();
        }

        protected void GridViewComissions_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridViewComissions.EditIndex = -1;
            GridViewComissions.DataBind();
        }
    }
}
