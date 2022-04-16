using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CCoinsPage : IPageType
    {
        public int count => 1;
        public CCoinsM model;

        public CCoinsPage(CCoinsM model)
        {
            this.model = model;
        }
        public IEnumerable<CPageInfo> pages
        {
            get
            {
                /*yield break;*/
                yield return new CPageInfo() { url = "/coins" };
            }
        }
    }
}
