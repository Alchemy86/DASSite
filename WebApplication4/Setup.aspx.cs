using System;
using System.Linq;
using System.Web.UI;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class Setup : Page, ISetupView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This page has one purpose, add an account whe you have none so go back if you have one
            if (DefaultView.UserAccount.GoDaddyAccount.Any())
            {
                Response.Redirect("Default.aspx");
            }
            DefaultView.DisplayAccountVerification = false;
        }

        protected void btnSave_Godaddy(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GoDaddyUsername))
            {
                Msg.Text = @"Please add a username";
                return;
            }
            if (string.IsNullOrEmpty(GoDaddyPassword))
            {
                Msg.Text = @"Please add a password";
                return;
            }
            Msg.Text = "";
            var presenter = new SetupPresenter(this);
            presenter.CreateGoDaddyAccount();
            DefaultView.DisplayAccountVerification = true;
            Response.Redirect("Default.aspx");
        }

        public string GoDaddyUsername
        {
            get { return GodaddyUsername.Text; }
        }

        public string GoDaddyPassword
        {
            get { return GodaddyPassword.Text;  }
        }

        public IDefaultView DefaultView
        {
            get { return (Master.Default)Master; }
        }
    }
}