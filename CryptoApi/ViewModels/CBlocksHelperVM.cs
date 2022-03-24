using CryptoApi.Models.DB;
using CryptoApi.Services;

namespace CryptoApi.ViewModels;

/// <summary>
///     Вспомогательный класс (сервис) для удобства работы в файлах cshtml.
/// </summary>
public class CBlocksHelperVM
{
    CDbM db;
    WebApplication app;
    IConfiguration conf;
    CCoinsM coinsModel;
    CCoinPairsM pairsModel;

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CBlocksHelperVM (IConfiguration conf, CDbM db, CCoinsM coins_model, CCoinPairsM pairs_model)
    {
        this.db = db;
        this.coinsModel = coins_model;
        this.pairsModel = pairs_model;
        this.conf = conf;
    }
    /// <summary>
    ///     Возвращает список монет относительно кол-ва и номера страницы.
    /// </summary>
    public IEnumerable<CCoinDataVM> GetCoinList(int count, int page = 1)
    {
        return coinsModel.GetCoins(page, count);
    }
    /// <summary>
    ///     Возвращает список похожих монет относительно текущей.
    /// </summary>
    public IEnumerable<CCoinDataVM> GetCoinList(CCoinDataM coin)
    {
        return  from coin_m in coinsModel.GetSimiliarCoins(coin)
                select new CCoinDataVM() { data = coin_m };
    }
    /// <summary>
    ///     Возвращает список пар относительно кол-ва и номера страницы.
    /// </summary>
    public IEnumerable<CCoinPairDataVM> GetPairList(int count, int page = 1)
    {
        return pairsModel.GetPairs(page, count);
    }
    /// <summary>
    ///     Возвращает список похожих пар относительно текущей.
    /// </summary>
    public IEnumerable<CCoinPairDataVM> GetPairList(CCoinPairDataM pair)
    {
        return from pair_m in pairsModel.GetSimiliarPairs(pair)
               select new CCoinPairDataVM() 
               { 
                   data = pair_m, 
                   coin1 = db.Coins.Find(pair_m.coin1_id), 
                   coin2 = db.Coins.Find(pair_m.coin2_id) 
               };
    }
    /// <summary>
    ///     Возвращает акутальный список ссылок пагинации.
    /// </summary>
    public List<(string Url, string Title)> GetPagination(int max_page, int page, string link_start = "?page=")
    {
        List<(string Url, string Title)> pag_items = new List<(string Url, string Title)>();
        int max_links_per_page = 10;
        int dott_backward_page = (int)Math.Ceiling(decimal.Divide(1 + page, 2));
        int dott_forward_page = (int)Math.Ceiling(decimal.Divide(max_page + page, 2));

        if (max_page <= max_links_per_page)
        {
            for (int i = 1; i <= max_page; i++) 
                pag_items.Add((link_start + i.ToString(), i.ToString()));

            return pag_items;
        }
        if (page == 1)
        {
            string _page = page.ToString();
            pag_items.Add((link_start + _page, _page));
        }
        else if (page > 1)
        {
            if (page == 3) pag_items.Add((link_start + "1", "1"));
            else if (page > 3)
            {
                pag_items.Add((link_start + "1", "1"));
                pag_items.Add((link_start + dott_backward_page.ToString(), "..."));
            }
            if (page == max_page - 1) 
                pag_items.Add((link_start + (page - 2).ToString(), (page - 2).ToString()));
            if (page > 2)
            {
                if (page == max_page && max_page >= 4) // ???
                {
                    pag_items.Add((link_start + (page - 3).ToString(), (page - 3).ToString()));
                    pag_items.Add((link_start + (page - 2).ToString(), (page - 2).ToString()));
                }
                if (max_page < 5) // ???
                    pag_items.Add((link_start + (page - 2).ToString(), (page - 2).ToString()));
            }
            pag_items.Add((link_start + (page - 1).ToString(), (page - 1).ToString()));
            pag_items.Add((link_start + page.ToString(), page.ToString()));
        }
        if (page + 1 < max_page)
        {
            pag_items.Add((link_start + (page + 1).ToString(), (page + 1).ToString()));
            
            if (page == 1) pag_items.Add((link_start + (page + 2).ToString(), (page + 2).ToString()));
            if (page <= 2) pag_items.Add((link_start + "4", "4"));
            if (max_page > 4 && page < max_page - 2) pag_items.Add((link_start + dott_forward_page.ToString(), "..."));
        }
        if (max_page > page) pag_items.Add((link_start + max_page.ToString(), max_page.ToString()));

        return pag_items;
    }
}
