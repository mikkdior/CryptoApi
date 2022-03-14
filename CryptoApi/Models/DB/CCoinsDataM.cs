namespace CryptoApi.Models.DB
{
    public class CCoinsDataM
    {
        public uint id { get; set; }
        public uint donor_id { get; set; }
        public string name_full { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public List<CCoinsMetaDataM> meta { get; set; }

        public CCoinsDataM()
        {
            meta = new List<CCoinsMetaDataM>();
        }
    }
}
