using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class LoginPresenter
    {
        protected ILoginView View;
        protected LoginModel Model;

        public LoginPresenter(ILoginView view)
        {
            View = view;
            Model = new LoginModel();
        }

        public bool Login()
        {
            return Model.Login(View.UserName, View.Password);
        }

    }
}