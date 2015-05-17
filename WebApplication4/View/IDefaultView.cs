using ASEntityFramework;

namespace WebApplication4.View
{
    public interface IDefaultView
    {
        Users UserAccount { get; }
        string Username { get;  }
        string BugMessage { get; }
    }
}
