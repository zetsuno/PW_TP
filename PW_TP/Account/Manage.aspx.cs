using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using PW_TP.Models;
using PW_TP.App_Classes;

namespace PW_TP.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Init()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UnauthorizedAccess.aspx");

            }

            if (User.IsInRole("workshop") && User.IsInRole("client")) { accTypeLabel.Text = "Cliente/Oficina";}
            else if (User.IsInRole("workshop")) { accTypeLabel.Text = "Oficina"; ShowWorkshopForm.Text = "Tornar Cliente"; ShowWorkshopForm.Visible = true; }
            else if (User.IsInRole("client")) { accTypeLabel.Text = "Cliente"; ShowWorkshopForm.Text = "Tornar Oficina"; ShowWorkshopForm.Visible = true; }
        }
        protected void Page_Load()
        {
            

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));
            
            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }

        protected void btnRequestDualRole_Click(object sender, EventArgs e)
        {
            
                        

            if (User.IsInRole("client"))
            {
                int nifcheck = Users.CheckDuplicateNIF(NIFTitularOficina.Text);
                if (nifcheck == -1) { Response.Redirect("~/Error.aspx"); }
                else if (nifcheck == 0)
                {
                    Security w = new Security();
                    if (w.AddUserToRoleByID(User.Identity.GetUserId(), "workshop") == false) { Response.Redirect("~/Error.aspx"); }
                    if (CheckVerified.LockAccount(User.Identity.GetUserId()) == false) { Response.Redirect("~/Error.aspx"); }
                    if (Users.UpdateWorkshopDetails(NomeOficina.Text, MoradaOficina.Text, DdlRegiao.SelectedValue, TelefoneOficina.Text, TitularOficina.Text, NIFTitularOficina.Text, User.Identity.GetUserId()) == false) { Response.Redirect("~/Error.aspx"); }
                    Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    Response.Redirect("ValidationRequired.aspx");
                }
                else
                {
                    NIFServerValidator.IsValid = false;
                }
               
                
            }
            
        }

        protected void ShowWorkshopForm_Click(object sender, EventArgs e)
        {
            if (User.IsInRole("workshop"))
            {
                Security w = new Security();
                if (w.AddUserToRoleByID(User.Identity.GetUserId(), "client") == false) { Response.Redirect("~/Error.aspx"); }
                Response.Redirect("RoleChangeSuccess.aspx");
            }
            else if (PainelOficina.Visible == true)
            {
                PainelOficina.Visible = false;
            }
            else
                PainelOficina.Visible = true;
        }
    }
}