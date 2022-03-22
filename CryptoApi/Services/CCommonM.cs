using CryptoApi.Models.DB;

namespace CryptoApi.Services
{
    public class CCommonM : CBaseDbM
    {
        public CCommonM(CDbM db) : base(db)
        {
        }

        public IEnumerable<CCommonMetaDataM> this[string group]
        {
            get
            {
                return db.CommonMeta.Where(x => x.group == group);
            }
        }
        public CCommonMetaDataM this[string group, string option]
        {
            get
            {
                return db.CommonMeta.Where(x => x.group == group && x.option == option).FirstOrDefault();
            }
        }
    }
}
