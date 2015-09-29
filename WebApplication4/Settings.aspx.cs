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
            if (string.IsNullOrEmpty(((Master.Default)Master).GoDaddyAccount.GoDaddyUsername))
            {
                Response.Redirect("Setup.aspx");
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_settings').className  = 'active';", true);
            SetupControls();
        }

        private void SetupControls()
        {
            if (IsPostBack) return;
            receiveEmails.Checked = DefaultPresenter.View.UserAccount.ReceiveEmails;
            GodaddyAccount.Text = DefaultPresenter.View.GoDaddyAccount.GoDaddyUsername;
            useAccountForSearch.Checked = DefaultPresenter.View.UserAccount.UseAccountForSearch;
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
                var account = DefaultPresenter.View.GoDaddyAccount;
                account.GoDaddyPassword = GoDaddyPassword;
                account.GoDaddyUsername = GoDaddyUsername;
                account.Verified = true;
                DefaultPresenter.SaveGoDaddyAccount(account);
                const string moo = "$('#MainContentHolder_emailmessage').attr('class', 'alert alert-success pull-right');$('#MainContentHolder_emailmessage').text('Account verified and updated');$('#MainContentHolder_emailmessage').fadeIn(500).delay(5000).fadeOut('slow'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
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

        protected void Update_UseAccount(object sender, EventArgs e)
        {
            UseAccountForSearch = useAccountForSearch.Checked;
        }

        public bool ReceiveEmails
        {
            get { return DefaultPresenter.View.UserAccount.ReceiveEmails; }
            set
            {
                var account = DefaultPresenter.View.UserAccount;
                account.ReceiveEmails = value;
                DefaultPresenter.SaveSettings(account);
                emailmessage.InnerText = "Settings Saved";

                const string moo = "$('#MainContentHolder_emailmessage').fadeIn(300).delay(1000).fadeOut('slow'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
            }
        }

        public bool UseAccountForSearch
        {
            get { return DefaultPresenter.View.UserAccount.UseAccountForSearch; }
            set
            {
                var account = DefaultPresenter.View.UserAccount;
                account.UseAccountForSearch = value;
                DefaultPresenter.SaveSettings(account);
                emailmessage.InnerText = "Settings Saved";

                const string moo = "$('#MainContentHolder_emailmessage').fadeIn(300).delay(1000).fadeOut('slow'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
            }
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

        public SettingsPresenter Presenter
        {
            get
            {
                if (Session["SettingsPresenter"] != null)
                {
                    return (SettingsPresenter) Session["SettingsPresenter"];
                }
                Session["SettingsPresenter"] = new SettingsPresenter(this);
                return (SettingsPresenter)Session["SettingsPresenter"];
            }
        }
    }
}