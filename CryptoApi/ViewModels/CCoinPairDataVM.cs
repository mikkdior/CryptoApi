using CryptoApi.Models.DB;

namespace CryptoApi.ViewModels
{
    public class CCoinPairDataVM
    {
        public CCoinPairDataM data;
        public CCoinDataM coin1;
        public CCoinDataM coin2;
        public List<CCoinPairsMetaDataM> meta { get; set; }

        public CCoinPairDataVM ()
        {
            meta = new List<CCoinPairsMetaDataM> ();
        }
    }
}
