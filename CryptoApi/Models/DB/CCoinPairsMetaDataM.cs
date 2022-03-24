namespace CryptoApi.Models.DB
{
    public class CCoinPairsMetaDataM
    {
        public uint id { get; set; }
        public uint coinpairsid { get; set; }
        public string group { get; set; }
        public string option { get; set; }
        public string value { get; set; }
        public CCoinPairDataM pair { get; set; }
    }
}
