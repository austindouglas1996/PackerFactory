using CommandHandlerLib;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public abstract class JobCommand : ICommand
    {
        private IJobRepository _Jobs;

        protected JobCommand(IJobRepository jobs)
        {
            this._Jobs = jobs;
        }

        public IJobRepository Jobs
        {
            get { return this._Jobs; }
        }

        public abstract string Name { get; }

        public string Library => "Jobs";

        public abstract string Description { get; }

        public abstract string Execute(object[] args);
    }
}
