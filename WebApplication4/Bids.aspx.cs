using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASEntityFramework;
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
                var rIndex = row.RowIndex;
                var bid = (LunchboxGridView2.Rows[rIndex].Cells[6].Controls[0] as TextBox).Text;
                Presenter.UpdateAuction(auctionRef, bid);

                LunchboxGridView2.EditIndex = -1;
                LoadAuctions();
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
                    var history = ds.AuctionHistoryView.Where(x => x.AuctionLink == id).ToList().OrderBy(x => x.CreatedDate);
                    grdViewOrdersOfCustomer.DataSource = history;
                    grdViewOrdersOfCustomer.DataBind();

                    var auction = ds.Auctions.First(x => x.AuctionID == id);

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
                }

                //var bidval = int.Parse(e.Row.Cells[6].Text);
                //var minval = int.Parse(e.Row.Cells[3].Text);
                //e.Row.Cells[6].Style.Add("text-align", "center");
                //if (bidval >= minval)
                //{
                //    e.Row.Cells[6].Style.Add("background-color", "#D9EDF7");
                //}
                //else
                //{
                //    e.Row.Cells[6].Style.Add("background-color", "#F2DEDE");
                //}

                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(LunchboxGridView2, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void gvAgency_DataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gvAgency_Sorting(object sender, GridViewSortEventArgs e)
        {
            LunchboxGridView2.Order(MyBids.AsQueryable(), e.SortExpression);
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
            LunchboxGridView2.DataSource = MyBids;
            LunchboxGridView2.DataBind();
            //Hide edit options
            LunchboxGridView2.Columns[7].Visible = false;
         
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            var row = ((LinkButton) sender).NamingContainer as GridViewRow;
            var mybid = (row.Cells[6].Controls[0] as TextBox).Text;
            var auctionref = Guid.Parse(((LinkButton)sender).CommandArgument);

            Presenter.UpdateAuction(auctionref, mybid);
            
            LunchboxGridView2.EditIndex = -1;
            LoadAuctions();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            LunchboxGridView2.EditIndex = -1;
            LoadAuctions();
        }

        protected void LunchboxGridView2_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            LunchboxGridView2.EditIndex = e.NewEditIndex;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "editFix", "var list = document.getElementsByTagName('input')[0];list.setAttribute('onkeypress', 'return isNumberKey(event)');", true);

            LoadAuctions();
            LunchboxGridView2.Columns[7].Visible = true;
           
        }

        protected void updatestuff(object sender, GridViewUpdateEventArgs e)
        {
            
        }
    }
}