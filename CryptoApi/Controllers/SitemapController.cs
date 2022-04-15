using CryptoApi.Sitemap;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Host;

namespace CryptoApi.Controllers;
public class SitemapController : Controller
{
    [Route("/sitemap-{index:int}.xml")]
    public IActionResult Index([FromServices] CSitemap sitemapModel, int index) 
    {
        string? result = sitemapModel.GetSubSitemap(index);

        return result != null ? View(result) : throw new HttpException(404, "Page you requested is not found");
    }
}
