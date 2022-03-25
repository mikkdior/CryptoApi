using CryptoApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers;

/// <summary>
///     Контроллер страниц Администратора. Возможности: добавление метаданных в БД.
/// </summary>
public class AdminController : Controller
{
    private CDbM db;

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public AdminController(CDbM db)
    {
        this.db = db;
    }
    /// <summary>
    ///     Отображает главную страницу админ панели.
    /// </summary>
    public IActionResult Index() => View();

    /// <summary>
    ///     Отображает страницу админ панели, на которой находится пустая форма для добавления метаданных таблицы БД "CommonMeta".
    /// </summary>
    public IActionResult CommonMeta() => View();
    [HttpPost]

    /// <summary>
    ///     Принимает входные метаданные заполненной формы и сохраняет их в БД.
    ///     После чего перенаправляет на страницу админ панели, на которой находится пустая форма для добавления метаданных таблицы БД "CommonMeta".
    /// </summary>
    public IActionResult CommonMeta(CCommonMetaDataM meta)
    {
        db.CommonMeta.Add(meta);
        db.SaveChanges();

        return Redirect("/admin/commonmeta");
    }

    /// <summary>
    ///     Отображает страницу админ панели, на которой находится пустая форма для добавления метаданных таблицы БД "CoinPairsMeta".
    /// </summary>
    public IActionResult CoinPairsMeta() => View();

    /// <summary>
    ///     Принимает входные метаданные заполненной формы и сохраняет их в БД. 
    ///     После чего перенаправляет на страницу админ панели, на которой находится пустая форма для добавления метаданных таблицы БД "CoinPairsMeta".
    /// </summary>
    [HttpPost]
    public IActionResult CoinPairsMeta(CCoinPairsMetaDataM meta)
    {
        db.CoinPairsMeta.Add(meta);
        db.SaveChanges();

        return Redirect("/admin/coinpairsmeta");
    }

    /// <summary>
    ///     Отображает страницу админ панели, на которой находится пустая форма для добавления метаданных таблицы БД "CoinsMeta".
    /// </summary>
    public IActionResult CoinsMeta() => View();

    /// <summary>
    ///     Принимает входные метаданные заполненной формы и сохраняет их в БД. 
    ///     После чего перенаправляет на страницу админ панели, на которой находится пустая форма для добавления метаданных таблицы БД "CoinsMeta".
    /// </summary>
    [HttpPost]
    public IActionResult CoinsMeta(CCoinsMetaDataM meta)
    {
        db.CoinsMeta.Add(meta);
        db.SaveChanges();

        return Redirect("/admin/coinsmeta");
    }
}
