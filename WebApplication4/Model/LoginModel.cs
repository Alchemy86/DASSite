using System;
using System.Data.Entity.Migrations;
using System.Linq;
using ASEntityFramework;
using WebApplication4.LunchboxAPI;

namespace WebApplication4.Model
{
    public class LoginModel : ILoginModel
    {
        protected DomainAuctionSniperAPI DasApi { get; private set; }
        protected ASEntities Ds { get; private set; }

        public LoginModel()
        {
            DasApi = new DomainAuctionSniperAPI();
            Ds = new ASEntities();
        }

        /// <summary>
        /// Login to the app
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            if ((DasApi.LoginWP(username, password) != "MATCHED")) return false;
            var account = Ds.Users.FirstOrDefault(x => x.Username == username);
            if (account == null)
            {
                account = new Users { Username = username, Password = password };
                Ds.Users.Add(account);
                Ds.SaveChanges();
            }

            var accessLevel = DasApi.GetAccessLevel(username, password);
            if (DasApi.GetAccessLevel(username, password) == "FAILED") return false;
            if (accessLevel.Contains("administrator"))
            {
                account.AccessLevel = 10;
            }
            else
            {
                account.AccessLevel = 1;
            }
            account.Password = password;
            Ds.Users.AddOrUpdate(account);
            Ds.SaveChanges();


            return true;
        }
    }
}