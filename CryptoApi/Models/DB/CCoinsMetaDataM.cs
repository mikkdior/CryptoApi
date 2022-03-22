using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApi.Models.DB
{
    public class CCoinsMetaDataM
    {
        public uint id { get; set; }
        public uint coinid { get; set; }
        public string group { get; set; }
        public string option { get; set; }
        public string value { get; set; }
        public CCoinDataM coin { get; set; }
    }
}
