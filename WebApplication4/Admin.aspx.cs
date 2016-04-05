using System;
using System.Web.UI;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class Admin : Page, IAdminView
    {
        public IDefaultView DefaultView
        {
            get { return (Master.Default)Master; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_admin').className  = document.getElementById('menu_admin').className + ' active';", true);
            if (DefaultView.UserAccount.AccessLevel != 10)
            {
                Response.Redirect("BasicSearch.aspx");
            }
            var moo = DefaultView.GetPacificTime.ToString("M/dd/yyyy H:mm:ss");
        }
    }
}