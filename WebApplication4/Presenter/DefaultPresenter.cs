using ASEntityFramework;
using AuctionSniperDLL.Business.Sites;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class DefaultPresenter
    {
        protected IDefaultView View;
        protected IDefaultModel Model;
        protected GoDaddyAuctions2Cs GoDaddy;

        public DefaultPresenter(IDefaultView view)
        {
            View = view;
            Model = new DefaultModel();
            GoDaddy = new GoDaddyAuctions2Cs();
        }

        public Users GetUser()
        {
            return Model.GetUser(View.Username);
        }

        public GoDaddyAccount GetGoDaddyAccount(Users user)
        {
            return Model.GetGoDaddyAccount(user);
        }

        public bool SubmitBug()
        {
            return Model.SubmitBug(View.UserAccount, View.BugMessage);
        }

        public bool ValidateGodaddy(GoDaddyAccount account)
        {
            return GoDaddy.Login(account.GoDaddyUsername, account.GoDaddyPassword);
        }

    }
}