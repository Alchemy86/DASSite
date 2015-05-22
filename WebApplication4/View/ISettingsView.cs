using WebApplication4.Presenter;

namespace WebApplication4.View
{
    public interface ISettingsView
    {
        DefaultPresenter DefaultPresenter { get; }
        bool ReceiveEmails { get; set; }
        string GoDaddyUsername { get; }
        string GoDaddyPassword { get; }
    }
}
