using CryptoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers
{
    public class ActualizerController : Controller
    {
        CActualizerM actualizer;
        public ActualizerController (CActualizerM act)
        {
            this.actualizer = act;
        }

        [Route("/actualizer")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/actualizer/run")]
        public string Run()
        {
            actualizer.RunAsync();
            return "run";
        }

        [Route("/actualizer/stop")]
        public string Stop()
        {
            actualizer.StopAsync();
            return "stop";
        }

        [Route("/actualizer/run-now")]
        public string RunNow()
        {
            
            actualizer.RunNowAsync(HttpContext);
            return "RunNow";
        }

        [Route("/actualizer/clear")]
        public string Clear()
        {
            actualizer.ClearAllAsync();
            return "Clear";
        }
    }
}
