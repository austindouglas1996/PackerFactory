using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Helpers
{
    public class Logger : ILogger
    {
        private const string LogFile = "PackerControlPanel.DataLog.txt";

        public void Log(LogEntry entry)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(LogFile, FileMode.Append)))
            {
                sw.WriteLine(string.Format("[{0}] Message: {1} Exception: {2} StackTrace {3}", 
                    entry.Severity.ToString(), 
                    entry.Message, 
                    entry.Exception.GetType().ToString(), 
                    entry.Exception.StackTrace.ToString()));
            }
        }

        public static Logger GetLogger()
        {
            return new Logger();
        }
    }

    /// <summary>
    /// <see cref="https://stackoverflow.com/questions/5646820/logger-wrapper-best-practice/5646876#5646876"/>
    /// </summary>
    public static class LoggerExtensions
    {
        public static void Log(this Logger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, message));
        }

        public static void Log(this Logger logger, Exception exception)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, exception.Message, exception));
        }

    }
}
