using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CCoinVM
    {
        public CCoinDataVM coin;
        private CCoinsM model;
        private IConfiguration conf;
        public CCoinVM (CCoinsM model, IConfiguration conf)
        {
            this.model = model;
            this.conf = conf;
        }
        public void Init (HttpContext context)
        {
            string? name = (string?)context.GetRouteValue("coin");
            coin = model.GetCoinByName(name);
        }
    }
}
