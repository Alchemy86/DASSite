using System.Data.Entity.Migrations;
using System.Linq;
using ASEntityFramework;
using LunchboxSource.Business.SiteObject.GoDaddy;

namespace WebApplication4.Model
{
    public class MultibidModel
    {
        protected ASEntities Ds { get; private set; }

        public MultibidModel()
        {
            Ds = new ASEntities();
        }

        public IQueryable<AuctionSearch> GetSearchResults(GoDaddyAccount account)
        {   
            return Ds.AuctionSearch.Where(x => x.AccountID == account.AccountID).ToList().AsQueryable();
        }
            
        public void SaveSearchResults(IQueryable<AuctionSearch> results, GoDaddyAccount account)
        {
            Ds.AuctionSearch.RemoveRange(GetSearchResults(account));
            foreach (var item in results)
            {
                item.AccountID = account.AccountID;
            }
            Ds.AuctionSearch.AddRange(results);
            Ds.SaveChanges();
        }

        public void AddOrUpdateBid(Auctions auction)
        {
            Ds.Auctions.AddOrUpdate(auction);
            Ds.SaveChanges();
        }

        public void AddAuctionHistory(AuctionHistory item)
        {
            Ds.AuctionHistory.AddOrUpdate(item);
            Ds.SaveChanges();
        }

        public void AddAlert(Alerts item)
        {
            Ds.Alerts.AddOrUpdate(item);
            Ds.SaveChanges();
        }

    }
}