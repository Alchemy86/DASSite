using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Master.Default) Master).GoDaddyAccount != null)
            {
                Response.Redirect("Setup.aspx");
            }
        }
    }
}