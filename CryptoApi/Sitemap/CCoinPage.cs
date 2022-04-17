using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CCoinPage : IPageType
    {
        public uint count => model.Count();
        public CCoinsM model;

        public CCoinPage(CCoinsM model)
        {
            this.model = model;
        }

        public IEnumerable<CPageInfo> pages
        {
            get
            {
                return model.GetCoins()
                    .Select(c => new CPageInfo()
                    {
                        url = $"/coins/{c.name}"
                    });
            }
        }
    }
}
