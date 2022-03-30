using CryptoApi.Api;
using CryptoApi.Models.DB;

namespace CryptoApi.Services
{
    public class CActualizerM
    {
        private CDbM db;
        private CCoinsM coinsModel;
        private CCoinPairsM coinPairsModel;
        private CApiManager api;
        private IConfiguration conf;
        private IRunnerM runner;

        public CActualizerM (CDbM db, CCoinsM coins, CCoinPairsM pair, CApiManager api, IRunnerM runner)
        {
            this.db = db;
            this.coinsModel = coins;
            this.coinPairsModel = pair;
            this.api = api;
            this.runner = runner;

            conf = new ConfigurationBuilder().AddJsonFile("ConfApi.json").Build();
            var donors = conf.GetSection("Donors");
            api.Init(donors);
        }
        public async Task RefreshDataAsync ()
        {
            await RefreshCoinsAsync();
        }
        public async Task RefreshCoinsAsync()
        {
            var coins = api.GetCoinsAsync().Result;
            await coinsModel.AddCoinsAsync(coins);
        }
        public async Task RunAsync ()
        {
            runner.Run(Int32.Parse(conf["ActualizeTime"]), () => RefreshDataAsync());
        }

        public async Task RunNowAsync ()
        {
            await Task.Run(RefreshDataAsync);
        }

        public async Task LoadCoinsAsync()
        {
            await Task.Run(RefreshCoinsAsync);
        }

        public async Task TestAsync()
        {
            await Task.Run(api.TestAsync);
        }

        public async Task StopAsync ()
        {
            runner.Stop();
        }

        public async Task ClearCoinsAsync()
        {
            db.Coins.RemoveRange(db.Coins);
            await db.SaveChangesAsync();
        }

        public async Task ClearAllAsync()
        {
            await ClearCoinsAsync();
        }
    }
}
