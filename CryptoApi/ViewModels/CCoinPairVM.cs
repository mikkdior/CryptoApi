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
    ///     Используя паттерн Buider генерирует модель текстового блока "Описания" и возвращает ее.
    /// </summary>
    public CTextBlockVM Description
    {
        get
        {
            return new CTextBlockBuilder()
                .SetTitle(commonModel["pair desc", "title"]?.value)
                .SetTitleValues(pair.data["desc", "title"]?.value)
                .SetTitleData(pair.data)
                .SetText(commonModel["pair desc", "text"]?.value)
                .SetTextValues(pair.data["desc", "text"]?.value)
                .SetTextData(pair.data)
                .Build();
        }
    }

    /// <summary>
    ///     Используя метод GetTextBlock генерирует перечисление моделей текстовых блоков и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> TextBlocks => GetTextBlock("pair texts");

    /// <summary>
    ///     Используя метод GetTextBlock генерирует перечисление моделей текстовых блоков "Faq" и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> Faq => GetTextBlock("pair faq");

    /// <summary>
    ///     Генерирует перечисление моделей текстовых блоков по имени группы и возвращает их.
    /// </summary>
    public IEnumerable<CTextBlockVM> GetTextBlock(string group)
    {
        for (var i = 0; i < commonModel[group].Count() / 2; i++)
        {
            string title = commonModel[group, $"title{i + 1}"].value;
            string text = commonModel[group, $"text{i + 1}"].value;

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
