using CoinpaprikaAPI;
using CoinpaprikaAPI.Entity;

namespace CryptoApi.Api.Paprika
{
    public class CPaprikaCoinsData : IApiCoinsData
    {
        List<CoinInfo> coins;
        Dictionary<string, ExtendedExchangeInfo> extCoins;
        string key = "paprika";

        public CPaprikaCoinsData (List<CoinInfo> coins, Dictionary<string, ExtendedExchangeInfo> extCoins)
        {
            this.coins = coins;
            this.extCoins = extCoins;
        }
        public IEnumerable<IApiCoin> GetEnumerable()
        {
            foreach (var coin in coins)
            {
                ExtendedExchangeInfo info = extCoins.ContainsKey(coin.Id) ? extCoins[coin.Id] : null;

                yield return new CApiCoin
                {
                    Image = "",
                    Donor = key,
                    Id = coin.Id,
                    FullName = coin.Name,
                    Name = coin.Symbol,
                    Usd = 0,
                    MarketCap = 0,
                    ChangeDay = info == null ? 0 : info.Quotes["USD"].AdjustedVolume24H,
                    ChangeWeek = info == null ? "0" : info.Quotes["USD"].AdjustedVolume7D.ToString(),
                    ChangeMonth = info == null ? "0" : info.Quotes["USD"].ReportedVolume30D.ToString(),
                    ChangePrice = 0
                };
            }
        }
    }
}
