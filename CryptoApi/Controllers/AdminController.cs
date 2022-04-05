using CryptoApi.Models.DB;
using CryptoApi.Services;
using CryptoApi.ViewModels;
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
    public IActionResult CoinPairsMeta(CCoinPairsMetaDataM meta, string name1, string name2, [FromServices] CCoinsM model)
    {
        var coin1 = model.GetCoinByName(name1);
        var coin2 = model.GetCoinByName(name2);
        meta.coin_1_id = coin1.data.id;
        meta.coin_2_id = coin2.data.id;
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
    public IActionResult CoinsMeta(CCoinsMetaDataM meta, string name, [FromServices] CCoinsM model)
    {
        var coin = model.GetCoinByName(name);
        meta.coins_id = coin.data.id;
        meta.coin = coin.data;
        db.CoinsMeta.Add(meta);
        db.SaveChanges();

        return Redirect("/admin/coinsmeta");
    }
}
