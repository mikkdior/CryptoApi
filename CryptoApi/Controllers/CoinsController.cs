using CryptoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers;
public class CoinsController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public CoinsController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/coins")]
    public IActionResult Index(int page)
    {


        return View();
    }
    [Route("/coins/{coin}")]
    public IActionResult Coin()
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