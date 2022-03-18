using CoinGecko.Entities.Response.Shared;
using System.Net.Mime;

namespace CryptoApi.Api
{
    public class CApiCoin : IApiCoin
    {
        public string Id { get; set; }
        public string Donor { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Usd { get; set; }
    }
}
