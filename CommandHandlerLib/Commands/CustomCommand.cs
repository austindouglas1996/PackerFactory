using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Commands
{
    internal class CustomCommand : ICommand
    {
        /// <summary>
        /// The function to be executed.
        /// </summary>
        private Func<object[], string> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCommand"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="library"></param>
        /// <param name="helpText"></param>
        /// <param name="action"></param>
        /// <remarks>Allow a command to be created without being derived from <see cref="ICommand"/></remarks>
        public CustomCommand(string name, string library, string helpText, Func<object[], string> action)
        {
            this.Name = name;
            this.Library = library;
            this.HelpText = helpText;
            this.action = action;
        }

        /// <summary>
        /// Name of the command.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Library the command belongs in.
        /// </summary>
        public string Library { get; private set; }

        /// <summary>
        /// Breif description about the command.
        /// </summary>
        public string HelpText { get; private set; }

        /// <summary>
        /// Execute the action provided.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult Execute(CommandArgs args)
        {
            CommandResult result = new CommandResult(this);

            try
            {
                var objectArray = new List<object>(args.Arguments).ToArray();
                result.Message = action.Invoke(objectArray);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.ExceptionThrown = e;
                result.ResultType = CommandResultType.ErrorByException;
            }

            return result;
        }
    }
}
