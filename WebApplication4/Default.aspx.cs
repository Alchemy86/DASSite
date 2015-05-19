using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ReSharper disable once PossibleNullReferenceException
            if (string.IsNullOrEmpty(((Master.Default) Master).GoDaddyAccount.GoDaddyUsername))
            {
                Response.Redirect("Setup.aspx");
            }
        }
    }
}