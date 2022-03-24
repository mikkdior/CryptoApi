using CryptoApi.Models.DB;

namespace CryptoApi.ViewModels;

/// <summary>
///     Вью-Модель данных пары.
/// </summary>
public class CCoinPairDataVM
{
    public CCoinPairDataM data;
    public CCoinDataM coin1;
    public CCoinDataM coin2;
    public List<CCoinPairsMetaDataM> meta { get; set; }

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinPairDataVM ()
    {
        meta = new List<CCoinPairsMetaDataM> ();
    }
}
