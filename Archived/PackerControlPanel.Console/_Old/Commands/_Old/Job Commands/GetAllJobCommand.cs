using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public class GetAllJobCommand : JobCommand
    {
        public GetAllJobCommand(IJobRepository jobs)
            : base(jobs)
        {
        }

        public override string Name => "GetAll";
        public override string Description => "Gets basic information about all jobs within the collection.";

        public override string Execute(object[] args)
        {
            var jobArray = Jobs.GetAll().ToArray();
            ConsoleTable jobs = jobArray.ToTable();
            return jobs.ToString();
        }
    }
}
