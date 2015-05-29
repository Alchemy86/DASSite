using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASEntityFramework;
using LunchboxWebControls;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class Multibid : Page, IMultibidView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_multibid').className  = 'active';", true);
            
        }

        /// <summary>
        /// Correct layout after use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Reset(object sender, EventArgs e)
        {
            multipaste.Style.Clear();
            LinkButton5.Style.Clear();
            hiddenmulti.Style.Add("Display", "none");
            masssubmit.Style.Add("Display", "none");
            reset.Style.Add("Display", "none");
        }

        protected void MassBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "DeleteRow") return;
            var auctionRef = Guid.Parse(e.CommandArgument.ToString());

            using (var ds = new ASEntities())
            {
                ds.AuctionSearch.Remove(ds.AuctionSearch.First(x => x.AuctionID == auctionRef));
                ds.SaveChanges();
            }
            LoadSearchResults(LunchboxGridView4);
            SetupMultiBidLayout(LunchboxGridView4);
        }

        protected void gvAgency_Sorting(object sender, GridViewSortEventArgs e)
        {
            LunchboxGridView4.Order(SearchResults.AsQueryable(), e.SortExpression);
            hiddenmulti.Style.Clear();
            masssubmit.Style.Clear();
            reset.Style.Clear();
        }

        protected void GenerateMultiBids(object sender, EventArgs e)
        {
            if (!IsPostBack) return;
            var lst = MultiBidText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (!lst.Any()) return;

            foreach (var s in lst)
            {
                Presenter.Search(s);
            }
            SetupMultiBidLayout(LunchboxGridView4);
        }

        protected void SubmitMultiBids(object sender, EventArgs e)
        {
            Presenter.GenerateBids(LunchboxGridView4, BidValue);
            Response.Redirect("Bids.aspx");
        }

        public void LoadSearchResults(LunchboxGridView grid)
        {
            grid.DataSource = SearchResults;
            grid.DataBind();
        }

        public void SetupMultiBidLayout(LunchboxGridView grid)
        {
            multipaste.Style.Add("Display", "none");
            LinkButton5.Style.Add("Display", "none");
            LoadSearchResults(grid);
            hiddenmulti.Style.Clear();
            masssubmit.Style.Clear();
            reset.Style.Clear();
        }

        public IQueryable<AuctionSearch> SearchResults
        {
            get { return Presenter.SearchResults(); }
        }

        public MultibidPresenter Presenter
        {
            get
            {
                if (Session["presenter"] != null)
                {
                    return (MultibidPresenter)Session["presenter"];
                }
                return new MultibidPresenter(this, (Master.Default)Master);
            }
        }

        public string MultiBidText
        {
            get { return TextBox1.Text; }
        }


        public int BidValue
        {
            get { return int.Parse(fullApplyvalue.Value ?? "0"); }
        }
    }
}