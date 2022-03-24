 using System.Reflection;

namespace CryptoApi.Api
{
    public class CApiManager
    {
        Dictionary<string, IApiFactory> factories;
        IConfigurationSection donorsData;
        IEnumerator<IApi> apiList;
        string currentApiKey = null;

        private IApi _trueApi;
        private IApi GetTrueApi(string key)
        {
            _trueApi = currentApiKey != key ? GetNextApi(key) : _trueApi;
            currentApiKey = key;
            _trueApi = _trueApi.isLimit ? GetNextApi(key) : _trueApi;

            return _trueApi;
        }
                    
        public CApiManager ()
        {

        }

        public void Init (IConfigurationSection donors)
        {
            this.donorsData = donors;
            CreateFactories();
        }

        private void CreateFactories ()
        {
            factories = new Dictionary<string, IApiFactory>();

            foreach (var donor in donorsData.GetChildren())
            {
                if (donor["Enable"] != "True") continue;
                CreateFactory(donor.Key, donor.GetSection("CommonData"));
            }
        }

        private void CreateFactory (string name, IConfigurationSection data)
        {
            string class_name = $"CryptoApi.Api.CApi{name}Factory";
            var type = Type.GetType(class_name);
            var constructors = Type.GetType(class_name).GetConstructors();
            IApiFactory factory = (IApiFactory)constructors[0].Invoke(new object[] { data });
            factories[name] = factory;
        }

        private IEnumerator<IApi> GetApiList (string key)
        {
            IApiFactory factory = factories[key];
            var factory_data = donorsData.GetSection(key);
            var accs = factory_data.GetSection("Accounts").GetChildren();

            if (accs.Count() == 0)
            {
                yield return factory.CreateApi(null);
                yield break;
            }

            foreach (var acc in accs)
                yield return factory.CreateApi(acc);
        }

        private IApi GetNextApi (string key)
        {
            if (apiList == null || !apiList.MoveNext())
            {
                apiList = GetApiList(key);
                apiList.MoveNext();
            }

            return apiList.Current;
        }

        public async Task<IEnumerable<IApiCoin>> GetCoinsAsync()
        {
            var lists = new List<IApiCoinsData>();

            foreach (var pair in factories)
            {
                var coins = await GetTrueApi(pair.Key).GetCoinsAsync();

                if (coins != null)
                    lists.Add(coins);
            }

            IEnumerable<IApiCoin> GetCoinList ()
            {
                foreach (var list in lists)
                {
                    foreach(var coin in list.GetEnumerable())
                        yield return coin;
                }
            }

            return GetCoinList();
        }

        public async Task<IEnumerable<IApiCoinPair>> GetCoinPairsAsync()
        {
            var lists = new List<IApiCoinPairsData>();

            foreach (var pair in factories)
            {
                var api = GetTrueApi(pair.Key);
                IApiCoinPairsData coins = api.GetCoinPairsAsync().Result;
                
                if (coins != null)
                    lists.Add(coins);
            }

            IEnumerable<IApiCoinPair> GetPairList()
            {
                foreach (var list in lists)
                {
                    foreach (var pair in list.GetEnumerable())
                        yield return pair;
                }
            }

            return GetPairList();
        }

        public async Task<IEnumerable<IApiCoin>> GetCoinsAsync(string key)
        {
            return (await GetTrueApi(key).GetCoinsAsync()).GetEnumerable();
        }

        public async Task<IEnumerable<IApiCoinPair>> GetCoinPairsAsync(string key)
        {
            return (await GetTrueApi(key).GetCoinPairsAsync()).GetEnumerable();
        }

        public async Task TestAsync()
        {
            //await trueApi.TestAsync();
        }
    }
}
