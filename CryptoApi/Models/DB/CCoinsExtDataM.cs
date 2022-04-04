using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApi.Models.DB
{
    public class CCoinsExtDataM
    {
        public uint id { get; set; }
        public uint coins_id { get; set; }
        public decimal? usd_price { get; set; }
        public decimal? market_cap { get; set; }
        public decimal? low { get; set; }
        public decimal? high { get; set; }
        public decimal? change_24h => 2.64m;
        public decimal? volume_24h => 22313546455;
        public decimal? circulating_supply => 18545784;

        public DateTime last_updated { get; set; }

        [ForeignKey("coins_id")]
        public CCoinDataM coin { get; set; }
    }
}
