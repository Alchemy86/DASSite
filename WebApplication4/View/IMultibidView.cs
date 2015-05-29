using System.Linq;
using ASEntityFramework;
using LunchboxWebControls;
using WebApplication4.Presenter;

namespace WebApplication4.View
{
    public interface IMultibidView
    {
        IQueryable<AuctionSearch> SearchResults { get; }
        MultibidPresenter Presenter { get; }
        string MultiBidText { get; }
        int BidValue { get;  }
        void LoadSearchResults(LunchboxGridView grid);
        void SetupMultiBidLayout(LunchboxGridView grid);
    }
}
