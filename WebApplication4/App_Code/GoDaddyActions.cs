using System.Linq;
using System.Web.Management;
using ASEntityFramework;
using AuctionSniperDLL.Business.Sites;
using WebApplication4.View;

namespace WebApplication4
{
    public class GoDaddyActions : IGoDaddyActions
    {
        public GoDaddyAuctions2Cs GoDaddyApi
        {
            get { return new GoDaddyAuctions2Cs(); }
        }

        private IDefaultView DefaultView;

        public GoDaddyActions(IDefaultView defaultView)
        {
            DefaultView = defaultView;
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
            return GoDaddyApi.Login(username, password, tryonce ? 3 : 0);
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


        public IQueryable<ASEntityFramework.AuctionSearch> ListLastSearch()
        {
            return null;
        }
    }
}