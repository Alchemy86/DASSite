using ASEntityFramework;

namespace WebApplication4.Model
{
    public interface IDefaultModel
    {
        void Logout();
        bool SubmitBug(Users user, string message);
        Users GetUser(string username);
        GoDaddyAccount GetGoDaddyAccount(Users user);
    }
}
