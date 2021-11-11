using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Repository;
    using System.Threading;

    public class RemoveAllJobsCommand : JobCommand
    {
        public RemoveAllJobsCommand(IJobRepository jobs)
            : base(jobs)
        {
        }

        public override string Name => "RemoveAll";
        public override string Description => "Removes all jobs from within the collection.";

        public override string Execute(object[] args)
        {
            if (CommandHelper.AskQuestion("<y>Are you sure you want to permanently delete all jobs?"))
            {
                Jobs.RemoveAll();

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Program.WriteToConsole("<r> ALL DATA HAS BEEN DELETED. CLOSING PROGRAM");
                }

                Environment.Exit(0);
                return "";
            }
            else
                return "<y>No data has been deleted. Command cancelled.";
        }
    }
}
