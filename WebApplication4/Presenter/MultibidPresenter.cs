using System.Linq;
using ASEntityFramework;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class MultibidPresenter
    {
        protected IMultibidView View;
        protected MultibidModel Model;
        public IDefaultView DefaultView;

        public MultibidPresenter(IMultibidView view, IDefaultView defaultview)
        {
            View = view;
            DefaultView = defaultview;
            Model = new MultibidModel();
        }

        public IQueryable<AuctionSearch> SearchResults()
        {
            return Model.GetSearchResults(DefaultView.GoDaddyAccount);
        }

        public void SetSearchResults(IQueryable<AuctionSearch> results)
        {
            Model.SaveSearchResults(results, DefaultView.GoDaddyAccount);
        }

        public IQueryable<AuctionSearch> Search(string searchText)
        {
            SetSearchResults(DefaultView.GdHelper.GoDaddyApi.Search(searchText.Replace("http://", "").Replace("www.", "")));
            return SearchResults();
        }

    }
}