using ASEntityFramework;

namespace WebApplication4.Model
{
    public class SetupModel : ISetupModel
    {

        public void CreateGoDaddyAccount(Users user, string username, string password)
        {
            using (var ds = new ASEntities())
            {
                ds.GoDaddyAccount.Add(new GoDaddyAccount{GoDaddyUsername = username, GoDaddyPassword = password, UserID = user.UserID, Verified = true});
                ds.SaveChanges();
            }
        }


        public void DeleteGoDaddyAccount(Users account)
        {
            account.GoDaddyAccount.Clear();
        }


        public void Save(Users user)
        {
            using (var ds = new ASEntities())
            {
                ds.Users.Attach(user);
                ds.SaveChanges();
            }
        }
    }
}