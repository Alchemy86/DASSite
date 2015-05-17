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
        }

        public Users UserAccount
        {
            get
            {
                if (Session["UserAccount"] != null)
                {
                    return (Users) Session["UserAccount"];
                }
                var presenter = new DefaultPresenter(this);
                Session["UserAccount"] = presenter.GetUser();
                return (Users)Session["UserAccount"];
            }
        }

        public string Username
        {
            get
            {
                return Context.User.Identity.Name;
            }
        }


        protected void Signout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/LoginPage.aspx");
        }

        protected void BtnSubmitBug(object sender, EventArgs e)
        {
            var presenter = new DefaultPresenter(this);
            if (presenter.SubmitBug())
            {
                sentmessage.Text = @"Bug Report Sent. Thank you for the feedback";
            }
        }


        public string BugMessage
        {
            get { return bugtxtv.Text; }
        }
    }
}