using CryptoApi.Services;

namespace CryptoApi.ViewModels;

/// <summary>
///     Вью-Модель (сервис) страницы всех монет.
/// </summary>
public class CCoinsVM
{
    public IEnumerable<CCoinDataVM> coins;
    private CCoinsM model;
    private IConfiguration conf;
    public int maxPage;
    public int page;
    public CBlocksHelperVM blocks;

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinsVM(CCoinsM model, IConfiguration conf, CBlocksHelperVM blocks)
    {
        this.model = model;
        this.conf = conf;
        this.blocks = blocks;
    }

    /// <summary>
    ///     Ручная инициализация (заполнение нужных полей).
    /// </summary>
    public void Init(HttpContext context)
    {
        int count = Int32.Parse(conf["CoinsCountOnPage"]);
        maxPage = model.GetMaxPage(count);
        string? page_str = (string?)context.Request.Query["page"];
        page = page_str == null ? 1 : Int32.Parse(page_str);
        page = page <= maxPage ? page : maxPage;
        coins = blocks.GetCoinList(count, page);
    }
}
