using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class SetupPresenter
    {
        protected ISetupView View;

        public SetupPresenter(ISetupView view)
        {
            View = view;
        }

        public void CreateGoDaddyAccount()
        {
            var model = new SetupModel();
            model.CreateGoDaddyAccount(View.DefaultView.UserAccount, View.GoDaddyUsername, View.GoDaddyPassword);
        }
    }
}