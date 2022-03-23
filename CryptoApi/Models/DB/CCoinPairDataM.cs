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
        public ICollection<CCoinPairsMetaDataM> meta { get; set; }
        public CCoinPairDataM ()
        {
            meta = new List<CCoinPairsMetaDataM> ();
        }

        public IEnumerable<CCoinPairsMetaDataM> this[string group]
        {
            get
            {
                int c = meta.Count;
                IEnumerable<CCoinPairsMetaDataM> data = meta.Where(x => x.group == group);
                return data;
                /*return meta.Where(x => x.group == group);*/
            }
        }
        public CCoinPairsMetaDataM this[string group, string option]
        {
            get
            {
                return meta.Where(x => x.group == group && x.option == option).FirstOrDefault();
            }
        }
    }
}
