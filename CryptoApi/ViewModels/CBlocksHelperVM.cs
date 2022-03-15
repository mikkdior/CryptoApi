using CryptoApi.Models.DB;

namespace CryptoApi.ViewModels
{
    public class CBlocksHelperVM
    {
        private CDbM db;

        public CBlocksHelperVM (CDbM db)
        {
            this.db = db;
        }
    }
}
