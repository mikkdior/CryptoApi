namespace CryptoApi.Services;
public class CRunnerM : IRunnerM
{
    private bool Buzy = false;
    private CancellationTokenSource? CancellationSource;
    private Task? CurrTask;

    public void Run(int hour, Action action)
    {
        if (Buzy) return;
        Buzy = true;

        CancellationSource = new CancellationTokenSource();
        var token = CancellationSource.Token;

        int min = 0;
        int sec = 0;

        CurrTask = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                TimeSpan start_execution_span = GetNextExecutionSpan(hour, min, sec);

                try { Task.Delay(start_execution_span).Wait(token); }
                catch (OperationCanceledException) { break; }

                while (!token.IsCancellationRequested)
                {
                    action();
                    TimeSpan next_execution_span = GetNextExecutionSpan(hour, min, sec);
                    Task.Delay(next_execution_span).Wait();
                }
            }
        });
    }
    private TimeSpan GetNextExecutionSpan(int hour, int min, int sec)
    {
        var execute_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, min, sec);
        if (execute_time <= DateTime.Now) execute_time = execute_time.AddDays(1);

        return execute_time - DateTime.Now;
    }
    public void Stop()
    {
        if (!Buzy) return;
        CancellationSource?.Cancel();
        CurrTask?.Wait();
    }
}
