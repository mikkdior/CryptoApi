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
                yield return new CApiCoin
                {
                    Donor = key,
                    Id = coin.Id,
                    FullName = coin.Name,
                    Name = coin.Symbol,
                    Image = null,
                    UsdPrice = null,
                    MarketCap = null,
                    Low = null,
                    High = null
                };
            }
        }
    }
}
