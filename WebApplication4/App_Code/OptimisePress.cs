using WebApplication4.LunchboxAPI;

namespace WebApplication4
{
    public static class OptimisePress
    {
        public static bool LoginWp(string username, string password)
        {
            var api = new DomainAuctionSniperAPI();
            if ((api.LoginWP(username, password) == "MATCHED"))
            {
                return true;
            }

            return false;
        }
    }
}