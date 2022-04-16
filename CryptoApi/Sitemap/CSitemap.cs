namespace CryptoApi.Sitemap;
public class CSitemap : ISitemap
{
    IServiceProvider services;

    public CSitemap(IServiceProvider services)
    {
        this.services = services;
    }
    public async Task CreateAsync()
    {
        var pages = new CPages(services);
        CWriter writer = new CWriter(pages.GetPages(), pages.count);
        /*writer.UpdateMainSitemap();*/
        await Task.Run(() => writer.UpdateMainSitemap());
        /*await Task.Run(() => writer.Write());*/
    }
    public string? GetSubSitemap(int index) 
    {
        var pages = new CPages(services);
        var writer = new CWriter(pages.GetPages(), pages.count);
        writer.UpdateMainSitemap();

        return writer.GetSubSitemap(index);
    } 
}
