using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Helpers
{
    /// <summary>
    /// <see cref="https://stackoverflow.com/questions/5646820/logger-wrapper-best-practice/5646876#5646876"/>
    /// </summary>
    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}
