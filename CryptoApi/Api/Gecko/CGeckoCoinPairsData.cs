using CoinGecko.Entities.Response.Coins;

namespace CryptoApi.Api.Gecko
{
    public class CGeckoCoinPairsData : IApiCoinPairsData
    {
        IReadOnlyList<CoinFullData> coins;

        public CGeckoCoinPairsData(IReadOnlyList<CoinFullData> coins)
        {
            this.coins = coins;
        }

        public IEnumerable<IApiCoinPair> GetEnumerable()
        {
            foreach (CoinFullData coin in coins)
            {
                foreach(var data in coin.MarketData.CurrentPrice)
                {
                    CoinFullData coin2 = null;// Find(data.Key);

                    yield return new CApiCoinPair()
                    {
                        Coin1 = coin.Symbol,
                        Coin2 = data.Key,
                        Price1 = coin.MarketData.CurrentPrice[data.Key].Value,
                        Price2 = coin2 == null ? 0 : coin2.MarketData.CurrentPrice[coin.Symbol].Value,
                        DayPercent = coin.MarketData.PriceChangePercentage24H.Value,
                        DayHight1 = coin.MarketData.High24H[data.Key].Value,
                        DayHight2 = coin2 == null ? 0 : coin2.MarketData.High24H[coin.Symbol].Value,
                        DayLow1 = coin.MarketData.Low24H[data.Key].Value,
                        DayLow2 = coin2 == null ? 0 : coin2.MarketData.Low24H[coin.Symbol].Value,
                        MarketCap = coin.MarketData.MarketCap[data.Key].Value,
                    };
                }
            }
        }

        private CoinFullData Find (string symbol)
        {
            var coin = from c in coins
                       where c.Symbol.ToLower() == symbol.ToLower()
                       select c;

            return coin.First();
        }
    }
}
