using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CPairPage : IPageType
    {
        public uint count => model.Count();
        public CCoinPairsM model;

        public CPairPage(CCoinPairsM model)
        {
            this.model = model;
        }
        public IEnumerable<CPageInfo> pages
        {
            get
            {
                return model.GetPairsData()
                    .Select(p => new CPageInfo()
                    {
                        url = $"/crypto-pairs/{p.coin_1.name}-to-{p.coin_2.name}"
                    });
            }
        }
    }
}
