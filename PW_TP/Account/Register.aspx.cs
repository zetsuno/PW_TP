using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PW_TP.Models;
using PW_TP.App_Classes;

namespace PW_TP.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e){}

        protected void CreateUser_Click(object sender, EventArgs e)
        {
           
            if(RBtnCliente.Checked == false && RBtnOficina.Checked == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Por favor selecione um tipo de conta" + "');", true); //RadioButton Check Popup Window
                return;
            }

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (RBtnCliente.Checked == true)
            {
                RegisterUser.RegisterUserTypeClient(NomeCliente.Text, Password.Text, Email.Text, NIFCliente.Text);
                Security c = new Security();
                c.AddUserToRole(Email.Text, "client");
            }
            if (RBtnOficina.Checked == true)
            {
                RegisterUser.RegisterUserTypeWorkshop(Email.Text, Password.Text, NomeOficina.Text, nifOficina.Text, TitularOficina.Text, NIFTitularOficina.Text);
                Security w = new Security();
                w.AddUserToRole(Email.Text, "workshop");
                Response.Redirect("ValidationRequired.aspx");

            }

            if (result.Succeeded && RBtnCliente.Checked == true)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void RBtnOficina_CheckedChanged(object sender, EventArgs e)
        {
            PainelUtilizador.Visible = false;
            PainelOficina.Visible = true;
        }

        protected void RBtnCliente_CheckedChanged(object sender, EventArgs e)
        {
            PainelOficina.Visible = false;
            PainelUtilizador.Visible = true;
        }
    }
}