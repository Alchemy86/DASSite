using System.Linq;
using DAL;
using DAS.Domain.Users;
using GoDaddy;
using WebApplication4.View;

namespace WebApplication4
{
    public class GoDaddyActions : IGoDaddyActions
    {
        private GoDaddyAuctionSniper GodaddyAuctions;

        public GoDaddyAuctionSniper GoDaddyApi
        {
            get { return GodaddyAuctions; }
        }

        private IDefaultView DefaultView;

        public GoDaddyActions(string username, IDefaultView defaultView, IUserRepository userRepo)
        {
            DefaultView = defaultView;
            GodaddyAuctions = new GoDaddy.GoDaddyAuctionSniper(username, userRepo);
        }

        /// <summary>
        /// Test credentials for godaddy
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="tryonce">attempt once - else 3 times for failures</param>
        /// <returns></returns>
        public bool ValidateCredentials(string username, string password, bool tryonce = false)
        {
            return GoDaddyApi.Login(tryonce ? 3 : 0, username, password);
        }

        /// <summary>
        /// Perform a search
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="numerofresults"></param>
        /// <returns></returns>
        public IQueryable<AuctionSearch> Search(string searchText, int numerofresults)
        {
            var results = GoDaddyApi.Search(searchText).Take(50);
            using (var ds = new ASEntities())
            {
                var search = ds.AuctionSearch.Where(x => x.AccountID == DefaultView.GoDaddyAccount.AccountID).ToList();
                foreach (var auctionSearch in search)
                {
                    ds.AuctionSearch.Remove(auctionSearch);
                }
                foreach (var auctionSearch in results)
                {
                    auctionSearch.AccountID = DefaultView.GoDaddyAccount.AccountID;
                }
                ds.AuctionSearch.AddRange(results);
                ds.SaveChanges();
            }
            
            return results;
        }


        public IQueryable<AuctionSearch> ListLastSearch()
        {
            return null;
        }
    }
}