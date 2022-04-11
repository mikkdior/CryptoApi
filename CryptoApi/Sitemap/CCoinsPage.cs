using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CCoinsPage : IPageType
    {
        public int count => 0;
        public CCoinsM model;

        public CCoinsPage(CCoinsM model)
        {
            this.model = model;
        }
        public IEnumerable<CPageInfo> pages
        {
            get
            {
                yield break;
            }
        }
    }
}
