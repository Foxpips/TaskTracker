using System.Linq;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;

namespace TaskTracker.Logging
{
    internal class Log4NetFileLogger : ICustomLogger
    {
        public static ILog Logger { get; set; }

        public Log4NetFileLogger()
        {
            XmlConfigurator.Configure();
            Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void SetOutputPath(string outputPath)
        {
            var appender = LogManager.GetRepository().GetAppenders().First(x => x is RollingFileAppender);
            var fileAppender = ((FileAppender) appender);
            fileAppender.File = outputPath;
            fileAppender.ActivateOptions();
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }
    }
}