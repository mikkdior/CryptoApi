﻿using CoinGecko.Entities.Response.Coins;
using System.Collections;

namespace CryptoApi.Api.Gecko
{
    public class CGeckoCoinsData : IApiCoinsData
    {
        IReadOnlyList<CoinFullData> coins;
        string key = "gecko";
        public CGeckoCoinsData (IReadOnlyList<CoinFullData> coins)
        {
            this.coins = coins;
        }
        public IEnumerator<IApiCoin> GetEnumerator()
        {
            foreach(var coin in coins)
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
                    ChangeWeek = double.Parse(coin.MarketData.PriceChangePercentage7D),
                    ChangeMonth = double.Parse(coin.MarketData.PriceChangePercentage30D)
                };
            }
        }
    }
}
