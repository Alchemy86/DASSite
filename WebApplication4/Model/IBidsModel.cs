using System;
using System.Linq;
using DAL;

namespace WebApplication4.Model
{
    public interface IBidsModel
    {
        IQueryable<Auctions> GetAuctions();
        void DeleteAuction(Guid auctionRef);
        void UpdateAuctionBid(Guid auctionRef, string bidValue);
        string GetDomain(Guid auctionRef);
    }
}
