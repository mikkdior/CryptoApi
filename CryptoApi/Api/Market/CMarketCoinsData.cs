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
                    Image = "",
                    Donor = key,
                    Id = coin.id.ToString(),
                    FullName = coin.name,
                    Name = coin.symbol,
                    Usd = coin.quote["USD"].price,
                    MarketCap = coin.quote["USD"].market_cap,
                    ChangeDay = (double)coin.quote["USD"].percent_change_24h,
                    ChangeWeek = coin.quote["USD"].percent_change_7d.ToString(),
                    ChangeMonth = "",
                    ChangePrice = (decimal)coin.quote["USD"].volume_change_24h
                };
            }
        }
    }
}
