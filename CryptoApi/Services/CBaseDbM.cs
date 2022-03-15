using CryptoApi.Models.DB;

namespace CryptoApi.Services
{
    public class CBaseDbM
    {
        protected CDbM db;
        public CBaseDbM (CDbM db)
        {
            this.db = db;
        }
    }
}
