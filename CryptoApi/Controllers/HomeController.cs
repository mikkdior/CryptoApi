using CryptoApi.Models;
using CryptoApi.Models.DB;
using CryptoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CDbM db;
        private CBlocksHelperVM blocksHelper;

        public HomeController(ILogger<HomeController> logger, CDbM db, CBlocksHelperVM blocks)
        {
            _logger = logger;

            this.db = db;
            this.blocksHelper = blocks;
        }

        public IActionResult Index([FromServices] CHomeVM model)
        {
            ViewBag.Blocks = blocksHelper;
            return View(model);
        }

        [Route("/test")]
        public string Test()
        {
            return "";
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
}