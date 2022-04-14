using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers
{
    public class SitemapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
