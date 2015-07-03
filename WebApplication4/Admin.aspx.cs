using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using ASEntityFramework;

namespace WebApplication4
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_admin').className  = document.getElementById('menu_admin').className + ' active';", true);
            var data = new ASEntities().Chart_PopularDomainsThisMonth.ToList();
            Chart1.Series[0].Points.DataBindXY(data, data);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Legends[0].Enabled = true;
        }
    }
}