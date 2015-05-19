using System.Data.Entity.Migrations;
using ASEntityFramework;

namespace WebApplication4.Model
{
    public class SetupModel : ISetupModel
    {

        public void CreateGoDaddyAccount(Users user, string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return;
            }
            using (var ds = new ASEntities())
            {
                ds.GoDaddyAccount.AddOrUpdate(x=>x.GoDaddyUsername, new GoDaddyAccount
                {
                    GoDaddyUsername = username, 
                    GoDaddyPassword = password, UserID = user.UserID
                });
                ds.Users.AddOrUpdate(user);
                ds.SaveChanges();
            }
        }
    }
}