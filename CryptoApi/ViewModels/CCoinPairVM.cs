using CryptoApi.Services;

namespace CryptoApi.ViewModels
{
    public class CCoinPairVM
    {
        private CCoinPairsM model;
        private IConfiguration conf;
        public CCoinPairDataVM pair;

        public CCoinPairVM(CCoinPairsM model, IConfiguration conf)
        {
            this.model = model;
            this.conf = conf;
        }

        public void Init(HttpContext context)
        {
            string coin1 = (string)context.GetRouteValue("coin1");
            string coin2 = (string)context.GetRouteValue("coin2");

            pair = model.GetPairByNames(coin1, coin2);
        }
    }
}
