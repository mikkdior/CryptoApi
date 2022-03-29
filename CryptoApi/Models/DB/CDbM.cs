using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Models.DB;

/// <summary>
///     Модель БД.
/// </summary>
public class CDbM: DbContext
{
    public DbSet<CCoinDataM> Coins { get; set; }
    public DbSet<CCoinsExtDataM> CoinsExt { get; set; }
    public DbSet<CCoinsMetaDataM> CoinsMeta { get; set; }
    public DbSet<CCoinPairDataM> CoinPairs { get; set; }
    public DbSet<CCoinPairsMetaDataM> CoinPairsMeta { get; set; }
    public DbSet<CCommonMetaDataM> CommonMeta { get; set; }

    /// <summary>
    ///     Конструктор. Создает базу данных при первом обращении.
    /// </summary>
    public CDbM(DbContextOptions<CDbM> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
