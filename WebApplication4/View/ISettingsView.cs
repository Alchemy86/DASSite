namespace WebApplication4.View
{
    public interface ISettingsView
    {
        bool ReceiveEmails { get; set; }
        bool UseAccountForSearch { get; set; }
        string GoDaddyUsername { get; }
        string GoDaddyPassword { get; }
    }
}
