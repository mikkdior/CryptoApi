namespace CryptoApi.Api
{
    public class CBaseApi
    {
        private IConfigurationSection conf;
        private IConfigurationSection accountData;
        private int requestCount = 0;
        public bool isLimit => requestCount >= Int32.Parse(conf["Limit"]);

        public CBaseApi (IConfigurationSection conf, IConfigurationSection acc)
        {
            this.conf = conf;
            this.accountData = acc;
        }

        public void Inc() => requestCount++;
    }
}
