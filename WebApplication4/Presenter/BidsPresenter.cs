using System;
using System.Linq;
using DAL;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class BidsPresenter
    {
        public IBidsView View;
        public BidsModel Model;
        public IDefaultView DefaultView;

        public BidsPresenter(IBidsView view, IDefaultView defaultView)
        {
            View = view;
            DefaultView = defaultView;
            Model = new BidsModel(DefaultView.GoDaddyAccount, defaultView);
        }

        public void DeleteAuction(Guid auctionRef)
        {
            Model.DeleteAuction(auctionRef);
        }

        public void UpdateAuction(Guid auctionRef, string mybid)
        {
            Model.UpdateAuctionBid(auctionRef, mybid);
        }

        public IQueryable<Auctions> LoadAuctions()
        {
            return Model.GetAuctions();
        }

        public IQueryable<AuctionHistoryView> LoadAuctionHistory(Auctions auction)
        {
            return Model.GetAuctionHistory(auction);
        }

        public string GetDomain(Guid auctionRef)
        {
            return Model.GetDomain(auctionRef);
        }
    }
}