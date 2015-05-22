using ASEntityFramework;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class DefaultPresenter
    {
        public IDefaultView View;
        private IDefaultModel Model;

        public DefaultPresenter(IDefaultView view)
        {
            View = view;
            Model = new DefaultModel();
        }

        public Users GetUser()
        {
            return Model.GetUser(View.Username);
        }
            
        public GoDaddyActions GdHelper()
        {
            return View.GdHelper;
        }

        public GoDaddyAccount GetGoDaddyAccount(Users user)
        {
            return Model.GetGoDaddyAccount(user);
        }

        public bool SubmitBug()
        {
            return Model.SubmitBug(View.UserAccount, View.BugMessage);
        }

        public void SaveSettings(Users user)
        {
            Model.SaveSettings(user);
        }

        public void SaveGoDaddyAccount(GoDaddyAccount account)
        {
            Model.SaveGodaddyAccount(account);
        }

        public bool ValidateGodaddy(string username = null, string password = null)
        {
            return View.GdHelper.ValidateCredentials(username ?? View.GoDaddyAccount.GoDaddyUsername, 
                password ?? View.GoDaddyAccount.GoDaddyPassword, true);
        }

    }
}