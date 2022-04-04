using Microsoft.AspNetCore.Html;

namespace CryptoApi.ViewModels
{
    public interface ITableVM
    {
        IEnumerable<string> keys { get; }
        IEnumerable<IEnumerable<IHtmlContent>> rows { get; }
    }
}
