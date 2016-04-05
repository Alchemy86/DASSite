using DAL;

namespace WebApplication4.Model
{
    public interface IDefaultModel
    {
        void Logout();
        void SaveSettings(Users user);
        void SaveGodaddyAccount(GoDaddyAccount account);
        bool SubmitBug(Users user, string message);

        Users GetUser(string username);
        GoDaddyAccount GetGoDaddyAccount(Users user);
        string GetMyBidCount(GoDaddyAccount account);

    }
}
