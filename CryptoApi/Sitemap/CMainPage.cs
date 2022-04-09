namespace CryptoApi.Sitemap
{
    public class CMainPage : IPageType
    {
        public int count => 1;

        public IEnumerable<CPageInfo> pages
        {
            get
            {
                yield return new CPageInfo() { url = "/" };
            }
        }
    }
}
