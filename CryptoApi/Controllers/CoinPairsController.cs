using CryptoApi.Models;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers;
/// <summary>
///     Контроллер страниц всех пар и конкретной пары.
/// </summary>
public class CoinPairsController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private CDbM db;
    private CBlocksHelperVM blocksHelper;

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CoinPairsController(ILogger<HomeController> logger, CDbM db, CBlocksHelperVM blocks)
    {
        _logger = logger;

        this.db = db;
        this.blocksHelper = blocks;
    }

    /// <summary>
    ///     Отображает страницу всех пар.
    /// </summary>
    [Route("/crypto-pairs")]
    public IActionResult Index(int page, [FromServices] CCoinPairsVM model)
    {
        ViewBag.Blocks = blocksHelper;
        model.Init(HttpContext);

        return View(model);
    }

    /// <summary>
    ///     Отображает страницу конкретной пары. Через get параметры принимает идентификаторы самих пар.
    /// </summary>
    [Route("/crypto-pairs/{coin1}-to-{coin2}")]
    public IActionResult Pair([FromServices] CCoinPairVM model)
    {
        ViewBag.Blocks = blocksHelper;
        model.Init(HttpContext);

        return View(model);
    }

    /// <summary>
    ///     Отображает страницу Privacy.
    /// </summary>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    ///     Отображает страницу ошибки.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}