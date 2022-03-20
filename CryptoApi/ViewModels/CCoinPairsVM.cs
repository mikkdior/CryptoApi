using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CCoinPairsVM
    {
        private CCoinPairsM model;
        public IEnumerable<CCoinPairDataVM> pairs;
        private IConfiguration conf;
        public int maxPage = 10;
        public int page = 1;
        public CBlocksHelperVM blocks;

        public CCoinPairsVM(CCoinPairsM model, IConfiguration conf, CBlocksHelperVM blocks)
        {
            this.model = model;
            this.conf = conf;
            this.blocks = blocks;
        }

        public void Init(HttpContext context)
        {
            int count = Int32.Parse(conf["PairsCountOnPage"]);
            maxPage = model.GetMaxPage(count);
            string? page_str = (string?)context.Request.Query["page"];
            page = page_str == null ? 1 : Int32.Parse(page_str);
            page = page <= maxPage ? page : maxPage;
            pairs = blocks.GetPairList(count, page);
        }
    }
}
