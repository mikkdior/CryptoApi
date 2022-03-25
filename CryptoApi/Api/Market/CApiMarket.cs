using System.Net;
using System.Web;

namespace CryptoApi.Api.Market
{
    public class CApiMarket : CBaseApi, IApi
    {
        public CApiMarket(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
        }

        public Task<IApiCoinPairsData> GetCoinPairsAsync()
        {
            return default;
        }

        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            Console.WriteLine("data:");
            string str = makeAPICall();
            //var data = CMarketJsonParser.Parse(str);
            Console.WriteLine(str);
            //Console.WriteLine("count: " + data.data.Count);
            return null;
            //return new CMarketCoinsData(data.data);
        }

        public Task TestAsync()
        {
            throw new NotImplementedException();
        }

        private string makeAPICall(string key = "8ebb1a91-71c4-4615-8171-2329c07b945e")
        {
            string API_KEY = key;
            var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            //var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/market-pairs/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            //queryString["start"] = "1";
            //queryString["limit"] = "5000";
            //queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());

        }
    }
}
