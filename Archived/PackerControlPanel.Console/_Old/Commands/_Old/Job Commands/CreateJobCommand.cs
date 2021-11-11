using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;

    public class CreateJobCommand : JobCommand
    {
        private IPartRepository parts;

        public CreateJobCommand(IJobRepository jobs, IPartRepository parts)
            : base(jobs)
        {
            this.parts = parts;
        }

        public override string Name => "CreateJob";
        public override string Description => "Creates and adds a new job into the existing collection.";

        public override string Execute(object[] args)
        {
            string jobName = (string)args[0];
            string ownerName = (string)args[1];

            Job job = new Job();
            job.Name = jobName;
            job.Part = parts.FirstOrDefault(p => p.Name == ownerName);

            if (Jobs.FirstOrDefault(j => j.Name == jobName) != null)
                return "<r>A job already exists by this name. Failed to create job.";

            Jobs.Add(job);

            return string.Format("<g>The job #'{0}' and the owner of {1} was successfully created.", jobName, ownerName);


        }
    }
}
