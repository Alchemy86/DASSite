using System.Linq;
using System.Web.UI.WebControls;
using ASEntityFramework;

namespace WebApplication4.View
{
    public interface IBidsView
    {   
        IQueryable<Auctions> MyBids { get; }
        IQueryable<Auctions> HistoricBids { get; }

        void LoadAuctions();
    }
}
