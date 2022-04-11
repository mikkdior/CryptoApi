namespace CryptoApi.Sitemap
{
    public class CSitemap : ISitemap
    {
        IServiceProvider services;
        public CSitemap (IServiceProvider services)
        {
            this.services = services;
        }
        public async Task CreateAsync()
        {
            var pages = new CPages(services);
            var writer = new CWriter(pages.GetPages(), pages.count);

            await Task.Run(() => writer.Write()); 
        }
    }
}
