﻿namespace CryptoApi.Api.Paprika
{
    public class CApiPaprika : CBaseApi, IApi
    {
        public CApiPaprika(IConfigurationSection conf, IConfigurationSection acc) : base(conf, acc)
        {
        }
        public async Task<IApiCoinsData> GetCoinsAsync()
        {
            Inc();
            Console.WriteLine("CApiPaprika");
            return default;
        }
    }
}
