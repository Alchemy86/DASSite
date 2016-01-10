using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASEntityFramework;
using LunchboxWebControls;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class MultibidPresenter
    {
        protected IMultibidView View;
        protected MultibidModel Model;
        public IDefaultView DefaultView;

        public MultibidPresenter(IMultibidView view, IDefaultView defaultview)
        {
            View = view;
            DefaultView = defaultview;
            Model = new MultibidModel();
        }

        public IQueryable<AuctionSearch> SearchResults()
        {
            return Model.GetSearchResults(DefaultView.GoDaddyAccount);
        }

        public void SetSearchResults(IQueryable<AuctionSearch> results)
        {
            Model.SaveSearchResults(results, DefaultView.GoDaddyAccount);
        }

        public IQueryable<AuctionSearch> Search(string searchText)
        {
            SetSearchResults(DefaultView.GdHelper.GoDaddyApi.Search(searchText.Replace("http://", "").Replace("www.", "")));
            return SearchResults();
        }

        public void GenerateBids(LunchboxGridView grid, int bidvalue)
        {
            foreach (GridViewRow auc in grid.Rows)
            {
                var myminbid = int.Parse(((TextBox)auc.FindControl("bidvalue")).Text == "" ? "0" : ((TextBox)auc.FindControl("bidvalue")).Text);
                var auctionRef = auc.Cells[1].Text;

                var bid = SearchResults().First(x => x.AuctionRef == auctionRef);

                var enddate = DefaultView.GdHelper.GoDaddyApi.GetEndDate(bid.AuctionRef);
                var auction = new Auctions
                {
                    AuctionID = Guid.NewGuid(),
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
                    MyBid = myminbid == 0 ? bidvalue : myminbid
                };

                Model.AddOrUpdateBid(auction);
                Model.AddAuctionHistory(new AuctionHistory
                {
                    HistoryID = Guid.NewGuid(),
                    Text = "Auction Added",
                    CreatedDate = DefaultView.GetPacificTime,
                    AuctionLink = auction.AuctionID
                });

                Model.AddAlert(new Alerts
                {
                    AuctionID = auction.AuctionID,
                    Custom = false,
                    Description = "WIN ALERT",
                    TriggerTime = auction.EndDate.AddMinutes(5),
                    Type = "WIN ALERT"
                });

                Model.AddAlert(new Alerts
                {
                    AlertID = Guid.NewGuid(),
                    AuctionID = auction.AuctionID,
                    Custom = false,
                    Description = "12 Hour Alert",
                    TriggerTime = auction.EndDate.AddHours(-12),
                    Type = "12 Hour Alert"
                });

                Model.AddAlert(new Alerts
                {
                    AlertID = Guid.NewGuid(),
                    AuctionID = auction.AuctionID,
                    Custom = false,
                    Description = "1 Hour Alert",
                    TriggerTime = auction.EndDate.AddHours(-1),
                    Type = "1 Hour Alert"
                });
            }
        }

    }
}