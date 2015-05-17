using System;
using System.Web.Security;
using System.Web.UI;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class LoginPage : Page, ILoginView
    {
        public string UserName
        {
            get { return UserEmail.Text; }
            set { }
        }

        public string Password
        {
            get { return UserPass.Text; }
            set { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logon_Click(object sender, EventArgs e)
        {
            var presenter = new LoginPresenter(this);
            if (presenter.Login())
            {
                FormsAuthentication.RedirectFromLoginPage(UserName, Persist.Checked);
            }
            else
            {
                Msg.Text = @"Invalid credentials. Please try again.";
            }
        }


    }
}