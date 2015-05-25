using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class Search : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_search').className  = 'active';", true);
            slidermenuholder.Controls.Add(new LiteralControl(@"<div class='col-md-4'><div id='slider_pagerank' ClientIDMode='Static' runat='server'></div>
	<p class='text-center'><b>Majestic Citationflow</b></p>
	<div id='slider4'></div>
</div>"));
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}