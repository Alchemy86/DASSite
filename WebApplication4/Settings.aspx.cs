using System;
using System.Web.UI;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class Settings : Page, ISettingsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_settings').className  = 'active';", true);
            SetupControls();
        }

        private void SetupControls()
        {
            if (!IsPostBack)
            {
                receiveEmails.Checked = DefaultView.UserAccount.ReceiveEmails;
                GodaddyAccount.Text = DefaultView.GoDaddyAccount.GoDaddyUsername;
            }
        }

        protected void Verify_click(object sender, EventArgs e)
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

            if (DefaultPresenter.ValidateGodaddy(GoDaddyUsername, GoDaddyPassword))
            {
                DefaultView.DisplayAccountVerification = true;
                Response.Redirect("Default.aspx");
            }
            else
            {
                const string moo = "$('#MainContentHolder_emailmessage').attr('class', 'alert alert-danger pull-right');$('#MainContentHolder_emailmessage').text('Unable to verify account, please confirm your details.');$('#MainContentHolder_emailmessage').fadeIn(1000).delay(5000).fadeOut('slow'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
            }
        }

        protected void Update_EmailOptions(object sender, EventArgs e)
        {
            ReceiveEmails = receiveEmails.Checked;
        }

        public bool ReceiveEmails
        {
            get { return DefaultView.UserAccount.ReceiveEmails; }
            set
            {
                var account = DefaultView.UserAccount;
                account.ReceiveEmails = value;
                DefaultPresenter.SaveSettings(account);
                emailmessage.InnerText = "Settings Saved";

                const string moo = "$('#MainContentHolder_emailmessage').fadeIn(300).delay(1000).fadeOut('slow'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
            }
        }

        public IDefaultView DefaultView
        {
            get { return (Master.Default)Master; }
        }

        public string GoDaddyUsername
        {
            get { return GodaddyAccount.Text; }
        }
            
        public string GoDaddyPassword
        {
            get { return GodaddyPassword.Text; }
        }

        public DefaultPresenter DefaultPresenter
        {
            get { return ((Master.Default) Master).Presenter; }
        }
    }
}