namespace CryptoApi.Sitemap;
public class CSitemap : ISitemap
{
    IServiceProvider services;
    CWriter writer;

    public CSitemap(IServiceProvider services)
    {
        this.services = services;
    }
    public async Task CreateAsync()
    {
        var pages = new CPages(services);
        writer = new CWriter(pages.GetPages(), pages.count);

        await Task.Run(() => writer.UpdateMainSitemap());      /*await Task.Run(() => Writer.Write());*/
    }
    public string? GetSubSitemap(int index) => writer != null? writer.GetSubSitemap(index) : null;
}
