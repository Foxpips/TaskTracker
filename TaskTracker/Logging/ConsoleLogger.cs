using System;

namespace TaskTracker.Logging
{
    public class ConsoleLogger : ICustomLogger
    {
        public void Error(string message)
        {
            Console.WriteLine("ERROR: " + message);
        }

        public void Info(string message)
        {
            Console.WriteLine("INFO: " + message);
        }
    }
}