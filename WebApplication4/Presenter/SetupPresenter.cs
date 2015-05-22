using AuctionSniperDLL.Business.Sites;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class SetupPresenter
    {
        protected ISetupView View;
        protected SetupModel Model;
        protected GoDaddyAuctions2Cs GoDaddy;

        public SetupPresenter(ISetupView view)
        {
            View = view;
            GoDaddy = new GoDaddyAuctions2Cs();
            Model = new SetupModel();
        }

        private void CreateGoDaddyAccount()
        {
            Model.CreateGoDaddyAccount(View.DefaultView.UserAccount, View.GoDaddyUsername, View.GoDaddyPassword);
        }

        public bool ValidateGodaddy(bool tryonce = false)
        {
            if (!GoDaddy.Login(View.GoDaddyUsername, View.GoDaddyPassword, tryonce ? 3 : 0)) return false;
            CreateGoDaddyAccount();
            return true;
        }
    }
}