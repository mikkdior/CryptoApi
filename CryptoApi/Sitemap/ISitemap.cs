namespace CryptoApi.Sitemap
{
    public interface ISitemap
    {
        Task CreateAsync();
        string? GetSubSitemap(int index);
    }
}
