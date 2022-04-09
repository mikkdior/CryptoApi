namespace CryptoApi.Sitemap
{
    public interface IPageType
    {
        int count { get; }
        IEnumerable<CPageInfo> pages { get; }
    }
}
