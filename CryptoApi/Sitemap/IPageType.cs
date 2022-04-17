namespace CryptoApi.Sitemap
{
    public interface IPageType
    {
        uint count { get; }
        IEnumerable<CPageInfo> pages { get; }
    }
}
