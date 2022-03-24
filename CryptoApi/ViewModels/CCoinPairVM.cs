using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CCoinPairVM
    {
        private CCoinPairsM model;
        private IConfiguration conf;
        public CCoinPairDataVM pair;
        private CCommonM commonModel;

        public CTextBlockVM Description
        {
            get
            {
                return new CTextBlockBuilder()
                    .SetTitle(commonModel["pair desc", "title"]?.value)
                    .SetTitleValues(pair.data["desc", "title"]?.value)
                    .SetTitleData(pair.data)
                    .SetText(commonModel["pair desc", "text"]?.value)
                    .SetTextValues(pair.data["desc", "text"]?.value)
                    .SetTextData(pair.data)
                    .Build();
            }
        }

        public IEnumerable<CTextBlockVM> TextBlocks => GetTextBlock("pair texts");
        public IEnumerable<CTextBlockVM> Faq => GetTextBlock("pair faq");

        public IEnumerable<CTextBlockVM> GetTextBlock(string group)
        {
            for (var i = 0; i < commonModel[group].Count() / 2; i++)
            {
                string title = commonModel[group, $"title{i + 1}"].value;
                string text = commonModel[group, $"text{i + 1}"].value;

                yield return new CTextBlockBuilder()
                    .SetTitle(title)
                    .SetTitleValues(pair.data["desc", "title"]?.value)
                    .SetTitleData(pair.data)
                    .SetText(text)
                    .SetTextValues(pair.data["desc", "text"]?.value)
                    .SetTextData(pair.data)
                    .Build();
            }
        }
        public CCoinPairVM(CCoinPairsM model, IConfiguration conf, CCommonM common_model)
        {
            this.model = model;
            this.conf = conf;
            this.commonModel = common_model;
        }

        public void Init(HttpContext context)
        {
            string coin1 = (string)context.GetRouteValue("coin1");
            string coin2 = (string)context.GetRouteValue("coin2");

            pair = model.GetPairByNames(coin1, coin2); 
        }
    }
}
