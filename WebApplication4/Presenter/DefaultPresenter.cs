using System;
using System.Collections.Generic;
using ASEntityFramework;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class DefaultPresenter
    {
        public IDefaultView View;
        private IDefaultModel Model;
        public IGoDaddyActions GoDaddyActions;

        public DefaultPresenter(IDefaultView view)
        {
            View = view;
            Model = new DefaultModel();
            GoDaddyActions = new GoDaddyActions(view);
        }

        public Users GetUser()
        {
            return Model.GetUser(View.Username);
        }
            
        public GoDaddyActions GdHelper()
        {
            return View.GdHelper;
        }

        public GoDaddyAccount GetGoDaddyAccount(Users user)
        {
            return Model.GetGoDaddyAccount(user);
        }

        public string GetMyBidCount()
        {
            return Model.GetMyBidCount(View.GoDaddyAccount);
        }

        public bool SubmitBug()
        {
            return Model.SubmitBug(View.UserAccount, View.BugMessage);
        }

        public void SaveSettings(Users user)
        {
            Model.SaveSettings(user);
        }

        public void SaveGoDaddyAccount(GoDaddyAccount account)
        {
            Model.SaveGodaddyAccount(account);
        }

        public bool ValidateGodaddy(string username = null, string password = null)
        {
            return View.GdHelper.ValidateCredentials(username ?? View.GoDaddyAccount.GoDaddyUsername, 
                password ?? View.GoDaddyAccount.GoDaddyPassword, true);
        }

        public bool CheckIfWon(Dictionary<Guid, string> domain)
        {
            var items = new List<Dictionary<Guid, string>> { domain };
            return CheckIfWon(items, true);
        }

        public bool CheckIfWon(List<Dictionary<Guid, string>> domain, bool single)
        {
            if (!View.GdHelper.GoDaddyApi.LoggedIn())
            {
                View.GdHelper.ValidateCredentials(View.GoDaddyAccount.GoDaddyUsername,View.GoDaddyAccount.GoDaddyPassword, true);
            }
            if (!View.GdHelper.GoDaddyApi.LoggedIn())
            {
                return false;
            }
            foreach (var items in domain)
            {
                foreach (KeyValuePair<Guid, string> dom in items)
                {
                    if (View.GdHelper.GoDaddyApi.WinCheck(dom.Value))
                    {
                        using (var ds = new ASEntities())
                        {
                            var item2 = new AuctionHistory
                            {
                                HistoryID = Guid.NewGuid(),
                                Text = "Auction WON",
                                CreatedDate = View.GetPacificTime,
                                AuctionLink = dom.Key
                            };
                            ds.AuctionHistory.Add(item2);
                            ds.SaveChanges();
                        }
                        if (single)
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }
    }
}