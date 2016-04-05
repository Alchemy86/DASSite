using System;
using System.Web.Security;
using System.Web.UI;
using DAL;
using Ninject;
using WebApplication4.Presenter;
using WebApplication4.View;
using WebApplication4.App_Code;
using DAS.Domain.Users;
using DAS.Domain;

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
            if (!DisplayAccountVerification)
            {
                accountverifictiondisplay.Style.Add("display","none");
            }
            if (UserAccount.AccessLevel != 10)
            {
                menu_admin.Style.Add("display", "none");
            }
            bidcount.InnerText = BidCount;
        }


        /// <summary>
        /// Show/Hide account verification on header
        /// </summary>
        public bool DisplayAccountVerification
        {
            get
            {
                if (Session["DisplayAccountVerification"] == null)
                {
                    return true;
                }
                return (bool)Session["DisplayAccountVerification"];
            }
            set { Session["DisplayAccountVerification"] = value; }
        }

        /// <summary>
        /// Helper contains all actions for Godaddy (site)
        /// </summary>
        public GoDaddyActions GdHelper
        {
            get
            {
                if (Session["GDHelper"] != null)
                {
                    return (GoDaddyActions)Session["GDHelper"];
                }
                Session["GDHelper"] = new GoDaddyActions(Username, this, kernel.Get<IUserRepository>());
                return (GoDaddyActions)Session["GDHelper"];
            }
        }

        public IKernel kernel
        {
            get { return new StandardKernel(new DefaultBindings()); }
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
                return Presenter.GetUser();
            }
        }

        public DefaultPresenter Presenter
        {
            get
            {
                return new DefaultPresenter(this);
            }
        }

        public string BidCount
        {
            get { return Presenter.GetMyBidCount(); }
        }

        /// <summary>
        /// Returns the Pacific time
        /// </summary>
        /// <returns></returns>
        public DateTime GetPacificTime
        {
            get
            {
                var tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                var localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);

                return localDateTime;
            }
        }

        public GoDaddyAccount GoDaddyAccount
        {
            get
            {
                return Presenter.GetGoDaddyAccount(UserAccount);
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
            Presenter.SubmitBug();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('bugtxtv').Value = '';", true);
        }

        public ASEntities Ds
        {
            get { return new ASEntities(); }
        }
    }
}