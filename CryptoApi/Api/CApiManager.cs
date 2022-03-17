using System.Reflection;

namespace CryptoApi.Api
{
    public class CApiManager
    {
        Dictionary<string, IApiFactory> factories;
        IConfigurationSection donorsData;
        IEnumerator<IApi> apiList;

        private IApi _trueApi;
        private IApi trueApi
        {
            get 
            {
                _trueApi = _trueApi ?? GetNextApi();
                _trueApi = _trueApi.isLimit ? GetNextApi() : _trueApi;

                return _trueApi; 
            }
        }
                    
        public CApiManager ()
        {

        }

        public void Init (IConfigurationSection donors)
        {
            this.donorsData = donors;
            CreateFactories();
            apiList = GetApiList();
        }

        private void CreateFactories ()
        {
            factories = new Dictionary<string, IApiFactory>();

            foreach (var donor in donorsData.GetChildren())
            {
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

        private IEnumerator<IApi> GetApiList ()
        {
            foreach (var factory_pair in factories)
            {
                string key = factory_pair.Key;
                IApiFactory factory = factory_pair.Value;
                var factory_data = donorsData.GetSection(key);


                foreach (var acc in factory_data.GetSection("Accounts").GetChildren())
                    yield return factory.CreateApi(acc);
            }
        }

        private IApi GetNextApi ()
        {
            if (!apiList.MoveNext())
            {
                apiList = GetApiList();
                apiList.MoveNext();
            }

            return apiList.Current;
        }

        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            return await trueApi.GetCoinsAsync();
        }

        public async Task GetPairAsync()
        {

        }
    }
}
