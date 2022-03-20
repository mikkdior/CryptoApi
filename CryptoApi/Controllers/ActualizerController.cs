using CryptoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers
{
    public class ActualizerController : Controller
    {
        CActualizerM actualizer;
        private CCoinsM coinsModel;
        private CCoinPairsM coinPairsModel;
        public ActualizerController (CActualizerM act, CCoinsM coins, CCoinPairsM pair)
        {
            this.actualizer = act;
            this.coinsModel = coins;
            this.coinPairsModel = pair;
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
            actualizer.RunNowAsync();
            return "RunNow";
        }

        [Route("/actualizer/clear")]
        public string Clear()
        {
            actualizer.ClearAllAsync();
            return "Clear";
        }

        [Route("/actualizer/coins-count")]
        public string CoinsCount()
        {
            return $"Coins count: {coinsModel.Count()}";
        }

        [Route("/actualizer/pairs-count")]
        public string PairsCount()
        {
            return $"Pairs count: {coinPairsModel.Count()}";
        }

        [Route("/actualizer/test")]
        public string Test()
        {
            actualizer.TestAsync();
            return "test";
        }
    }
}
