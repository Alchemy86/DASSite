using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class LoginPresenter
    {
        private ILoginView view;
        private LoginModel model;

        public LoginPresenter(ILoginView view)
        {
            this.view = view;
            model = new LoginModel();
        }

        public bool Login()
        {
            return model.Login(view.UserName, view.Password);
        }

    }
}