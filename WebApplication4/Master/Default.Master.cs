using System;
using System.Web.Security;
using System.Web.UI;
using ASEntityFramework;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4.Master
{
    public partial class Default : MasterPage, IDefaultView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Welcome.Text = @"Hello, " + Username + @"    ";
            if (!AccountVerified)
            {
                accountverified.Style.Add("display", "none");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('flash').style.display = 'none';", true);
                verifyaccount.Style.Add("display", "none");
                godaddydisplay.InnerText = GoDaddyAccount.GoDaddyUsername;
            }
        }

        public string BugMessage
        {
            get
            {
                if (Session["BugText"] != null)
                {
                    return (string) Session["BugText"];
                }
                return "";
            }
            set { Session["BugText"] = value; }
        }

        public Users UserAccount
        {
            get
            {
                var presenter = new DefaultPresenter(this);
                return presenter.GetUser();
            }
        }

        public GoDaddyAccount GoDaddyAccount
        {
            get
            {
                var presenter = new DefaultPresenter(this);
                return presenter.GetGoDaddyAccount(UserAccount);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Username
        {
            get
            {
                return Context.User.Identity.Name;
            }
        }

        public bool AccountVerified
        {
            get { return GoDaddyAccount.Verified; }
        }

        protected void Signout_Click(object sender, EventArgs e)
        {
            if (!IsPostBack) return;
            FormsAuthentication.SignOut();
            Response.Redirect("~/LoginPage.aspx");
        }

        protected void BtnSubmitBug(object sender, EventArgs e)
        {
            if ((!IsPostBack || BugMessage == bugtxtv.Text) && bugtxtv.Text != string.Empty) return;
            BugMessage = bugtxtv.Text;
            bugtxtv.Text = "";
            var presenter = new DefaultPresenter(this);
            presenter.SubmitBug();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('bugtxtv').Value = '';", true);
        }
    }
}