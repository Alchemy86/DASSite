using System;
using System.Linq;
using ASEntityFramework;
using WebApplication4.LunchboxAPI;

namespace WebApplication4.Model
{
    public class DefaultModel : IDefaultModel
    {
        protected DomainAuctionSniperAPI DasApi { get; private set; }
        protected ASEntities Ds { get; private set; }

        public DefaultModel()
        {
            DasApi = new DomainAuctionSniperAPI();
            Ds = new ASEntities();
        }

        public void Logout()
        {
            
        }

        /// <summary>
        /// Send a report
        /// </summary>
        /// <param name="user">Username</param>
        /// <param name="message">report message</param>
        /// <returns></returns>
        public bool SubmitBug(Users user, string message)
        {
            if (user == null)
            {
                throw new Exception("User cannot be null");
            }
            DasApi.Email(AppConfig.GetSystemConfig(AppSettings.AlertEmail), "Bug Report",
                                 "Account: " + user.Username +  Environment.NewLine +
                                 "Description: " + message, "Service Manager Bug Report");

            return true;
        }

        /// <summary>
        /// Get the user account from their unique login
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        public Users GetUser(string username)
        {
            return Ds.Users.First(x => x.Username == username);
        }

        /// <summary>
        /// Get the users godaddy account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public GoDaddyAccount GetGoDaddyAccount(Users user)
        {
            return user.GoDaddyAccount.FirstOrDefault() ?? new GoDaddyAccount();
        }
    }
}