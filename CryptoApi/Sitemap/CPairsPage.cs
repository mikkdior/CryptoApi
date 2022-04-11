using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CPairsPage : IPageType
    {
        public int count => 0;
        public CCoinPairsM model;

        public CPairsPage(CCoinPairsM model)
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
