using CryptoApi.Services;

namespace CryptoApi.Sitemap
{
    public class CPages
    {
        private List<IPageType> _pages = new();
        public int count
        {
            get 
            { 
                int count = 0;

                foreach (var page in _pages)
                {
                    count += page.count;
                }

                return count;
            }
        }
        public CPages (IServiceProvider services)
        {
            _pages.Add(new CMainPage());
            _pages.Add(new CCoinPage(services.GetService<CCoinsM>()));
            _pages.Add(new CCoinsPage(services.GetService<CCoinsM>()));
            _pages.Add(new CPairPage(services.GetService<CCoinPairsM>()));
            _pages.Add(new CPairsPage(services.GetService<CCoinPairsM>()));
        }

        public IEnumerable<CPageInfo> GetPages ()
        {
            foreach (var page in _pages)
            {
                foreach (var info in page.pages)
                {
                    yield return info;
                }
            }
        }
    }
}
