using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CCoinVM
    {
        public CCoinDataVM coin;
        private CCoinsM model;
        private IConfiguration conf;
        private CCommonM commonModel;

        public CTextBlockVM Description
        {
            get 
            {
                return new CTextBlockBuilder()
                    .SetTitle(commonModel["coin desc", "title"]?.value)
                    .SetTitleValues(coin.data["desc", "title"]?.value)
                    .SetTitleData(coin.data)
                    .SetText(commonModel["coin desc", "text"]?.value)
                    .SetTextValues(coin.data["desc", "text"]?.value)
                    .SetTextData(coin.data)
                    .Build(); 
            }
        }

        public IEnumerable<CTextBlockVM> TextBlocks => GetTextBlock("coin texts");
        public IEnumerable<CTextBlockVM> Faq => GetTextBlock("coin faq");

        public IEnumerable<CTextBlockVM> GetTextBlock(string group)
        {
            for (var i = 0; i < commonModel[group].Count() / 2; i++)
            {
                string title = commonModel[group, $"title{i}"].value;
                string text = commonModel[group, $"text{i}"].value;

                yield return new CTextBlockBuilder()
                    .SetTitle(title)
                    .SetTitleValues(coin.data["desc", "title"]?.value)
                    .SetTitleData(coin.data)
                    .SetText(text)
                    .SetTextValues(coin.data["desc", "text"]?.value)
                    .SetTextData(coin.data)
                    .Build();
            }
        }
        public CCoinVM (CCoinsM model, IConfiguration conf, CCommonM common_model)
        {
            this.model = model;
            this.conf = conf;
            this.commonModel = common_model;
        }
        public void Init (HttpContext context)
        {
            string? name = (string?)context.GetRouteValue("coin");
            coin = model.GetCoinByName(name);
            Console.WriteLine("-------------------------");
            Console.WriteLine(Description.title);
            Console.WriteLine("-------------------------");
            Console.WriteLine(Description.text);
            Console.WriteLine("-------------------------");
        }
    }
}
