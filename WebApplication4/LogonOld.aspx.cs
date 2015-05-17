using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASEntityFramework;
using AuctionSniperService.Business.Sites;

namespace WebApplication4
{
    public partial class logon : System.Web.UI.Page
    {
        private GoDaddyAuctions GoDaddy = new GoDaddyAuctions();

        public IQueryable<AuctionSearch> SearchResults
        {
            get
            {
                using (var ds = new ASEntities())
                {
                    return ds.AuctionSearch;
                }
            }
            set
            {
                using (var ds = new ASEntities())
                {
                    var search = ds.AuctionSearch.ToList();
                    foreach (var auctionSearch in search)
                    {
                        ds.AuctionSearch.Remove(auctionSearch);
                    }
                    ds.AuctionSearch.AddRange(value);
                    //ds.SaveChanges();
                }
            }
        }

        public void Logon_Click(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = @"Auction Sniper WEB";


            //if (Request.QueryString["ViewUser"] != null)
            //{
            //    string id = Request.QueryString["ViewUser"];
            //    using (var ds = new ASEntities())
            //    {
            //        GridView1.AutoGenerateColumns = true;

            //        var items = ds.Users.Where(x=>x.Username == id).ToList();
            //        GridView1.DataSource = items;
            //        GridView1.DataBind();
            //    }
            //}
            //else
            //{
            //    using (var ds = new ASEntities())
            //    {
            //        var items = ds.Users.ToList();
            //        GridView1.DataSource = items;
            //        GridView1.DataBind();
            //    }
            //}
        }


        protected void btnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?ViewUser=" + ((LinkButton)sender).Attributes["adminID"]);
        }

        protected void gvAgency_DataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //var myButtonAp = e.Row.FindControl("LinkButton1") as LinkButton;
            //    myButtonAp.Attributes.Add("adminID", ((Employee)e.Row.DataItem).DisplayEmployeeId);
            //}
        }

    }
}