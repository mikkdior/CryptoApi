using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApi.Models.DB
{
    public class CCoinsExtDataM : IUpdatedData
    {
        public uint id { get; set; }
        public uint coins_id { get; set; }

        public decimal? change_week => 12.71m;
        public decimal? change_month => 15.33m;
        public decimal? change_day => 3.17m;
        public decimal? change_24h => 2.06m;

        public decimal? usd_price { get; set; }
        public decimal? market_cap { get; set; }
        public decimal? low { get; set; }
        public decimal? high { get; set; }

        public DateTime last_updated { get; set; }

        public string circulating_supply { get; set; }
        public string total_supply { get; set; }
        public long? market_cap_rank { get; set; }
        public decimal? total_volume { get; set; }


        [ForeignKey("coins_id")]
        public CCoinDataM coin { get; set; }
    }
}
