namespace CryptoApi.Models.DB
{
    public class CCoinPairDataM
    {
        public uint id { get; set; }
        public uint coin1_id { get; set; }
        public uint coin2_id { get; set; }
        public string price_1 { get; set; }
        public string price_2 { get; set; }
        public string day_percent { get; set; }
        public string day_hight_1 { get; set; }
        public string day_hight_2 { get; set; }
        public string day_low_1 { get; set; }
        public string day_low_2 { get; set; }
        public string market_cap { get; set; }
    }
}
