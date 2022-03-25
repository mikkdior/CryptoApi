namespace CryptoApi.Services
{
    public interface IRunnerM
    {
        // Должен запускать action в hour часов каждый день
        // (соответственно таймер в отдельном потоке)
        // Предусмотреть, чтобы нельзя было запустить таймер дважды из одного и того же экземпляра IRunnerM
        void Run(int hour, Action action);

        // Останавливает таймер
        void Stop();
    }
}
