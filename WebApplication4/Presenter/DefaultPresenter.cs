using ASEntityFramework;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class DefaultPresenter
    {
        private IDefaultView view;
        private IDefaultModel model;

        public DefaultPresenter(IDefaultView view)
        {
            this.view = view;
            model = new DefaultModel();
        }

        public Users GetUser()
        {
            return model.GetUser(view.Username);
        }

        public bool SubmitBug()
        {
            return model.SubmitBug(view.UserAccount, view.BugMessage);
        }


    }
}