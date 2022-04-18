using CoinGecko.Entities.Response.Coins;
using System.Collections;

namespace CryptoApi.Api.Gecko
{
    public class CGeckoCoinsData : IApiCoinsData
    {
        /*IReadOnlyList<CoinFullData> coins_full;*/
        IEnumerable<CoinMarkets> coins_full;
        IReadOnlyList<CoinList> coins;

        string key = "gecko";
        public CGeckoCoinsData (IEnumerable<CoinMarkets> coins_full, IReadOnlyList<CoinList> coins)
        {
            this.coins = coins;
            this.coins_full = coins_full;
        }
        public IEnumerable<IApiCoin> GetEnumerable()
        {
            Console.WriteLine("GetEnumerable");
            foreach(var coin in coins_full)
            {
                //Console.WriteLine("image: " + coin.Image.Large.AbsoluteUri);
                //Console.WriteLine("image: " + coin.Image.Small.AbsoluteUri);
                //Console.WriteLine("image: " + coin.Image.Thumb.AbsoluteUri);
                Console.WriteLine("GetEnumerable++");

                yield return new CApiCoin
                {
                    Image = coin.Image.ToString(),
                    Donor = key,
                    Id = coin.Id,
                    FullName = coin.Name,
                    Name = coin.Symbol,
                    UsdPrice = coin.CurrentPrice,
                    MarketCap = coin.MarketCap,
                    Low = coin.Low24H,
                    High = coin.High24H,

                    CirculatingSupply = coin.CirculatingSupply,
                    TotalSupply = coin.TotalSupply,
                    MarketCapRank = coin.MarketCapRank,
                    TotalVolume = coin.TotalVolume
                };

                /*yield return new CApiCoin
                {
                    Image = coin.Image.Large.AbsoluteUri,
                    Donor = key, 
                    Id = coin.Id, 
                    FullName = coin.Name, 
                    Name = coin.Symbol,
                    UsdPrice = coin.MarketData.CurrentPrice["usd"],
                    MarketCap = coin.MarketData.MarketCap["usd"],
                    Low = coin.MarketData.Low24H["usd"],
                    High = coin.MarketData.High24H["usd"]
                };*/
            }

            /*foreach (var coin in coins)
            {
                yield return new CApiCoin
                {
                    Donor = key,
                    Id = coin.Id,
                    FullName = coin.Name,
                    Name = coin.Symbol
                };
            }*/
        }
    }
}
