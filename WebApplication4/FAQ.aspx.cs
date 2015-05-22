using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class FAQ : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_faq').className  =document.getElementById('menu_faq').className +  ' active';", true);
            
        }
    }
}