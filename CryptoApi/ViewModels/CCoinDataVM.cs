using CryptoApi.Models.DB;

namespace CryptoApi.ViewModels
{
    public class CCoinDataVM
    {
        public CCoinDataM data { get; set; }
        public string Title => $"Exchange DODO to USD {data.name_full}";
        public string Url => $"/coins/{data.slug}";
    }
}
