using AuctionSniperDLL.Business.Sites;
using WebApplication4.App_Code;

namespace WebApplication4
{
    public class GoDaddyActions : IGoDaddyActions
    {
        public GoDaddyAuctions2Cs GoDaddyApi
        {
            get { return new GoDaddyAuctions2Cs(); }
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

    }
}