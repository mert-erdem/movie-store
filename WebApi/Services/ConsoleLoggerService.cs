namespace MovieStore.Services;

public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine("[ConsoleLogger] - " + message);
    }
}