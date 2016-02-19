namespace TaskTracker.Logging
{
    public interface ICustomLogger
    {
        void Error(string s);
        void Info(string s);
    }
}