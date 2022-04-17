using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CPairsPage : IPageType
    {
        public uint count => 1;
        public CCoinPairsM model;

        public CPairsPage(CCoinPairsM model)
        {
            this.model = model;
        }
        public IEnumerable<CPageInfo> pages
        {
            get
            {
                /*yield break;*/
                yield return new CPageInfo() { url = "/crypto-pairs" };
            }
        }
    }
}
