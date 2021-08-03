namespace Assignment1
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
        void LogPrint(string message);
    }
}
