using AuctionSniperDLL.Business.Sites;

namespace WebApplication4
{
    public interface IGoDaddyActions
    {
        GoDaddyAuctions2Cs GoDaddyApi { get; }
        bool ValidateCredentials(string username, string password, bool tryonce);
    }
}
