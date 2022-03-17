using CoinGecko.Entities.Response.Coins;
using System.Collections;

namespace CryptoApi.Api.Gecko
{
    public class CGeckoCoinsData : IApiCoinsData
    {
        IReadOnlyList<CoinList> coins;
        string key = "gecko";
        public CGeckoCoinsData (IReadOnlyList<CoinList> coins)
        {
            this.coins = coins;
        }
        public IEnumerator<IApiCoin> GetEnumerator()
        {
            foreach(CoinList coin in coins)
            {
                yield return new CApiCoin { Donor = key, Id = coin.Id, FullName = coin.Name, Name = coin.Symbol };
            }
        }
    }
}
