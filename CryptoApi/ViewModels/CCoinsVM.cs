using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CCoinsVM
    {
        public IEnumerable<CCoinDataVM> coins;
        private CCoinsM model;
        private IConfiguration conf;
        public int MaxPage;
        public int Page;

        public CCoinsVM(CCoinsM model, IConfiguration conf)
        {
            this.model = model;
            this.conf = conf;
        }
        public void Init(HttpContext context)
        {
            int count = Int32.Parse(conf["CoinsCountOnPage"]);
            MaxPage = model.GetMaxPage(count);
            string? page_str = (string?)context.Request.Query["page"];
            Page = page_str == null ? 1 : Int32.Parse(page_str);
            Page = Page <= MaxPage ? Page : MaxPage;
            coins = model.GetCoins(Page, count);
        }
    }
}
