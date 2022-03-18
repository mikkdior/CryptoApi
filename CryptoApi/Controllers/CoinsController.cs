using CryptoApi.Models;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers;
public class CoinsController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private CDbM db;
    private CBlocksHelperVM blocksHelper;

    public CoinsController(ILogger<HomeController> logger, CDbM db, CBlocksHelperVM blocks)
    {
        _logger = logger;

        this.db = db;
        this.blocksHelper = blocks;
    }

    [Route("/coins")]
    public IActionResult Index(int page, [FromServices] CCoinsVM model)
    {
        ViewBag.Blocks = blocksHelper;
        model.Init(HttpContext);
        return View(model);
    }
    [Route("/coins/{coin}")]
    public IActionResult Coin([FromServices] CCoinVM model)
    {
        ViewBag.Blocks = blocksHelper;
        model.Init(HttpContext);
        return View(model);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}