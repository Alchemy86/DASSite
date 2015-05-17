using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASEntityFramework;
using AuctionSniperDLL.Business.Sites;
using AuctionSniperService.Business.Sites;
using LunchboxWebControls;
using WebApplication4.LunchboxAPI;

namespace WebApplication4
{
    public partial class index : Page
    {   
        DomainAuctionSniperAPI API = new DomainAuctionSniperAPI();
        DomCop DCop = new DomCop(); 

        private GoDaddyAuctions2Cs GoDaddy = new GoDaddyAuctions2Cs();

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        private void CreateCookie(string name, string value)
        {
            //create a cookie
            var myCookie = new HttpCookie("DASmembers");
            myCookie.Values.Add(name, value);
            myCookie.Expires = DateTime.Now.AddHours(12);
            Response.Cookies.Add(myCookie);
        }

        public bool AdvSearchAccess
        {
            get
            {
                if (Session["AdvAccess"] != null)
                {
                    return (bool)Session["AdvAccess"];
                }
                Session["AdvAccess"] = Account.AccessLevel > 1;
                return (bool)Session["AdvAccess"];
            }
        }

        public bool SearchAll
        {
            get
            {
                if (Session["SearchAll"] != null)
                {
                    return (bool)Session["SearchAll"];
                }
                Session["SearchAll"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["SearchAll"];
            }
            set
            {
                Session["SearchAll"] = value;
            }
        }

        public bool SearchAuction
        {
            get
            {
                if (Session["SearchAuction"] != null)
                {
                    return (bool)Session["SearchAuction"];
                }
                Session["SearchAuction"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["SearchAuction"];
            }
            set
            {
                Session["SearchAuction"] = value;
            }
        }

        public bool SearchBuyNow
        {
            get
            {
                if (Session["SearchBuyNow"] != null)
                {
                    return (bool)Session["SearchBuyNow"];
                }
                Session["SearchBuyNow"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["SearchBuyNow"];
            }
            set
            {
                Session["SearchBuyNow"] = value;
            }
        }

        public bool SearchCloseout
        {
            get
            {
                if (Session["SearchCloseout"] != null)
                {
                    return (bool)Session["SearchCloseout"];
                }
                Session["SearchCloseout"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["SearchCloseout"];
            }
            set
            {
                Session["SearchCloseout"] = value;
            }
        }

        public bool SearchOffer
        {
            get
            {
                if (Session["SearchOffer"] != null)
                {
                    return (bool)Session["SearchOffer"];
                }
                Session["SearchOffer"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["SearchOffer"];
            }
            set
            {
                Session["SearchOffer"] = value;
            }
        }

        public bool SearchPendingDelete
        {
            get
            {
                if (Session["SearchPendingDelete"] != null)
                {
                    return (bool)Session["SearchPendingDelete"];
                }
                Session["SearchPendingDelete"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["SearchPendingDelete"];
            }
            set
            {
                Session["SearchPendingDelete"] = value;
            }
        }   

        public bool SearchBarginBin
        {
            get
            {
                if (Session["BarginBin"] != null)
                {
                    return (bool)Session["BarginBin"];
                }
                Session["BarginBin"] = btnSearchAll.Attributes["class"].Contains("active");
                return (bool)Session["BarginBin"];
            }
            set
            {
                Session["BarginBin"] = value;
            }
        }

        public Users Account
        {
            get
            {
                if (Session["Account"] != null)
                {
                    return (Users)Session["Account"];
                }
                Session["Account"] = new ASEntities().Users.First(x => x.Username == Context.User.Identity.Name);
                return (Users)Session["Account"];
            }
        }

        public bool UseAdvancedSearch
        {
            get
            {
                if (Session["UseAdvancedSearch"] != null)
                {
                    return (bool)Session["UseAdvancedSearch"];
                }
                Session["UseAdvancedSearch"] = true;
                return (bool)Session["UseAdvancedSearch"];
            }
            set
            {
                Session["UseAdvancedSearch"] = value;
            }
        }
                
        public GoDaddyAccount GdAccount
        {
            get
            {
                if (Session["GodaddyAccount"] != null)
                {
                    return (GoDaddyAccount)Session["GodaddyAccount"];
                }
                Session["GodaddyAccount"] = new ASEntities().GoDaddyAccount.FirstOrDefault(x => x.UserID == Account.UserID);
                return (GoDaddyAccount)Session["GodaddyAccount"];
            }
        }

        public IQueryable<AuctionSearch> SearchResults
        {
            get
            {
                //if (Session["SearchResults"] != null)
                //{
                //    return (IQueryable<AuctionSearch>)Session["SearchResults"];
                //}
                return new ASEntities().AuctionSearch.Where(x => x.AccountID == GdAccount.AccountID).ToList().AsQueryable();
                //return (IQueryable<AuctionSearch>)Session["SearchResults"];
            }
            set
            {
                using (var ds = new ASEntities())
                {
                    var search = ds.AuctionSearch.Where(x => x.AccountID == GdAccount.AccountID).ToList();
                    foreach (var auctionSearch in search)
                    {
                        ds.AuctionSearch.Remove(auctionSearch);
                    }
                    foreach (var auctionSearch in value)
                    {
                        auctionSearch.AccountID = GdAccount.AccountID;
                    }
                    ds.AuctionSearch.AddRange(value);
                    ds.SaveChanges();
                }
            }
        }

        protected void Signout_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "$(document).ready(function(){EnableControls();alert('Overrides successfully Updated.');DisableControls();});", true);

            FormsAuthentication.SignOut();
            Response.Redirect("~/LoginPage.aspx");
        }

        protected void verify_click(object sender, EventArgs e)
        {   
            Response.Redirect("Default.aspx#settings");
        }


        private void SetupAdv()
        {
            if (AdvSearchAccess)
            {
                cbAdvancedSeach.Checked = UseAdvancedSearch;
                if (SearchAll)
                {
                    btnSearchAll.Attributes["class"] = SearchAll ? "btn btn-default active" : "btn btn-default ";
                }
                else
                {
                    btnSearchAuction.Attributes["class"] = SearchAuction ? "btn btn-default active" : "btn btn-default ";
                    btnSearchBuyNow.Attributes["class"] = SearchBuyNow ? "btn btn-default active" : "btn btn-default ";
                    btnSearchCloseOut.Attributes["class"] = SearchCloseout ? "btn btn-default active" : "btn btn-default ";
                    btnSearchOffer.Attributes["class"] = SearchOffer ? "btn btn-default active" : "btn btn-default ";
                    btnSearchPendingDelete.Attributes["class"] = SearchPendingDelete ? "btn btn-default active" : "btn btn-default ";
                    btnBarginBin.Attributes["class"] = SearchBarginBin ? "btn btn-default active" : "btn btn-default ";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = @"Auction Sniper WEB";
            Welcome.Text = @"Hello, " + Context.User.Identity.Name + @"    ";
            if (IsPostBack)
            {
                SaveSearchSettings();
                SetSearchValues();
            }
            SetSearchValues();
            //FixHiddenValues();

            if (!IsPostBack)
            {
                LoadSavedSearchs();
                SetupAdv();
                if (Request.QueryString["redirect"] != null)
                {
                    Response.Redirect("Default.aspx#" + Request.QueryString["redirect"], true);
                }

                if (Request.QueryString["bookId"] != null && Request.QueryString["bidvalue"] != null)
                {
                    using (var ds = new ASEntities())
                    {
                        var biddref = Request.QueryString["bookId"];
                        var mybid = Request.QueryString["bidvalue"];
                        if (GdAccount != null)
                        {
                            var bid =
                                ds.AuctionSearch.First(
                                    x =>
                                        x.AccountID == GdAccount.AccountID &&
                                        x.AuctionRef == biddref);

                            var enddate = new GoDaddyAuctions().GetEndDate(biddref);
                            var linkedRuid = Guid.NewGuid();
                            var auction = new Auctions
                            {
                                AuctionID = linkedRuid,
                                AuctionRef = bid.AuctionRef,
                                DomainName = bid.DomainName,
                                BidCount = bid.BidCount,
                                Traffic = bid.Traffic,
                                Valuation = bid.Valuation,
                                Price = bid.Price,
                                MinBid = bid.MinBid,
                                MinOffer = bid.MinOffer,
                                BuyItNow = bid.BuyItNow,
                                EndDate = enddate,
                                EstimateEndDate = bid.EstimateEndDate,
                                AccountID = bid.AccountID,
                                Status = bid.Status,
                                MyBid = int.Parse(mybid)
                            };
                            var toRemove = ds.Auctions.FirstOrDefault(x => x.AccountID == GdAccount.AccountID && x.AuctionRef == biddref);
                            if (toRemove != null)
                            {
                                ds.Auctions.Remove(toRemove);
                            }
                            ds.Auctions.AddOrUpdate(auction);
                            ds.SaveChanges();

                            var item = new AuctionHistory
                            {
                                HistoryID = Guid.NewGuid(),
                                Text = "Auction Added",
                                CreatedDate = DateTime.Now,
                                AuctionLink = auction.AuctionID
                            };
                            ds.AuctionHistory.Add(item);

                            var winalert = new Alerts
                            {
                                AuctionID = auction.AuctionID,
                                Custom = false,
                                Description = "WIN ALERT",
                                TriggerTime = auction.EndDate.AddMinutes(5)
                            };
                            ds.Alerts.Add(winalert);

                            var bidalert = new Alerts
                            {
                                AlertID = Guid.NewGuid(),
                                AuctionID = auction.AuctionID,
                                Custom = false,
                                Description = "12 Hour Alert",
                                TriggerTime = auction.EndDate.AddHours(-12)
                            };
                            ds.Alerts.Add(bidalert);

                            var bidalert2 = new Alerts
                            {
                                AlertID = Guid.NewGuid(),
                                AuctionID = auction.AuctionID,
                                Custom = false,
                                Description = "1 Hour Alert",
                                TriggerTime = auction.EndDate.AddHours(-1)
                            };
                            ds.Alerts.Add(bidalert2);
                            ds.SaveChanges();
                        }
                    }
                    Response.Redirect("Default.aspx#mybids");

                }

            }

            LoadAuctions();
        }

        private void AddNewSearchConfig(Guid UserID, string Name, bool Active = true)
        {
            var sql = "INSERT INTO SearchConfig(UserID,Name,Active) VALUES(@P0,@P1,@P2)";
            var parameterList = new List<object>();
            parameterList.Add(UserID);
            parameterList.Add(Name);
            parameterList.Add(Active);
            object[] parameters1 = parameterList.ToArray();
            int result = new ASEntities()
                .Database.ExecuteSqlCommand(sql, parameters1);
        }

        private void LoadSavedSearchs()
        {
            using (var ds = new ASEntities())
            {

                if (!ds.SearchConfig.Any(x => x.UserID == Account.UserID))
                {
                    AddNewSearchConfig(Account.UserID, "Default");
                }

                var savedSearchs = ds.SearchConfig.Where(x => x.UserID == Account.UserID);
                foreach (var searchConfig in savedSearchs)
                {
                    DDLSavedSearchs.Items.Add(searchConfig.Name);
                }
                DDLSavedSearchs.SelectedValue = savedSearchs.First(x => x.Active).Name;
            }
            SetSearchValues();
        }

        private void SaveSearchSettings()
        {
            //if (int.Parse(MajesticBacklinksHiddenMin.Value) == 20 && int.Parse(CitationFlowHiddenMin.Value) == 20
            //    && int.Parse(MajesticTrustflowHiddenMin.Value) == 20 && int.Parse(MajesticTrustflowHiddenMax.Value) == 50
            //    && int.Parse(CitationFlowHiddenMax.Value) == 50)
            //{
            //    return;
            //}

            using (var ds = new ASEntities())
            {
                SetSearchValues();
                var activeSearch = ds.SearchConfig.FirstOrDefault(x => x.UserID == Account.UserID && x.Active);
                activeSearch.PRMin = int.Parse(PageRankHiddenMin.Value);
                activeSearch.PRMax = int.Parse(PageRankHiddenMax.Value);
                activeSearch.Keyword = txtSearch.Text.Replace(" ","+");

                activeSearch.DomainAgeMin = int.Parse(string.IsNullOrEmpty(DomainAgeHiddenMin.Value) ? activeSearch.DomainAgeMin.ToString(CultureInfo.InvariantCulture) : DomainAgeHiddenMin.Value);
                activeSearch.DomainAgeMax = int.Parse(string.IsNullOrEmpty(DomainAgeHiddenMax.Value) ? activeSearch.DomainAgeMax.ToString(CultureInfo.InvariantCulture) : DomainAgeHiddenMax.Value);

                activeSearch.DomainPriceMin = int.Parse(DomainPriceHiddenMin.Value);
                activeSearch.DomainPriceMax = int.Parse(DomainPriceHiddenMax.Value);

                activeSearch.MajesticTrustFlowMin = int.Parse(MajesticTrustflowHiddenMin.Value);
                activeSearch.MajesticTrustFlowMax = int.Parse(MajesticTrustflowHiddenMax.Value);

                activeSearch.MajesticIPSMin = int.Parse(MajesticIPSHiddenMin.Value);
                activeSearch.MajesticIPSMax = int.Parse(MajesticIPSHiddenMax.Value);

                activeSearch.MajesticCitationFlowMin = int.Parse(CitationFlowHiddenMin.Value);
                activeSearch.MajesticCitationFlowMax = int.Parse(CitationFlowHiddenMax.Value);

                activeSearch.MajesticBacklinksMin = int.Parse(MajesticBacklinksHiddenMin.Value);
                activeSearch.MajesticBacklinksMAX = int.Parse(MajesticBacklinksHiddenMax.Value);

                activeSearch.MOZDAMin = int.Parse(MOZDAHiddenMin.Value);
                activeSearch.MOZDAMax = int.Parse(MOZDAHiddenMax.Value);
                activeSearch.MOZPAMin = int.Parse(MOZPAHiddenMin.Value);
                activeSearch.MOZPAMax = int.Parse(MOZPAHiddenMax.Value);

                if (SearchAll)
                {
                    activeSearch.SalesTypeOffer = true;
                    activeSearch.BuyNow = true;
                    activeSearch.CloseOut = true;
                    activeSearch.Auction = true;
                    activeSearch.BarginBin = true;
                    activeSearch.PendingDelete = true;
                }
                else
                {
                    activeSearch.SalesTypeOffer = SearchOffer;
                    activeSearch.BuyNow = SearchBuyNow;
                    activeSearch.CloseOut = SearchCloseout;
                    activeSearch.Auction = SearchAuction;
                    activeSearch.BarginBin = SearchBarginBin;
                    activeSearch.PendingDelete = SearchPendingDelete;
                }

                if (HiddenStartsWith.Value == "true")
                {
                    activeSearch.KeywordSearchType = "starts";
                }
                else if (HiddenEndsWith.Value == "true")
                {
                    activeSearch.KeywordSearchType = "ends";
                }
                else if (HiddenContains.Value == "true")
                {
                    activeSearch.KeywordSearchType = "contains";
                }

                //Save domain endings
                activeSearch.end_asia = ends_asia.Checked;
                activeSearch.end_at = ends_at.Checked;
                activeSearch.end_au = ends_au.Checked;
                activeSearch.end_be = ends_be.Checked;
                activeSearch.end_biz = ends_biz.Checked;
                activeSearch.end_ca = ends_ca.Checked;
                activeSearch.end_cc = ends_cc.Checked;
                activeSearch.end_ch = ends_ch.Checked;
                activeSearch.end_co = ends_co.Checked;
                activeSearch.end_com = ends_com.Checked;
                activeSearch.end_de = ends_de.Checked;
                activeSearch.end_eu = ends_eu.Checked;
                activeSearch.end_fr = ends_fr.Checked;
                activeSearch.end_ie = ends_ie.Checked;
                activeSearch.end_in = ends_in.Checked;
                activeSearch.end_info = ends_info.Checked;
                activeSearch.end_it = ends_it.Checked;
                activeSearch.end_me = ends_me.Checked;
                activeSearch.end_misc = ends_misc.Checked;
                activeSearch.end_mobi = ends_mobi.Checked;
                activeSearch.end_mx = ends_mx.Checked;
                activeSearch.end_net = ends_net.Checked;
                activeSearch.end_nl = ends_nl.Checked;
                activeSearch.end_nu = ends_nu.Checked;
                activeSearch.end_org = ends_org.Checked;
                activeSearch.end_pl = ends_pl.Checked;
                activeSearch.end_ru = ends_ru.Checked;
                activeSearch.end_se = ends_se.Checked;
                activeSearch.end_su = ends_su.Checked;
                activeSearch.end_tv = ends_tv.Checked;
                activeSearch.end_uk = ends_uk.Checked;
                activeSearch.end_us = ends_us.Checked;

                activeSearch.Dynadot  = source_DynaDot.Checked;
                activeSearch.GoDaddy = source_GoDaddy.Checked;
                activeSearch.NameJet = source_NameJet.Checked;
                activeSearch.Sedo = source_Sedo.Checked;
                activeSearch.SnapName = source_SnapName.Checked;

                ds.SearchConfig.AddOrUpdate(activeSearch);
                ds.SaveChanges();
            }
        }

        public void SetSearchValues()
        {
            SearchConfig activeSearch;
            using (var ds = new ASEntities())
            {
                if (!ds.SearchConfig.Any(x => x.UserID == Account.UserID))
                {
                    AddNewSearchConfig(Account.UserID, "Default");
                }
                var account = ds.Users.First(x => x.Username == Context.User.Identity.Name);
                activeSearch = ds.SearchConfig.FirstOrDefault(x => x.UserID == account.UserID && x.Active);
            }

            switch (activeSearch.KeywordSearchType)
            {
                case "starts":
                    startswith.Checked = true;
                    break;
                case "contains":
                    contains.Checked = true;
                    break;
                case "ends":
                    endwith.Checked = true;
                    break;
            }

            PageRankHiddenMin.Value = activeSearch.PRMin.ToString();
            PageRankHiddenMax.Value = activeSearch.PRMax.ToString();

            DomainAgeHiddenMin.Value = activeSearch.DomainAgeMin.ToString();// = int.Parse(string.IsNullOrEmpty() ? activeSearch.DomainAgeMin.ToString() : DomainAgeHiddenMin.Value);
            DomainAgeHiddenMax.Value = activeSearch.DomainAgeMax.ToString();// = int.Parse(string.IsNullOrEmpty() ? activeSearch.DomainAgeMax.ToString() : DomainAgeHiddenMax.Value);

            DomainPriceHiddenMin.Value = activeSearch.DomainPriceMin.ToString();
            DomainPriceHiddenMax.Value = activeSearch.DomainPriceMax.ToString();

            MajesticTrustflowHiddenMin.Value = activeSearch.MajesticTrustFlowMin.ToString();
            MajesticTrustflowHiddenMax.Value = activeSearch.MajesticTrustFlowMax.ToString();

            MajesticIPSHiddenMin.Value = activeSearch.MajesticIPSMin.ToString();
            MajesticIPSHiddenMax.Value = activeSearch.MajesticIPSMax.ToString();

            CitationFlowHiddenMin.Value = activeSearch.MajesticCitationFlowMin.ToString();
            CitationFlowHiddenMax.Value = activeSearch.MajesticCitationFlowMax.ToString();

            MajesticBacklinksHiddenMin.Value = activeSearch.MajesticBacklinksMin.ToString();
            MajesticBacklinksHiddenMax.Value = activeSearch.MajesticBacklinksMAX.ToString();

            MOZDAHiddenMin.Value = activeSearch.MOZDAMin.ToString();
            MOZDAHiddenMax.Value = activeSearch.MOZDAMax.ToString();
            MOZPAHiddenMin.Value = activeSearch.MOZPAMin.ToString();
            MOZPAHiddenMax.Value = activeSearch.MOZPAMax.ToString();

            var moo = string.Format("$('#PRSilder').editRangeSlider('values', {0}, {1});", activeSearch.PRMin, activeSearch.PRMax);
            moo += string.Format("$('#CFSilder').editRangeSlider('values', {0}, {1});", activeSearch.MajesticCitationFlowMin, activeSearch.MajesticCitationFlowMax);
            moo += string.Format("$('#DomainAge').editRangeSlider('values', {0}, {1});", activeSearch.DomainAgeMin, activeSearch.DomainAgeMax);
            moo += string.Format("$('#DomainPrice').editRangeSlider('values', {0}, {1});", activeSearch.DomainPriceMin, activeSearch.DomainPriceMax);
            moo += string.Format("$('#MABacklinks').editRangeSlider('values', {0}, {1});", activeSearch.MajesticBacklinksMin, activeSearch.MajesticBacklinksMAX);
            moo += string.Format("$('#MATrustFlow').editRangeSlider('values', {0}, {1});", activeSearch.MajesticTrustFlowMin, activeSearch.MajesticTrustFlowMax);
            moo += string.Format("$('#MOZPA').editRangeSlider('values', {0}, {1});", activeSearch.MOZPAMin, activeSearch.MOZPAMax);
            moo += string.Format("$('#MOZDA').editRangeSlider('values', {0}, {1});", activeSearch.MOZDAMin, activeSearch.MOZDAMax);
            moo += string.Format("$('#MajesticIPS').editRangeSlider('values', {0}, {1});", activeSearch.MajesticIPSMin, activeSearch.MajesticIPSMax);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);

            ends_asia.Checked = activeSearch.end_asia;
            ends_at.Checked = activeSearch.end_at;
            ends_au.Checked = activeSearch.end_au;
            ends_be.Checked = activeSearch.end_be;
            ends_biz.Checked = activeSearch.end_biz;
            ends_ca.Checked = activeSearch.end_ca;
            ends_cc.Checked = activeSearch.end_cc;
            ends_ch.Checked = activeSearch.end_ch;
            ends_co.Checked = activeSearch.end_co;
            ends_com.Checked = activeSearch.end_com;
            ends_de.Checked= activeSearch.end_de;
            ends_eu.Checked = activeSearch.end_eu;
            ends_fr.Checked = activeSearch.end_fr;
            ends_ie.Checked = activeSearch.end_ie;
            ends_in.Checked = activeSearch.end_in;
            ends_info.Checked = activeSearch.end_info;
            ends_it.Checked = activeSearch.end_it;
            ends_me.Checked = activeSearch.end_me;
            ends_misc.Checked = activeSearch.end_misc;
            ends_mobi.Checked = activeSearch.end_mobi;
            ends_mx.Checked = activeSearch.end_mx;
            ends_net.Checked = activeSearch.end_net;
            ends_nl.Checked = activeSearch.end_nl;
            ends_nu.Checked = activeSearch.end_nu;
            ends_org.Checked = activeSearch.end_org;
            ends_pl.Checked = activeSearch.end_pl;
            ends_ru.Checked = activeSearch.end_ru;
            ends_se.Checked = activeSearch.end_se;
            ends_su.Checked = activeSearch.end_su;
            ends_tv.Checked = activeSearch.end_tv;
            ends_uk.Checked = activeSearch.end_uk;
            ends_us.Checked = activeSearch.end_us;

            source_DynaDot.Checked = activeSearch.Dynadot;
            source_GoDaddy.Checked = activeSearch.GoDaddy;
            source_NameJet.Checked = activeSearch.NameJet;
            source_Sedo.Checked = activeSearch.Sedo;
            source_SnapName.Checked = activeSearch.SnapName;

        }

        private void LoadAuctions(bool force = false)
        {
            if (!IsPostBack || force)
            {
                using (var ds = new ASEntities())
                {

                    if (GdAccount != null)
                    {
                        GodaddyAccount.Text = GdAccount.GoDaddyUsername;
                        GoDaddyPassword.Text = GdAccount.GoDaddyPassword;

                        receiveEmails.Checked = Account.ReceiveEmails;

                        var bids = ds.Auctions.Where(x => x.AccountID == GdAccount.AccountID).ToList().AsQueryable();
                        LunchboxGridView2.DataSource = bids;
                        LunchboxGridView2.DataBind();
                        bidcount.InnerText = bids.Count().ToString(CultureInfo.InvariantCulture);
                    }
                }

            }
        }

        protected void gvAgency_Sorting(object sender, GridViewSortEventArgs e)
        {
            LunchboxGridView1.Order(SearchResults.AsQueryable(), e.SortExpression);
        }

        protected void gvAgency_Sorting2(object sender, GridViewSortEventArgs e)
        {
            
        }

        private void FixHiddenValues()
        {
            const string data = @"var editValues = $('#PRSilder').editRangeSlider('values');
    $('#PageRankHiddenMin').val(Math.round(editValues.min));
    $('#PageRankHiddenMax').val(Math.round(editValues.max));

    var editValues = $('#CFSilder').editRangeSlider('values');
    $('#CitationFlowHiddenMin').val(Math.round(editValues.min));
    $('#CitationFlowHiddenMax').val(Math.round(editValues.max));

    var editValues = $('#DomainAge').editRangeSlider('values');
    $('#DomainAgeHiddenMin').val(Math.round(editValues.min));
    $('#DomainAgeHiddenMax').val(Math.round(editValues.max));

    var editValues = $('#DomainPrice').editRangeSlider('values');
    $('#DomainPriceHiddenMin').val(Math.round(editValues.min));
    $('#DomainPriceHiddenMax').val(Math.round(editValues.max));

    var editValues = $('#MABacklinks').editRangeSlider('values');
    $('#MajesticBacklinksHiddenMin').val(Math.round(editValues.min));
    $('#MajesticBacklinksHiddenMax').val(Math.round(editValues.max));

    var editValues = $('#MajesticIPS').editRangeSlider('values');
    $('#MajesticIPSHiddenMin').val(Math.round(editValues.min));
    $('#MajesticIPSHiddenMax').val(Math.round(editValues.max));
    var editValues = $('#MOZDA').editRangeSlider('values');
    $('#MOZDAHiddenMin').val(Math.round(editValues.min));
    $('#MOZDAHiddenMax').val(Math.round(editValues.max));
    var editValues = $('#MOZPA').editRangeSlider('values');
    $('#MOZPAHiddenMin').val(Math.round(editValues.min));
    $('#MOZPAHiddenMax').val(Math.round(editValues.max));
    var editValues = $('#MATrustFlow').editRangeSlider('values');
    $('#MajesticTrustflowHiddenMin').val(Math.round(editValues.min));
    $('#MajesticTrustflowHiddenMax').val(Math.round(editValues.max));
";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "fixvalues", data, true);
        }

        /// <summary>
        /// Perform Domain Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchClick(object sender, EventArgs e)
        {
            //ex2.Attributes;
            SaveChangesHidden.Value = "true";
            if (AdvSearchAccess && SaveChangesHidden.Value == "true") //&& Adv Search Enabled
            {
                SearchAll = btnSearchAll.Attributes["class"].Contains("active");

                SearchAuction = btnSearchAll.Attributes["class"].Contains("active");
                SearchBuyNow = btnSearchAll.Attributes["class"].Contains("active");
                SearchCloseout = btnSearchAll.Attributes["class"].Contains("active");

                SearchOffer = btnSearchAll.Attributes["class"].Contains("active");

                SearchPendingDelete = btnSearchAll.Attributes["class"].Contains("active");

                SaveSearchSettings();
                PerformAdvSearch();
                //SetupMultiBidLayout(gvAdvSearchResults);
                
            }
            else
            {
                GoDaddy.Login(GdAccount.GoDaddyUsername, GdAccount.GoDaddyPassword);
                SearchResults = GoDaddy.Search(txtSearch.Text).Take(int.Parse(ddlTopResults.SelectedValue));
                LoadSearchResults(LunchboxGridView1);
                SetupMultiBidLayout(LunchboxGridView4);
            }
            
        }

        private void PerformAdvSearch()
        {
            if (!DCop.Login(AppConfig.GetSystemConfig(AppSettings.DomCopUser), AppConfig.GetSystemConfig(AppSettings.DomCopPass))) return;
            DCop.Search(Account.UserID);
            using (var ds = new ASEntities())
            {
                var results = ds.AdvSearch.Where(x => x.UserID == Account.UserID).ToList().AsQueryable();
                gvAdvSearchResults.DataSource = results.Take(int.Parse(ddlTopResults.SelectedValue));
                gvAdvSearchResults.DataBind();
            }
        }

        protected void btnApply_Settings(object sender, EventArgs e)
        {
            SetSearchValues();
        }


        protected void btnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?ViewUser=" + ((LinkButton)sender).Attributes["adminID"]);
        }

        protected void btnSubmitBug(object sender, EventArgs e)
        {
            sentmessage.Style.Add("display","none");
            if (IsPostBack)
            {   
                var moo = bugtxtv.Text;
                API.Email(AppConfig.GetSystemConfig(AppSettings.AlertEmail), "Bug Report",
                                 "Account: " + Context.User.Identity.Name + Environment.NewLine +
                                 "Description: " + moo, "Service Manager Bug Report");
                sentmessage.Text = @"Bug Report Sent. Thank you for the feedback";
            }

        }

        public static int TryParse_INT(string value, int replaceval)
        {
            return int.TryParse(value, out replaceval) ? int.Parse(value) : replaceval;
        }

        protected void SubmitMultiBids(object sender, EventArgs e)
        {
            using (var ds = new ASEntities())
            {
                var account = ds.Users.First(x => x.Username == Context.User.Identity.Name);
                var accountID = account.UserID;
                var godaddy = ds.GoDaddyAccount.FirstOrDefault(x => x.UserID == accountID);
                var bidvalue = fullApplyvalue.Value;
                if (godaddy != null)
                {
                var bids =
                    ds.AuctionSearch.Where(
                        x =>
                            x.AccountID == godaddy.AccountID);

                    foreach (GridViewRow auc in LunchboxGridView4.Rows)
                    {
                        var myminbid = (auc.FindControl("bidvalue") as TextBox).Text;
                        var auctionRef = auc.Cells[1].Text;

                        var bid =
                            bids.First(
                                x =>
                                    x.AuctionRef == auctionRef);

                        var enddate = new GoDaddyAuctions().GetEndDate(bid.AuctionRef);
                        var linkedRuid = Guid.NewGuid();
                        var auction = new Auctions
                        {
                            AuctionID = linkedRuid,
                            AuctionRef = bid.AuctionRef,
                            DomainName = bid.DomainName,
                            BidCount = bid.BidCount,
                            Traffic = bid.Traffic,
                            Valuation = bid.Valuation,
                            Price = bid.Price,
                            MinBid = bid.MinBid,
                            MinOffer = bid.MinOffer,
                            BuyItNow = bid.BuyItNow,
                            EndDate = enddate,
                            EstimateEndDate = bid.EstimateEndDate,
                            AccountID = bid.AccountID,
                            Status = bid.Status,
                            MyBid = string.IsNullOrEmpty(myminbid) ? int.Parse(bidvalue) : TryParse_INT(myminbid, int.Parse(bidvalue))
                        };
                        var toRemove =
                            ds.Auctions.FirstOrDefault(
                                x => x.AccountID == godaddy.AccountID && x.AuctionRef == bid.AuctionRef);
                        if (toRemove != null)
                        {
                            ds.Auctions.Remove(toRemove);
                        }
                        ds.Auctions.AddOrUpdate(auction);
                        ds.SaveChanges();

                        var item = new AuctionHistory
                        {
                            HistoryID = Guid.NewGuid(),
                            Text = "Auction Added",
                            CreatedDate = DateTime.Now,
                            AuctionLink = auction.AuctionID
                        };
                        ds.AuctionHistory.Add(item);

                        var winalert = new Alerts
                        {
                            AuctionID = auction.AuctionID,
                            Custom = false,
                            Description = "WIN ALERT",
                            TriggerTime = auction.EndDate.AddMinutes(5)
                        };
                        ds.Alerts.Add(winalert);

                        var bidalert = new Alerts
                        {
                            AlertID = Guid.NewGuid(),
                            AuctionID = auction.AuctionID,
                            Custom = false,
                            Description = "12 Hour Alert",
                            TriggerTime = auction.EndDate.AddHours(-12)
                        };
                        ds.Alerts.Add(bidalert);

                        var bidalert2 = new Alerts
                        {
                            AlertID = Guid.NewGuid(),
                            AuctionID = auction.AuctionID,
                            Custom = false,
                            Description = "1 Hour Alert",
                            TriggerTime = auction.EndDate.AddHours(-1)
                        };
                        ds.Alerts.Add(bidalert2);
                        ds.SaveChanges();
                    }
                }

                ds.SaveChanges();
            }
            const string script = "window.location='" + "Default.aspx?redirect=mybids" + "';";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "RedirectTo", script, true);
            //Response.Redirect("Default.aspx#mybids", true);

        }
        //SearchClick

        protected void GenerateMultiBids(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string txt = TextBox1.Text;
                var lst = txt.Split(new [] { '\n'}, StringSplitOptions.RemoveEmptyEntries);

                List<AuctionSearch> tempsearch = null;
                if (lst.Any())
                {
                    GoDaddy.Login(GdAccount.GoDaddyUsername, GdAccount.GoDaddyPassword);
                    tempsearch = new List<AuctionSearch>();
                    foreach (var s in lst)
                    {
                        var ress =
                            GoDaddy.Search(s.Replace("http://", "").Replace("www.","")).ToList();
                        foreach (var res in ress)
                        {
                            if (res.DomainName.ToLower() == s.ToLower())
                            {
                                tempsearch.Add(res);
                                break;
                            }
                        }
                    }
                    SearchResults = tempsearch.AsQueryable();
                }
                SetupMultiBidLayout(LunchboxGridView4);
            }

        }

        private void SetupMultiBidLayout(LunchboxGridView lbv)
        {

            multipaste.Style.Add("Display", "none");
            LinkButton5.Style.Add("Display", "none");
            LoadSearchResults(lbv);
            hiddenmulti.Style.Clear();
            masssubmit.Style.Clear();
            reset.Style.Clear();
        }

        private void ResetMultiBidLayout()
        {

            multipaste.Style.Clear();
            LinkButton5.Style.Clear();
            hiddenmulti.Style.Add("Display", "none");
            masssubmit.Style.Add("Display", "none");
            reset.Style.Add("Display", "none");
        }

        private void LoadSearchResults(LunchboxGridView grid)
        {
            grid.DataSource = SearchResults;
            grid.DataBind();
        }

        protected void Reset(object sender, EventArgs e)
        {
            ResetMultiBidLayout();
        }


        protected void btnSave_Godaddy(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                using (var ds = new ASEntities())
                {
                    if (GdAccount == null)
                    {
                        var account = new GoDaddyAccount
                        {
                            GoDaddyUsername = inputEmail3.Text,
                            GoDaddyPassword = inputPassword3.Text,
                            UserID = Account.UserID
                        };
                        ds.GoDaddyAccount.Add(account);
                        ds.SaveChanges();
                    }

                }
            }
            
        }

        protected void grdViewCustomers_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerID = LunchboxGridView2.DataKeys[e.Row.RowIndex].Value.ToString();
                var grdViewOrdersOfCustomer = (GridView)e.Row.FindControl("grdViewOrdersOfCustomer");
                using (var ds = new ASEntities())
                {
                    var id = Guid.Parse(customerID);
                    var history = ds.AuctionHistoryView.Where(x => x.AuctionLink == id).ToList().OrderBy(x=>x.CreatedDate);
                    grdViewOrdersOfCustomer.DataSource = history;
                    grdViewOrdersOfCustomer.DataBind();

                    var auction = ds.Auctions.First(x => x.AuctionID == id);

                    var won = history.Any(x => x.Text == "Auction WON");
                    var lost = history.Any(x => x.Text == "Auction LOST");
                    var now = DateTime.Now;

                    if (won)
                    {
                        e.Row.CssClass = "info";
                        e.Row.Cells[6].Text = @"WON";
                        e.Row.Style.Add("background-color", "#D9EDF7");
                    }else if (lost)
                    {
                        e.Row.CssClass = "danger";
                        e.Row.Style.Add("background-color", "#F2DEDE");
                        e.Row.Cells[6].Text = @"LOST";
                    }else if (auction.EndDate < now)
                    {
                        e.Row.Cells[6].Text = @"Unconfirmed";
                    }
                }

                var bidval = int.Parse(e.Row.Cells[7].Text);
                var minval = int.Parse(e.Row.Cells[4].Text);
                e.Row.Cells[7].Style.Add("text-align", "center");
                e.Row.Cells[8].Style.Add("background-color", "#ffffff");
                e.Row.Cells[9].Style.Add("background-color", "#ffffff");
                //e.Row.Cells[7].Style.Add("color", "#ffffff");
                if (bidval >= minval)
                {
                    e.Row.Cells[7].Style.Add("background-color", "#D9EDF7");
                }
                else
                {
                    e.Row.Cells[7].Style.Add("background-color", "#F2DEDE");
                }

            }
        }

        protected void Update_EmailOptions(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                using (var ds = new ASEntities())
                {
                    var account = ds.Users.First(x => x.Username == Context.User.Identity.Name);
                    account.ReceiveEmails = receiveEmails.Checked;
                    ds.Users.AddOrUpdate(account);
                    ds.SaveChanges();
                    emailmessage.Style.Clear();
                    emailmessage.InnerText = @"Settings Saved";
                }
                var moo = "$('#MainContent_emailmessage').fadeIn(3000).delay(1000).fadeOut('slow'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
            }
        }

        protected void Update_Godaddy(object sender, EventArgs e)
        {   
            if (IsPostBack)
            {
                using (var ds = new ASEntities())
                {
                    var accountID = ds.Users.First(x => x.Username == Context.User.Identity.Name).UserID;
                    var godaddy = ds.GoDaddyAccount.First(x => x.UserID == accountID);
                    godaddy.GoDaddyUsername = GodaddyAccount.Text;
                    godaddy.GoDaddyPassword = GoDaddyPassword.Text;
                    if (GoDaddy.Login(GodaddyAccount.Text, GoDaddyPassword.Text))
                    {
                        godaddy.Verified = true;
                        ds.GoDaddyAccount.AddOrUpdate(godaddy);
                        ds.SaveChanges();
                        Msg.CssClass = "alert alert-success";
                        Msg.Text = @"Details Saved and Confirmed";
                        flash.Visible = false;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        godaddy.Verified = false;
                        ds.GoDaddyAccount.AddOrUpdate(godaddy);
                        ds.SaveChanges();
                        Msg.CssClass = "alert alert-danger";
                        Msg.Text = @"Changes failed. Login to GoDaddy Failed";
                    }

                    Msg.Style.Clear();
                }
            }

        }

        protected void MassBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                //incase you need the row index 
                //int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                var auctionRef = Guid.Parse(e.CommandArgument.ToString());

                using (var ds = new ASEntities())
                {
                    ds.AuctionSearch.Remove(ds.AuctionSearch.First(x => x.AuctionID == auctionRef));
                    ds.SaveChanges();
                }
                LoadSearchResults(LunchboxGridView4);
                SetupMultiBidLayout(LunchboxGridView4);
                //Response.Redirect("Default.aspx#mybids", true);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "javascript:document.location.reload();", true);
            }
        }

        protected void MyBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                //incase you need the row index 
                //int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                var auctionRef = Guid.Parse(e.CommandArgument.ToString());

                using (var ds = new ASEntities())
                {
                    try
                    {
                        var entries = ds.Alerts.Where(x => x.AuctionID == auctionRef);
                        if (entries.Any())
                        {
                            ds.Alerts.RemoveRange(ds.Alerts.Where(x => x.AuctionID == auctionRef));
                        }
                        ds.Auctions.Remove(ds.Auctions.First(x => x.AuctionID == auctionRef));
                        ds.SaveChanges();
                    }
                    catch (Exception)
                    {
                            
                    }
                    
                }
                ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).Style.Add("display", "none");
                //Response.Redirect("Default.aspx#mybids", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "javascript:document.location.reload();", true);
            }
        }

        public void PendingRecordsGridview_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            Response.Redirect(Request.RawUrl.ToString());
        } 

        protected void gvAgency_DataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
                //var myButtonAp = e.Row.FindControl("LinkButton1") as LinkButton;
                //Page.ClientScript.RegisterStartupScript(
                //    GetType(),
                //    "MyKey",
                //    "zxcCountDown('SetBid','message',20);",
                //    true);
                //myButtonAp.Attributes.Add("adminID", ((Auctions)e.Row.DataItem).EstimateEndDate);
            //}
        }

    }
}