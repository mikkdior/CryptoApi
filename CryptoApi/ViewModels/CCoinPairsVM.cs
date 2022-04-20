using CryptoApi.Services;

namespace CryptoApi.ViewModels;

/// <summary>
///     Вью-Модель (сервис) страницы всех пар.
/// </summary>
public class CCoinPairsVM
{
    private CCoinPairsM model;
    public IEnumerable<CCoinPairDataVM> pairs;
    private IConfiguration conf;
    public int maxPage = 10;
    public int page = 1;
    public CBlocksHelperVM blocks;
    private CCommonM commonModel;

    public CTextBlockVM SeoInfo
    {
        get => new CTextBlockBuilder()
                .SetTitle(commonModel["pairs seo", "title"]?.value)
                .SetText(commonModel["pairs seo", "text"]?.value)
                .Build();
    }
    /// <summary>
    ///     Возвращает заголовок страницы из БД.
    /// </summary>
    public CTextBlockVM PageHead
    {
        get => new CTextBlockBuilder()
                .SetTitle(commonModel["pairs pagehead", "title"]?.value)
                .SetText(commonModel["pairs pagehead", "text"]?.value)
                .Build();
    }
    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinPairsVM(CCoinPairsM model, IConfiguration conf, CBlocksHelperVM blocks, CCommonM common_model)
    {
        this.model = model;
        this.conf = conf;
        this.blocks = blocks;
        this.commonModel = common_model;
    }
    /// <summary>
    ///     Ручная инициализация (заполнение нужных полей).
    /// </summary>
    public void Init(HttpContext context, string filter = "")
    {
        /*int count = Int32.Parse(conf["PairsCountOnPage"]);
        maxPage = model.GetMaxPage(count, filter);
        maxPage = maxPage == 0 ? 1 : maxPage;

        string? page_str = (string?)context.Request.Query["page"];
        page = page_str == null ? 1 : Int32.Parse(page_str);
        page = page <= maxPage ? page : maxPage;
        pairs = blocks.GetPairList(count, page, filter);*/

        string? page_str = (string?)context.Request.Query["page"];
        page = page_str == null ? 1 : Int32.Parse(page_str);

        int count = Int32.Parse(conf["PairsCountOnPage"]);
        if (page < 2) count++;

        maxPage = model.GetMaxPage(count, filter);
        maxPage = maxPage == 0 ? 1 : maxPage;

        page = page <= maxPage ? page : maxPage;
        pairs = blocks.GetPairList(count, page, filter);
    }
}
