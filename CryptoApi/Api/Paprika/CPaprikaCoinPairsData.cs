using CoinpaprikaAPI.Entity;

namespace CryptoApi.Api.Paprika
{
    public class CPaprikaCoinPairsData : IApiCoinPairsData
    {
        public delegate Dictionary<string, OhlcValue> DGetData(string id);
        List<CoinInfo> coins;
        DGetData getData;

        public CPaprikaCoinPairsData (List<CoinInfo> coins, DGetData get_data)
        {
            this.coins = coins;
            getData = get_data;
        }
        public IEnumerable<IApiCoinPair> GetEnumerable()
        {
            int limit = 100;

            foreach (CoinInfo coin in coins)
            {
                var data = getData(coin.Id);
                if (data == null) continue;
                if (limit-- <= 0) yield break;

                foreach (var pair in data)
                {
                    yield return new CApiCoinPair()
                    {
                        Coin1 = coin.Symbol,
                        Coin2 = pair.Key,
                        Price1 = pair.Value.Volume,
                        Price2 = 0,
                        DayPercent = 0,
                        DayHight1 = pair.Value.High,
                        DayHight2 = 0,
                        DayLow1 = pair.Value.Low,
                        DayLow2 = 0,
                        MarketCap = pair.Value.MarketCap
                    };
                }
            }
        }
    }
}
