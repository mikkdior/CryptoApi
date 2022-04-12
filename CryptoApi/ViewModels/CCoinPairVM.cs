using CryptoApi.Services;

namespace CryptoApi.ViewModels;

/// <summary>
///     Вью-Модель (сервис) страницы пары.
/// </summary>
public class CCoinPairVM
{
    private CCoinPairsM model;
    private IConfiguration conf;
    public CCoinPairDataVM pair;
    private CCommonM commonModel;

    /// <summary>
    ///     Возвращает заголовок страницы из БД.
    /// </summary>
    public CTextBlockVM PageHead
    {
        get
        {
            string title = pair.data["pagehead", "title"] != null ? pair.data["pagehead", "title"].value : commonModel["pair pagehead", "title"]?.value;
            string text = pair.data["pagehead", "text"] != null ? pair.data["pagehead", "text"].value : commonModel["pair pagehead", "text"]?.value;

            return new CTextBlockBuilder()
                .SetTitle(title)
                .SetTitleValues(pair.data["pagehead tpl", "title"]?.value)
                .SetTitleData(pair.data)
                .SetText(text)
                .SetTextValues(text)
                .SetTextData(null)
                .Build();
        }
    }
    /// <summary>
    ///     Используя паттерн Buider генерирует модель текстового блока "Описания" и возвращает ее.
    /// </summary>
    public CTextBlockVM Description
    {
        get
        {
            string desc = pair.data["description", "text"] != null ? pair.data["description", "text"].value : commonModel["pair desc", "text"]?.value;
            string title = pair.data["description", "title"] != null ? pair.data["description", "title"].value : commonModel["pair desc", "title"]?.value;

            return new CTextBlockBuilder()
                .SetTitle(title)
                .SetTitleValues(pair.data["desc", "title"]?.value)
                .SetTitleData(pair.data)
                .SetText(desc)
                .SetTextValues(pair.data["desc", "text"]?.value)
                .SetTextData(pair.data)
                .Build();
        }
    }

    /// <summary>
    ///     Используя метод GetTextBlock генерирует перечисление моделей текстовых блоков и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> TextBlocks => GetTextBlocks("pair texts", "texts");

    /// <summary>
    ///     Используя метод GetTextBlock генерирует перечисление моделей текстовых блоков "Faq" и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> Faq => GetTextBlocks("pair faq", "faq");

    /// <summary>
    ///     Генерирует перечисление моделей текстовых блоков по имени группы и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> GetTextBlocks(string group, string coin_group)
    {
        for (var i = 0; i < commonModel[group].Count() / 2; i++)
        {
            string pair_title = pair.data[coin_group, $"title{i + 1}"]?.value;
            string pair_text = pair.data[coin_group, $"text{i + 1}"]?.value;

            string title = pair_title != null ? pair_title : commonModel[group, $"title{i + 1}"].value;
            string text = pair_text != null ? pair_text : commonModel[group, $"text{i + 1}"].value;

            yield return new CTextBlockBuilder()
                .SetTitle(title)
                .SetTitleValues(pair.data["desc", "title"]?.value)
                .SetTitleData(pair.data)
                .SetText(text)
                .SetTextValues(pair.data["desc", "text"]?.value)
                .SetTextData(pair.data)
                .Build();
        }
    }

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinPairVM(CCoinPairsM model, IConfiguration conf, CCommonM common_model)
    {
        this.model = model;
        this.conf = conf;
        this.commonModel = common_model;
    }

    /// <summary>
    ///     Ручная инициализация (заполнение нужных полей).
    /// </summary>
    public void Init(HttpContext context)
    {
        string coin1 = (string)context.GetRouteValue("coin1");
        string coin2 = (string)context.GetRouteValue("coin2");

        pair = model.GetPairByNames(coin1, coin2); 
    }
}
