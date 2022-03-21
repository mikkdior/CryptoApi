using CryptoApi.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers
{
    public class AdminController : Controller
    {
        private CDbM db;
        public AdminController(CDbM db)
        {
            this.db = db;
        }
        public IActionResult Index() => View();
        public IActionResult CommonMeta() => View();
        [HttpPost]
        public IActionResult CommonMeta(CCommonMetaDataM meta)
        {
            db.CommonMeta.Add(meta);
            db.SaveChanges();

            return Redirect("/admin/commonmeta");
        }
        public IActionResult CoinPairsMeta() => View();
        [HttpPost]
        public IActionResult CoinPairsMeta(CCoinPairsMetaDataM meta)
        {
            db.CoinPairsMeta.Add(meta);
            db.SaveChanges();

            return Redirect("/admin/coinpairsmeta");
        }
        public IActionResult CoinsMeta() => View();
        [HttpPost]
        public IActionResult CoinsMeta(CCoinsMetaDataM meta)
        {
            db.CoinsMeta.Add(meta);
            db.SaveChanges();

            return Redirect("/admin/coinsmeta");
        }
    }
}
