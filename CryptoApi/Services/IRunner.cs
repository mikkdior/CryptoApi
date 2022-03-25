namespace CryptoApi.Services
{
    public interface IRunner
    {
        void Run(int Hour, Action action);
    }
}
