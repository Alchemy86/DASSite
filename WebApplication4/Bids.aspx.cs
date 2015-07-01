using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASEntityFramework;
using LunchboxWebControls;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{
    public partial class Bids : Page, IBidsView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_mybids').className  = 'active';", true);
            if (!IsPostBack)
            {
                LoadAuctions();
            }
        }

        protected void MyBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                var auctionRef = Guid.Parse(e.CommandArgument.ToString());
                Presenter.DeleteAuction(auctionRef);
                ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "javascript:document.location.reload();", true);
            }
            if (e.CommandName == "Update")
            {
                var auctionRef = Guid.Parse(e.CommandArgument.ToString());
                GridViewRow row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                var bid = (row.Cells[6].Controls[0] as TextBox).Text;
                Presenter.UpdateAuction(auctionRef, bid);

                var grid = sender as GridView;
                grid.EditIndex = -1;
                LoadAuctions();
            }
        }

        protected void grdViewCustomers_OnRowDataBoundCurrent(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var grdViewOrdersOfCustomer = (GridView)e.Row.FindControl("grdViewOrdersOfCustomer");

            var auction = (Auctions)e.Row.DataItem;
            var history = Presenter.LoadAuctionHistory(auction).ToList().OrderBy(x => x.CreatedDate);
            grdViewOrdersOfCustomer.DataSource = history;
            grdViewOrdersOfCustomer.DataBind();

            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(LunchboxGridView2, "Edit$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";

            e.Row.Cells[6].CssClass = auction.MyBid > auction.MinBid ? "bidfine" : "bidtolow";
            
            //var bidval = int.Parse(e.Row.Cells[6].Text);
            //var minval = int.Parse(e.Row.Cells[3].Text);
            //e.Row.Cells[6].Style.Add("text-align", "center");
            //if (bidval >= minval)
            //{
            //    e.Row.Cells[6].CssClass = "bidfine";
            //}
            //else
            //{
            //    e.Row.Cells[6].CssClass = "bidtolow";
            //}
        }

        protected void grdViewCustomers_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var grdViewOrdersOfCustomer = (GridView)e.Row.FindControl("grdViewOrdersOfCustomer");

            var auction = (Auctions)e.Row.DataItem;
            var history = Presenter.LoadAuctionHistory(auction).ToList().OrderBy(x => x.CreatedDate);
            grdViewOrdersOfCustomer.DataSource = history;
            grdViewOrdersOfCustomer.DataBind();

            var won = history.Any(x => x.Text == "Auction WON");
            var lost = history.Any(x => x.Text == "Auction LOST");
            var now = DateTime.Now;

            if (won)
            {
                e.Row.CssClass = "info";
                e.Row.Cells[5].Text = @"WON";
                e.Row.Style.Add("background-color", "#D9EDF7");
            }
            else if (lost)
            {
                e.Row.CssClass = "danger";
                e.Row.Style.Add("background-color", "#F2DEDE");
                e.Row.Cells[5].Text = @"LOST";
            }
            else if (auction.EndDate < now)
            {
                e.Row.Cells[5].Text = @"Unconfirmed";
            }

            //var bidval = int.Parse(e.Row.Cells[6].Text);
            //var minval = int.Parse(e.Row.Cells[3].Text);
            //e.Row.Cells[6].Style.Add("text-align", "center");C:\git\DASSite\WebApplication4\fonts\
            //if (bidval >= minval)
            //{
            //    e.Row.Cells[6].Style.Add("background-color", "#D9EDF7");
            //}
            //else
            //{
            //    e.Row.Cells[6].Style.Add("background-color", "#F2DEDE");
            //}
        }

        protected void gvAgency_DataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gvAgency_Sorting(object sender, GridViewSortEventArgs e)
        {
            var grid = sender as LunchboxGridView;
            grid.Order(MyBids.AsQueryable(), e.SortExpression);
            //applyTimers()
        }

        public BidsPresenter Presenter
        {
            get
            {
                if (Session["BidsPresenter"] != null)
                {
                    return (BidsPresenter)Session["BidsPresenter"];
                }
                return new BidsPresenter(this, (Master.Default)Master);
            }
        }

        public IQueryable<Auctions> MyBids
        {
            get { return Presenter.LoadAuctions(); }
        }

        public IQueryable<Auctions> HistoricBids
        {
            get { return null; }
        }


        public void LoadAuctions()
        {
            var currentDate = DateTime.Now;
            LunchboxGridView2.DataSource = MyBids.Where(x=>x.EndDate > currentDate);
            LunchboxGridView2.DataBind();
            //Hide edit options
            LunchboxGridView2.Columns[7].Visible = false;
            LunchboxGridView2.Columns[8].Visible = true;

            LunchboxGridView1.DataSource = MyBids.Where(x => x.EndDate < currentDate);
            LunchboxGridView1.DataBind();
            //Hide edit options
            LunchboxGridView1.Columns[7].Visible = false;
            LunchboxGridView1.Columns[8].Visible = true;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            var row = ((LinkButton) sender).NamingContainer as GridViewRow;
            var mybid = (row.Cells[6].Controls[0] as TextBox).Text;
            var auctionref = Guid.Parse(((LinkButton)sender).CommandArgument);

            Presenter.UpdateAuction(auctionref, mybid);
            var grid = sender as GridView;
            grid.EditIndex = -1;
            LoadAuctions();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            LunchboxGridView2.EditIndex = -1;
            LoadAuctions();
        }

        protected void LunchboxGridView2_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            var grid = sender as GridView;
            grid.EditIndex = e.NewEditIndex;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "editFix", "var list = document.getElementsByTagName('input')[0];list.setAttribute('onkeypress', 'return isNumberKey(event)');", true);

            LoadAuctions();
            grid.Columns[7].Visible = true;
            grid.Columns[8].Visible = false;
           
        }

        protected void updatestuff(object sender, GridViewUpdateEventArgs e)
        {
            
        }
    }
}