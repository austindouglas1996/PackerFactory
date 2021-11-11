using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Helpers
{
    /// <summary>
    /// Writes any errors to a local file.
    /// </summary>
    sealed internal class LogHandler
    {
        /// <summary>
        /// Path to the file to write to.
        /// </summary>
        private const string filePath = "commandHandlerLibLog.txt";

        /// <summary>
        /// Logs an exception to the error log.
        /// </summary>
        /// <param name="ex"></param>
        public static void LogError(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.Append)))
            {
                sw.WriteLine(string.Format("Message: {0} {3} StackTrace: {1} {3} Date: {2}", ex.Message, ex.StackTrace, DateTime.Now.ToString(), Environment.NewLine));
                sw.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        /// <summary>
        /// Logs a command responce to the error log.
        /// </summary>
        /// <param name="responce"></param>
        public static void LogError(CommandInput responce, Exception exception)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.Append)))
            {
                sw.WriteLine(string.Format("Command Info: Name: {2} Arguments: {1}", responce.Name, responce.Arguments, Environment.NewLine));
                sw.WriteLine(string.Format("Message: {0} {3} StackTrace: {1} {3} Date: {2}", exception.Message, exception.StackTrace, DateTime.Now.ToString(), Environment.NewLine));
                sw.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
