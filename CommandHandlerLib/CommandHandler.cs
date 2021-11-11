using CommandHandlerLib.Commands;
using CommandHandlerLib.Exceptions;
using CommandHandlerLib.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib
{
    public class CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler"/> class.
        /// </summary>
        public CommandHandler()
        {
            this.commands = new List<ICommand>();
            this.processor = new CommandProcessor(this);
            this.CommandHistory = new CommandHistory();

            // Add default commands.
            this.AddCommand(new HelpCommand(this));
        }

        /// <summary>
        /// Gets or sets a value indicating whether to throw exceptions caught on command execution. Default is false.
        /// </summary>
        public bool ThrowExceptions
        {
            get { return this._throwExceptions; }
            set { this._throwExceptions = value; }
        }
        private bool _throwExceptions = false;

        /// <summary>
        /// Gets or sets the collection of commands.
        /// </summary>
        public List<ICommand> Commands
        {
            get { return this.commands; }
            set { this.commands = value; }
        }
        private List<ICommand> commands;

        /// <summary>
        /// Gets the history of commands executed so far.
        /// </summary>
        public CommandHistory CommandHistory { get; private set; }

        /// <summary>
        /// Gets the command processor which helps with locating and executing commands.
        /// </summary>
        public CommandProcessor Processor
        {
            get { return this.processor; }
            set { this.processor = value; }
        }
        private CommandProcessor processor;

        public void AddCommand(params ICommand[] commands)
        {
            this.commands.AddRange(commands);
        }

        public void AddCommand(string name, string library, Func<object[], string> action)
        {
            CustomCommand customCommand = new CustomCommand(name, library, "", action);
            this.commands.Add(customCommand);
        }

        public void AddCommand(string name, string library, Func<object[], string> action, string helpText)
        {
            CustomCommand customCommand = new CustomCommand(name, library, helpText, action);
            this.commands.Add(customCommand);
        }

        public void RemoveCommand(ICommand command)
        {
            if (this.commands.Contains(command))
                this.commands.Remove(command);
        }

        public void RemoveAll()
        {
            this.commands.Clear();
        }

        /// <summary>
        /// Process a string and execute a command if one is found.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CommandResult ProcessInput(string input)
        {
            ICommand command = null;

            try
            {
                CommandInput cInput = new CommandInput(input);

                this.CommandHistory.Add(input);

                // Process the string to get the command.
                command = this.processor.ProcessString(cInput);

                // Execute the command.
                return this.processor.ExecuteCommand(cInput, command);

            }
            catch (CommandNotFoundException e) // Maybe do something different here? :^)
            {
                //LogHandler.LogError(e);
                return new CommandResult(command, e.Message, CommandResultType.ErrorByException, e);
            }
            catch (Exception e)
            {
                LogHandler.LogError(e);

                if (this.ThrowExceptions == false)
                    return new CommandResult(command, e.Message, CommandResultType.ErrorByException, e);
                else
                    throw e;
            }
        }    
    }
}
