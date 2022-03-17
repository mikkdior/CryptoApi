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
        public List<CCoinsMetaDataM> meta { get; set; }

        public CCoinDataM()
        {
            meta = new List<CCoinsMetaDataM>();
        }
    }
}
