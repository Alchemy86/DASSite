namespace WebApplication4.View
{
    public interface ISettingsView
    {
        bool ReceiveEmails { get; set; }
        string GoDaddyUsername { get; }
        string GoDaddyPassword { get; }
    }
}
