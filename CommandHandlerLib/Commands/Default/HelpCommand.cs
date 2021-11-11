using CommandHandlerLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Commands
{
    public class HelpCommand : ICommand
    {
        private CommandHandler _handler;

        public HelpCommand(CommandHandler handler)
        {
            this._handler = handler;
        }

        public virtual string Name => "Help";

        public string Library => "Default";

        public virtual string HelpText => "Lists all the commands currently loaded.";

        public virtual CommandResult Execute(CommandArgs args)
        {
            StringBuilder sb = new StringBuilder();

            // Try to get the input from the argument.
            var cInput = args.Sender;

            string _library = string.Empty;
            string _command = string.Empty;

            // Split the argument.
            string[] _cInfo = cInput.Arguments.Count() > 0 ? cInput.Arguments[0].Split('.') : new string[] { };

            // Set the library and command if provided.
            if (_cInfo.Count() == 1)
                _library = _cInfo[0].ToLower();

            else if (_cInfo.Count() == 2)
            {
                _library = _cInfo[0].ToLower();
                _command = _cInfo[1].ToLower();
            }

            // List the commands in order.
            var commands = _handler.Commands.OrderBy(i => i.Library.ToLower()).ToList();

            if (!String.IsNullOrEmpty(_library))
                commands.RemoveAll(cl => cl.Library.ToLower() != _library);

            if (!String.IsNullOrEmpty(_command))
                commands.RemoveAll(c => c.Name.ToLower() != _command);

            if (commands.Count() == 0)
                return new CommandResult(this, "No commands found.", CommandResultType.Error);

            foreach (var command in commands)
            {
                if (command.GetType() == typeof(MethodCommand))
                {
                    MethodCommand mCommand = (MethodCommand)command;

                    // Write the parameters in a custom format.
                    string cmiArguments = "";
                    if (mCommand.Method.GetParameters().Count() > 0)
                        mCommand.Method.GetParameters().ToList().ForEach(p => cmiArguments += string.Format(" <{0} {1}>", p.ParameterType.Name, p.Name));

                    sb.AppendLine(string.Format("{0} {1}", command.Library + "." + command.Name, cmiArguments));
                }
                else
                {
                    sb.AppendLine(string.Format("{0}.{1} <Unknown Arguments>", command.Library, command.Name));
                }
            }

            sb.Append("\n");
            return new CommandResult(this, sb.ToString(), CommandResultType.NotSpecified);
        }
    }
}
