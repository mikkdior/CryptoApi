using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApi.Models.DB
{
    public class CCoinsExtDataM
    {
        public uint id { get; set; }
        public uint coins_id { get; set; }
        public decimal usd { get; set; }
        public string market_cap { get; set; }
        public string change_day { get; set; }
        public string change_week { get; set; }
        public string change_month { get; set; }
        public string change_price { get; set; }
        public DateTime last_updated { get; set; }

        [ForeignKey("coins_id")]
        public CCoinDataM coin { get; set; }
    }
}
