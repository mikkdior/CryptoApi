using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Models.DB
{
    public class CDbM: DbContext
    {
        public DbSet<CCoinDataM> Coins { get; set; }
        public DbSet<CCoinPairDataM> CoinPairs { get; set; }
        public DbSet<CCoinsMetaDataM> CoinsMeta { get; set; }
        public DbSet<CCoinPairsMetaDataM> CoinPairsMeta { get; set; }
        public DbSet<CCommonMetaDataM> CommonMeta { get; set; }

        public CDbM(DbContextOptions<CDbM> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
