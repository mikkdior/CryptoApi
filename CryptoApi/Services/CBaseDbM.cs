using CryptoApi.Models.DB;

namespace CryptoApi.Services
{
    public class CBaseDbM
    {
        public CDbM db;
        public CBaseDbM (CDbM db)
        {
            this.db = db;
        }
    }
}
