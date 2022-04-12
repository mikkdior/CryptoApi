using CryptoApi.Services;

namespace CryptoApi.ViewModels;

/// <summary>
///     Вью-Модель (сервис) страницы монеты.
/// </summary>
public class CCoinVM
{
    public CCoinDataVM coin;
    private CCoinsM model;
    private IConfiguration conf;
    private CCommonM commonModel;

    /// <summary>
    ///     Возвращает заголовок страницы из БД.
    /// </summary>
    public CTextBlockVM PageHead
    {
        get => new CTextBlockBuilder()
                .SetTitle(commonModel["coin pagehead", "title"]?.value)
                .SetTitleValues(coin.data["pagehead", "title"]?.value)
                .SetTitleData(coin.data)
                .SetText(commonModel["coin pagehead", "text"]?.value)
                .SetTextValues(coin.data["pagehead", "text"]?.value)
                .SetTextData(coin.data)
                .Build();
    }
    /// <summary>
    ///     Используя паттерн Buider генерирует модель текстового блока "Описания" и возвращает ее.
    /// </summary>
    public CTextBlockVM Description
    {
        get 
        {
            string desc = coin.data["description", "text"] != null ? coin.data["description", "text"].value : commonModel["coin desc", "text"]?.value;
            string title = coin.data["description", "title"] != null ? coin.data["description", "title"].value : commonModel["coin desc", "title"]?.value;

            return new CTextBlockBuilder()
                .SetTitle(title)
                .SetTitleValues(coin.data["desc tpl", "title"]?.value)
                .SetTitleData(coin.data)
                .SetText(desc)
                .SetTextValues(coin.data["desc tpl", "text"]?.value)
                .SetTextData(coin.data)
                .Build();
        }
    }

    /// <summary>
    ///     Используя метод GetTextBlock генерирует перечисление моделей текстовых блоков и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> TextBlocks => GetTextBlocks("coin texts", "texts");

    /// <summary>
    ///     Используя метод GetTextBlock генерирует перечисление моделей текстовых блоков "Faq" и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> Faq => GetTextBlocks("coin faq", "faq");

    /// <summary>
    ///     Генерирует перечисление моделей текстовых блоков по имени группы и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> GetTextBlocks(string group, string coin_group)
    {
        for (var i = 0; i < commonModel[group].Count() / 2; i++)
        {
            string coin_title = coin.data[coin_group, $"title{i + 1}"]?.value;
            string coin_text = coin.data[coin_group, $"text{i + 1}"]?.value;

            string title = coin_title != null ? coin_title : commonModel[group, $"title{i + 1}"].value;
            string text = coin_text != null ? coin_text : commonModel[group, $"text{i + 1}"].value;

            yield return new CTextBlockBuilder()
                .SetTitle(title)
                .SetTitleValues(coin.data["info tpl", "title"]?.value)
                .SetTitleData(coin.data)
                .SetText(text)
                .SetTextValues(coin.data["info tpl", "text"]?.value)
                .SetTextData(coin.data)
                .Build();
        }
    }

    /// <summary>
    ///     Конструктор. заполняет  необходимые поля при создании модели.
    /// </summary>
    public CCoinVM (CCoinsM model, IConfiguration conf, CCommonM common_model)
    {
        this.model = model;
        this.conf = conf;
        this.commonModel = common_model;
    }

    /// <summary>
    ///     Ручная инициализация (заполнение нужных полей).
    /// </summary>
    public void Init (HttpContext context)
    {
        string? name = (string?)context.GetRouteValue("coin");
        coin = model.GetCoinByName(name);
    }
}
