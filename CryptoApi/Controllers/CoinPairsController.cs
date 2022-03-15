using CryptoApi.Models;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers;
public class CoinPairsController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private CDbM db;
    private CBlocksHelperVM blocksHelper;

    public CoinPairsController(ILogger<HomeController> logger, CDbM db, CBlocksHelperVM blocks)
    {
        _logger = logger;

        this.db = db;
        this.blocksHelper = blocks;
    }

    [Route("/crypto-pairs")]
    public IActionResult Index(int page, [FromServices] CCoinPairsVM model)
    {


        return View();
    }

    [Route("/crypto-pairs/{coin1}-to-{coin2}")]
    public IActionResult Pair([FromServices] CCoinPairVM model)
    {

        return View();
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