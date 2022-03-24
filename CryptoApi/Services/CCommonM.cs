using CryptoApi.Models.DB;

namespace CryptoApi.Services;

/// <summary>
///     Класс предназначен для работы с common метаданными.
/// </summary>
public class CCommonM : CBaseDbM
{
    /// <summary>
    ///     Конструктор модели сервиса common. Передает экземпляр модели базы данных родителю.
    /// </summary>
    public CCommonM(CDbM db) : base(db) { }

    /// <summary>
    ///     Возвращает все метаданные common, при условии совпадения group.
    /// </summary>
    public IEnumerable<CCommonMetaDataM> this[string group]
    {
        get
        {
            return db.CommonMeta.Where(x => x.group == group);
        }
    }
    /// <summary>
    ///     Возвращает все метаданные common, при условии совпадения group & option.
    /// </summary>
    public CCommonMetaDataM this[string group, string option]
    {
        get
        {
            return db.CommonMeta.Where(x => x.group == group && x.option == option).FirstOrDefault();
        }
    }
}
