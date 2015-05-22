using ASEntityFramework;
using AuctionSniperDLL.Business.Sites;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class SettingsPresenter
    {
        protected ISettingsView View;

        public SettingsPresenter(ISettingsView view)
        {
            View = view;
        }

        public void SaveSettings(Users account)
        {
            View.DefaultPresenter.SaveSettings(account);
        }

        public bool ValidateGodaddy()
        {
            return View.DefaultPresenter.ValidateGodaddy(View.GoDaddyUsername, View.GoDaddyPassword);
        }
    }
}