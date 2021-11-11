using CommandHandlerLib;
using CommandHandlerLib.Commands;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{
    /// <summary>
    /// Helps with exporting a collection from the alkonInventory.
    /// </summary>
    public class XmlExportCommand : ICommand
    {
        private string _library = "Default";
        private IXmlRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlExportCommand"/> class.
        /// </summary>
        /// <param name="repository">Repository to call upon to export.</param>
        /// <param name="libraryName">Name of the library to store the command in.</param>
        public XmlExportCommand(IXmlRepository repository, string libraryName)
        {
            this._repository = repository;
            this._library = libraryName;
        }

        public string Name => "Export";

        public string Library
        {
            get { return this._library; }
        }

        public string HelpText => "Exports the collection into a localized XML file.";

        public CommandResult Execute(CommandArgs args)
        {
            _repository.Save();

            string message = "Exported the collection to: " + _repository.FileName;
            return new CommandResult(this, message, CommandResultType.Success);
        }
    }
}
