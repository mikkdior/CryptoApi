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

        public DateTime last_updated { get; set; }

        [ForeignKey("coins_id")]
        public CCoinDataM coin { get; set; }
    }
}
