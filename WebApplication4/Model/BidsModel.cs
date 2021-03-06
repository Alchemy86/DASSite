﻿using System;
using System.Linq;
using DAL;
using WebApplication4.View;

namespace WebApplication4.Model
{
    public class BidsModel : IBidsModel
    {
        protected ASEntities Ds { get; private set; }
        private GoDaddyAccount Account;
        private IDefaultView DefaultView;

        public BidsModel(GoDaddyAccount account, IDefaultView defaultView)
        {
            DefaultView = defaultView;
            Ds = new ASEntities();
            Account = account;
        }

        public string GetDomain(Guid auctionRef)
        {
            var domain = Ds.Auctions.First(x => x.AuctionID == auctionRef && x.AccountID == Account.AccountID).DomainName;
            return domain;
        }

        public IQueryable<Auctions> GetAuctions()
        {
            return Ds.Auctions.Where(x => x.AccountID == Account.AccountID).ToList().AsQueryable();
        }

        public IQueryable<Auctions> GetHistoricAuctions()
        {
            var currentDate = DefaultView.GetPacificTime;
            return Ds.Auctions.Where(x => x.AccountID == Account.AccountID && x.EndDate < currentDate).ToList().AsQueryable();
        }
            
        public IQueryable<AuctionHistoryView> GetAuctionHistory(Auctions auction)
        {
            return Ds.AuctionHistoryView.Where(x => x.AuctionLink == auction.AuctionID).ToList().AsQueryable();
        }

        public void DeleteAuction(Guid auctionRef)
        {
            if (Ds.Alerts.Any(x => x.AuctionID == auctionRef))
            {
                Ds.Alerts.RemoveRange(Ds.Alerts.Where(x => x.AuctionID == auctionRef));
            }
            Ds.Auctions.Remove(Ds.Auctions.First(x => x.AuctionID == auctionRef && x.AccountID == Account.AccountID));
            Ds.SaveChanges();
        }

        public void UpdateAuctionBid(Guid auctionRef, string bidValue)
        {
            Ds.Auctions.First(x => x.AuctionID == auctionRef && x.AccountID == Account.AccountID).MyBid = Int32.Parse(bidValue);
            Ds.SaveChanges();
        }
    }
}