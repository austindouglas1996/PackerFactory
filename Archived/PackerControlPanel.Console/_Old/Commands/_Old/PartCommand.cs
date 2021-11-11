using CommandHandlerLib;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public abstract class PartCommand : ICommand
    {
        private IPartRepository _Parts;

        protected PartCommand(IPartRepository parts)
        {
            this._Parts = parts;
        }

        protected IPartRepository Parts
        {
            get { return this._Parts; }
        }

        public abstract string Name { get; }

        public string Library => "Parts";

        public abstract string Description { get; }

        public abstract string Execute(object[] args);
    }
}
