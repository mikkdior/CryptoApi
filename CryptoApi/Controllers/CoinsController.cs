using CryptoApi.Models;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers;

/// <summary>
///     Контроллер страниц всех монет и конкретной монеты.
/// </summary>
public class CoinsController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private CDbM db;
    private CBlocksHelperVM blocksHelper;

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CoinsController(ILogger<HomeController> logger, CDbM db, CBlocksHelperVM blocks)
    {
        _logger = logger;

        this.db = db;
        this.blocksHelper = blocks;
    }

    /// <summary>
    ///     Отображает страницу всех монет.
    /// </summary>
    [Route("/coins")]
    public IActionResult Index([FromServices] CCoinsVM model, int page, string? filter = null, string? order = null)
    {
        if (filter == null && order == null)
        {
            model.Init(HttpContext);
        }
        else
        {
            if (filter == "" || filter == "#" && order == "" || order == "#") return Redirect($"/coins");

            model.Init(HttpContext, filter, order);
        }

        return View(model);
    }

    /// <summary>
    ///     Отображает страницу конкретной монеты. Через get параметры принимает идентификатор самой монеты.
    /// </summary>
    [Route("/coins/{coin}")]
    public IActionResult Coin([FromServices] CCoinVM model)
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