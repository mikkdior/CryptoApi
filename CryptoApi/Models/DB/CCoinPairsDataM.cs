namespace CryptoApi.Models.DB
{
    public class CCoinPairsDataM
    {
        public uint id { get; set; }
        public uint coin1_id { get; set; }
        public uint coin2_id { get; set; }
        public decimal amount { get; set; }
        public string last_mod { get; set; }
        public string slug { get; set; }
        public List<CCoinPairsMetaDataM> meta { get; set; }

        public CCoinPairsDataM ()
        {
            meta = new List<CCoinPairsMetaDataM> ();
        }
    }
}
