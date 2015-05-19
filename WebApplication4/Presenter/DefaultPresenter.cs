using ASEntityFramework;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class DefaultPresenter
    {
        protected IDefaultView View;
        protected IDefaultModel Model;

        public DefaultPresenter(IDefaultView view)
        {
            View = view;
            Model = new DefaultModel();
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

    }
}