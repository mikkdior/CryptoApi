namespace CryptoApi.ViewModels
{
    public interface ITableVM
    {
        IEnumerable<string> keys { get; }
        IEnumerable<IEnumerable<string>> rows { get; }
    }
}
