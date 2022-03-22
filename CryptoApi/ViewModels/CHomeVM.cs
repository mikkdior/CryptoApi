using CryptoApi.Services;
namespace CryptoApi.ViewModels
{
    public class CHomeVM
    {
        private IConfiguration conf;
        private CCommonM commonModel;

        public IEnumerable<CTextBlockVM> TextBlocks => GetTextBlock("home texts");
        public IEnumerable<CTextBlockVM> Faq => GetTextBlock("home faq");

        public IEnumerable<CTextBlockVM> GetTextBlock(string group)
        {
            for (var i = 0; i < commonModel[group].Count() / 2; i++)
            {
                string title = commonModel[group, $"title{i + 1}"].value;
                string text = commonModel[group, $"text{i + 1}"].value;

                yield return new CTextBlockBuilder()
                    .SetTitle(title)
                    .SetText(text)
                    .Build();
            }
        }
        public CHomeVM(IConfiguration conf, CCommonM common_model)
        {
            this.conf = conf;
            this.commonModel = common_model;
        }
    }
}
