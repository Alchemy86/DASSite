using ASEntityFramework;

namespace WebApplication4.Model
{
    public interface ISetupModel
    {
        void CreateGoDaddyAccount(Users user, string username, string password);
        void DeleteGoDaddyAccount(Users account);
        void Save(Users user);
    }
}
