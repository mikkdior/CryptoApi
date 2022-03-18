namespace CryptoApi.Models.DB
{
    public class CCoinDataM
    {
        public uint id { get; set; }
        public string donor { get; set; }
        public string donor_id { get; set; }
        public string name_full { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public decimal usd { get; set; }
        public string image { get; set; }
        public decimal market_cap { get; set; }
        public double change_day { get; set; }
        public double change_week { get; set; }
        public double change_month { get; set; }

        public List<CCoinsMetaDataM> meta { get; set; }

        public CCoinDataM()
        {
            meta = new List<CCoinsMetaDataM>();
        }
    }
}
