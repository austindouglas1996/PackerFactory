using CommandHandlerLib;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public abstract class ReceiverCommand : ICommand
    {
        private IReceiverRepository _Receivers;
        private ReceiverBase _LoadedReceiver;

        public ReceiverCommand(IReceiverRepository repository)
        {
            this._Receivers = repository;
        }

        public IReceiverRepository Receivers
        {
            get { return this._Receivers; }
        }

        public ReceiverBase LoadedReceiver
        {
            get { return this._LoadedReceiver; }
            set { this._LoadedReceiver = value; }
        }

        public abstract string Name { get; }

        public string Library => "Receiver";

        public abstract string Description { get; }

        public abstract string Execute(object[] args);
    }
}
