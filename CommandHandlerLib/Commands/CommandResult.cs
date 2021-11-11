using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Commands
{
    public class CommandResult
    {

        public CommandResult(ICommand sender)
            : this("")
        {
            this.Command = sender;
        }

        public CommandResult(string message)
        {
            this.Message = message;
            this.ResultType = CommandResultType.NotSpecified;
        }

        public CommandResult(ICommand cmd, string message, CommandResultType result, Exception e = null)
        {
            this.Command = cmd;
            this.Message = message;

            if (e == null)
                this.ResultType = result;
            else
                this.ResultType = CommandResultType.ErrorByException;

            this.ExceptionThrown = e;
        }

        public ICommand Command { get; set; }
        public string Message { get; set; }

        public CommandResultType ResultType { get; set; }
        public Exception ExceptionThrown { get; set; }

    }
}
