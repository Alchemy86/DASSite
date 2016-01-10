using System;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASEntityFramework;
using AuctionSniperService.Business.Sites;
using LunchboxSource.Business;
using LunchboxWebControls;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class BasicSearch : Page
    {
        public IDefaultView DefaultView
        {
            get { return (Master.Default)Master; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_search').className  = 'active';", true);
            if (Request.QueryString["bookId"] != null && Request.QueryString["bidvalue"] != null)
            {
                

            }
        }

        public IQueryable<AuctionSearch> SearchResults
        {
            get
            {
                return DefaultView.Ds.AuctionSearch.Where(x => x.AccountID == DefaultView.GoDaddyAccount.AccountID).ToList().AsQueryable();
            }
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            DefaultPresenter.ValidateGodaddy();
            DefaultPresenter.GoDaddyActions.Search(txtSearch.Text,int.Parse(ddlTopResults.SelectedValue));
            LoadSearchResults(LunchboxGridView1);
        }

        private void LoadSearchResults(LunchboxGridView grid)
        {
            grid.DataSource = SearchResults;
            grid.DataBind();
        }

        public DefaultPresenter DefaultPresenter
        {
            get { return ((Master.Default)Master).Presenter; }
        }

        protected void gvAgency_DataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    var myButtonAp = e.Row.FindControl("LinkButton1") as LinkButton;
            //    Page.ClientScript.RegisterStartupScript(
            //        GetType(),
            //        "MyKey",
            //        "zxcCountDown('SetBid','message',20);",
            //        true);
            //    myButtonAp.Attributes.Add("adminID", ((Auctions)e.Row.DataItem).EstimateEndDate);
            //}
        }

        protected void gvAgency_Sorting(object sender, GridViewSortEventArgs e)
        {
            LunchboxGridView1.Order(SearchResults.AsQueryable(), e.SortExpression);
        }

        public enum AlertType
        {
            [Description("Win Alert")]
            Win,
            [Description("1 Hour Alert")]
            Reminder1Hour,
            [Description("12 Hour Alert")]
            Reminder12Hours
        }

        protected void submitmybid(object sender, EventArgs e)
        {
            using (var ds = new ASEntities())
            {
                var biddref = bookId.Value;
                var mybid = inputbid.Value;
                var bid =
                        ds.AuctionSearch.First(
                            x =>
                                x.AccountID == DefaultView.GoDaddyAccount.AccountID &&
                                x.AuctionRef == biddref);

                var enddate = new GoDaddyAuctions().GetEndDate(biddref);
                var linkedRuid = Guid.NewGuid();
                var auction = new Auctions
                {
                    AuctionID = linkedRuid,
                    AuctionRef = bid.AuctionRef,
                    DomainName = bid.DomainName,
                    BidCount = bid.BidCount,
                    Traffic = bid.Traffic,
                    Valuation = bid.Valuation,
                    Price = bid.Price,
                    MinBid = bid.MinBid,
                    MinOffer = bid.MinOffer,
                    BuyItNow = bid.BuyItNow,
                    EndDate = enddate,
                    EstimateEndDate = bid.EstimateEndDate,
                    AccountID = bid.AccountID,
                    Status = bid.Status,
                    MyBid = int.Parse(mybid)
                };
                var toRemove = ds.Auctions.FirstOrDefault(x => x.AccountID == DefaultView.GoDaddyAccount.AccountID && x.AuctionRef == biddref);
                if (toRemove != null)
                {
                    ds.Auctions.Remove(toRemove);
                }
                ds.Auctions.AddOrUpdate(auction);
                ds.SaveChanges();

                var item = new AuctionHistory
                {
                    HistoryID = Guid.NewGuid(),
                    Text = "Auction Added",
                    CreatedDate = DefaultView.GetPacificTime,
                    AuctionLink = auction.AuctionID
                };
                ds.AuctionHistory.Add(item);

                var winalert = new Alerts
                {
                    AuctionID = auction.AuctionID,
                    Custom = false,
                    Description = "WIN ALERT",
                    TriggerTime = auction.EndDate.AddMinutes(5),
                    Type = AlertType.Win.ToDescription()
                };
                ds.Alerts.Add(winalert);

                var bidalert = new Alerts
                {
                    AlertID = Guid.NewGuid(),
                    AuctionID = auction.AuctionID,
                    Custom = false,
                    Description = "12 Hour Alert",
                    TriggerTime = auction.EndDate.AddHours(-12),
                    Type = AlertType.Reminder12Hours.ToDescription()
                };
                ds.Alerts.Add(bidalert);

                var bidalert2 = new Alerts
                {
                    AlertID = Guid.NewGuid(),
                    AuctionID = auction.AuctionID,
                    Custom = false,
                    Description = "1 Hour Alert",
                    TriggerTime = auction.EndDate.AddHours(-1),
                    Type = AlertType.Reminder1Hour.ToDescription()
                };
                ds.Alerts.Add(bidalert2);
                ds.SaveChanges();
            }
            Response.Redirect("Bids.aspx");
        }
    }
}