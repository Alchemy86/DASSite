using System.Linq;
using DAL;
using GoDaddy;

namespace WebApplication4
{
    public interface IGoDaddyActions
    {
        GoDaddyAuctionSniper GoDaddyApi { get; }
        bool ValidateCredentials(string username, string password, bool tryonce);
        IQueryable<AuctionSearch> Search(string searchText, int numerofresults);
        IQueryable<AuctionSearch> ListLastSearch();
    }
}
