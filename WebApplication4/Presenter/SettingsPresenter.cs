using System.Web.UI;
using ASEntityFramework;
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
    }
}