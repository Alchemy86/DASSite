using DAS.Domain.Users;
using GoDaddy;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class SetupPresenter
    {
        protected ISetupView View;
        protected SetupModel Model;
        protected GoDaddyAuctionSniper GoDaddy;

        public SetupPresenter(ISetupView view, IUserRepository userRepo)
        {
            View = view;
            GoDaddy = new GoDaddyAuctionSniper(View.DefaultView.UserAccount.Username, userRepo);
            Model = new SetupModel();
        }

        private void CreateGoDaddyAccount()
        {
            Model.CreateGoDaddyAccount(View.DefaultView.UserAccount, View.GoDaddyUsername, View.GoDaddyPassword);
        }

        public bool ValidateGodaddy(bool tryonce = false)
        {
            if (!GoDaddy.Login(tryonce ? 3 : 0)) return false;
            CreateGoDaddyAccount();
            return true;
        }
    }
}