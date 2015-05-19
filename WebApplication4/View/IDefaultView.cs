using ASEntityFramework;

namespace WebApplication4.View
{
    public interface IDefaultView
    {
        Users UserAccount { get; }
        GoDaddyAccount GoDaddyAccount { get; set; }

        string Username { get;  }
        string BugMessage { get; set; }

        bool AccountVerified { get; }
        bool DisplayAccountVerification { get; set; }
    }
}
