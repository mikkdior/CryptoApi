using CryptoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers;
public class CoinPairsController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public CoinPairsController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/crypto-pairs")]
    public IActionResult Index(int page)
    {


        return View();
    }

    [Route("/crypto-pairs/{coin1}-to-{coin2}")]
    public IActionResult Pair()
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