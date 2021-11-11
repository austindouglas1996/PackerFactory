using System;

namespace CommandHandlerLib.Commands
{
    public enum CommandResultType
    {
        ErrorByException,
        Error,
        Warning,
        Success,
        NotSpecified = -1
    }
}