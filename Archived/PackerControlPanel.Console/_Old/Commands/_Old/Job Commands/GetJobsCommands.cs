using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;
    using System.Text.RegularExpressions;

    public class GetJobsCommands : JobCommand
    {
        private IPartRepository parts;

        public GetJobsCommands(IJobRepository jobs, IPartRepository parts)
            : base(jobs)
        {
            this.parts = parts;
        }

        public override string Name => "GetJobs";
        public override string Description => "Gets jobs owned by a part.";

        public override string Execute(object[] args)
        {
            Part part = null;

            if (Regex.IsMatch((string)args[0], @"^\d+$"))
            {
                part = parts.Get(Convert.ToInt32(args[0]));

                if (part == null)
                    return string.Format(CommandHelper.ERROR_PART_ID_NOT_FOUND, args[0]);
            }
            else if (args[0].GetType() == typeof(string))
            {
                part = parts.FirstOrDefault(p => p.Name == (string)args[0]);

                if (part == null)
                    return string.Format(CommandHelper.ERROR_PART_NOT_FOUND, args[0]);
            }

            Job[] jobs = Jobs.Find(o => o.Part == part).ToArray();
            ConsoleTable jobTable = jobs.ToTable();

            return "Job Information For the Part Name/ID: " + part.Name + jobTable.ToString();
        }
    }
}
