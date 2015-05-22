using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_search').className  = 'active';", true);
            
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}