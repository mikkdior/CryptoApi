namespace CryptoApi.Api.Market
{
    public class CMarketCoinsData : IApiCoinsData
    {
        List<CJsonCoinData> coins;
        string key = "market";

        public CMarketCoinsData(List<CJsonCoinData> coins)
        {
            this.coins = coins;
        }
        public IEnumerable<IApiCoin> GetEnumerable()
        {
            foreach (var coin in coins)
            {
                yield return new CApiCoin
                {
                    Donor = key,
                    Id = coin.id.ToString(),
                    FullName = coin.name,
                    Name = coin.symbol,
                    Image = null,
                    UsdPrice = coin.quote["USD"].price,
                    MarketCap = coin.quote["USD"].market_cap,
                    Low = null,
                    High = null
                };
            }
        }
    }
}
