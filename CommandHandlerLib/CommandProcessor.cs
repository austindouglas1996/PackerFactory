using CommandHandlerLib.Attributes;
using CommandHandlerLib.Commands;
using CommandHandlerLib.Exceptions;
using CommandHandlerLib.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib
{
    /// <summary>
    /// Processes and executes a command based on <see cref="CommandInput"/>.
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>
        /// The owner of this proccessor.
        /// </summary>
        private CommandHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProcessor"/> class.
        /// </summary>
        /// <param name="handler"></param>
        public CommandProcessor(CommandHandler handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Process a string to get information on the command trying to be executed.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ICommand ProcessString(CommandInput input)
        {
            // The selected command.
            ICommand selectedCommand = null;

            string missingArguments = string.Format("Missing required arguments for the command '{0}' in the library '{1}'", input.Name, input.LibraryName);

            // Unable to find the library?
            if (handler.Commands.Find(c => c.Library.ToLower() == input.LibraryName.ToLower()) == null)
                throw new CommandNotFoundException(string.Format("Unable to find the library '{0}'.", input.LibraryName));

            // Unable to find any command by the name provided?
            if (handler.Commands.Find(c => c.Name.ToLower() == input.Name.ToLower()) == null)
                throw new CommandNotFoundException(string.Format("Unable to find a command by the name '{0}' within any library.", input.Name));

            // Find all commands by name and library..
            var commandList = handler.Commands.FindAll(c => c.Name.ToLower() == input.Name.ToLower() && c.Library.ToLower() == input.LibraryName.ToLower());

            // Unable to find any command by name in the specified library.
            if (commandList == null || commandList.Count == 0)
                throw new CommandNotFoundException(string.Format("Unable to find the command '{0}' within the specified library '{1}'.", input.Name, input.LibraryName));

            // Stores command parameter information.
            StringBuilder methodParamSb = new StringBuilder();
            methodParamSb.AppendLine(missingArguments);
            
            foreach (var command in commandList)
            {
                if (command.GetType() == typeof(MethodCommand))
                {
                    var mCommand = (MethodCommand)command;
                    IEnumerable<ParameterInfo> ParamInfoList = mCommand.Method.GetParameters();
                    var requiredParam = ParamInfoList.Where(p => p.IsOptional == false);
                    var optionalParam = ParamInfoList.Where(p => p.IsOptional == true);

                    int requiredParamCount = requiredParam.Count();
                    int optionalParamCount = optionalParam.Count();
                    int presentedParamCount = input.Arguments.Count();

                    // In case this method and any other method within the loop is not the right
                    // method we will add them to a StringBuilder so the user can be presented
                    // with a list of acceptable arguments with the method.
                    methodParamSb.AppendLine(string.Format("{0} [{1}] Marked Optional [{2}]",
                        input.Name, string.Join(" ", requiredParam), string.Join(" ", optionalParam)));

                    if (requiredParamCount > presentedParamCount ||
                        presentedParamCount > (requiredParamCount + optionalParamCount))
                        continue;

                    try
                    {
                        var values = MethodCommand.ConvertArgsToParameterType(ParamInfoList.ToList(), input.Arguments);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    // Set the selected command.
                    selectedCommand = command;
                    break;
                }
                else
                {
                    selectedCommand = command;
                    break;
                }
            }

            // No suitable command found.
            if (selectedCommand == null)
                throw new CommandNotFoundException(methodParamSb.ToString());

            return selectedCommand;
        }

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="cInput"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public CommandResult ExecuteCommand(CommandInput cInput, ICommand command)
        {
            if (cInput == null)
                throw new ArgumentNullException("cInput cannot be null.");

            return command.Execute(new CommandArgs(cInput));
        }
    }
}
