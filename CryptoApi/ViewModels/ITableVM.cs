using Microsoft.AspNetCore.Html;

namespace CryptoApi.ViewModels
{
    public interface ITableVM
    {
        IEnumerable<IHtmlContent> keys { get; }
        IEnumerable<IEnumerable<IHtmlContent>> rows { get; }
    }
}
