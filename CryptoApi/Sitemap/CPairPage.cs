using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CPairPage : IPageType
    {
        public int count => 0;
        public CCoinPairsM model;

        public CPairPage(CCoinPairsM model)
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
