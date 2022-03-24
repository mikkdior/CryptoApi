using CoinGecko.Entities.Response.Coins;
using System.Collections;

namespace CryptoApi.Api.Gecko
{
    public class CGeckoCoinsData : IApiCoinsData
    {
        IReadOnlyList<CoinFullData> coins_full;
        IReadOnlyList<CoinList> coins;

        string key = "gecko";
        public CGeckoCoinsData (IReadOnlyList<CoinFullData> coins_full, IReadOnlyList<CoinList> coins)
        {
            this.coins = coins;
            this.coins_full = coins_full;
        }
        public IEnumerable<IApiCoin> GetEnumerable()
        {
            foreach(var coin in coins_full)
            {
                yield return new CApiCoin
                {
                    Image = coin.Image.Large.AbsoluteUri,
                    Donor = key, 
                    Id = coin.Id, 
                    FullName = coin.Name, 
                    Name = coin.Symbol,
                    Usd = coin.MarketData.CurrentPrice["usd"].Value,
                    MarketCap = coin.MarketData.MarketCap["usd"].Value,
                    ChangeDay = coin.MarketData.PriceChangePercentage24H.Value,
                    ChangeWeek = coin.MarketData.PriceChangePercentage7D,
                    ChangeMonth = coin.MarketData.PriceChangePercentage30D,
                    ChangePrice = coin.MarketData.PriceChange24H.Value
                };
            }

            foreach (var coin in coins)
            {
                yield return new CApiCoin
                {
                    Image = "",
                    Donor = key,
                    Id = coin.Id,
                    FullName = coin.Name,
                    Name = coin.Symbol,
                    Usd = 0,
                    MarketCap = 0,
                    ChangeDay = 0,
                    ChangeWeek = "",
                    ChangeMonth = "",
                    ChangePrice = 0
                };
            }
        }
    }
}
