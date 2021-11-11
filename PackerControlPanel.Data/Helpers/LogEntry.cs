using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Helpers
{
    public enum LoggingEventType { Debug, Information, Warning, Error, Fatal };

    /// <summary>
    /// <see cref="https://stackoverflow.com/questions/5646820/logger-wrapper-best-practice/5646876#5646876"/>
    /// </summary>
    public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (message == string.Empty) throw new ArgumentException("empty", "message");

            this.Severity = severity;
            this.Message = message;
            this.Exception = exception;
        }
    }
}
