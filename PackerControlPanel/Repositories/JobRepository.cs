using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PackerControlPanel.Core;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.Domain;

namespace PackerControlPanel.Data.Repository
{
    public class JobRepository : XmlRepository<Job, PackerContext>, IJobRepository
    {
        public JobRepository(PackerContext context)
            : base(context, "Jobs.XML")
        {

        }


        public Job Get(string jobName)
        {
            return this.Context.Jobs
                .Include(p => p.Part)
                .Include(re => re.Entries)
                .FirstOrDefault(j => j.Name.ToLower() == jobName.ToLower());
        }

        public int GetID(string jobName)
        {
            return this.Context.Jobs.FirstOrDefault(j => j.Name.ToLower() == jobName.ToLower()).ID;
        }

        public Job[] GetJobs(Part part)
        {
            return this.Context.Jobs
                .Include(p => p.Part)
                .Include(re => re.Entries)
                .Where(j => j.Part == part).ToArray();
        }

        public Job[] GetJobs(int partID)
        {
            var part = this.Context.Parts.FirstOrDefault(p => p.ID == partID);
            if (part != null)
                return GetJobs(part);

            return null;
        }

        public Job[] GetJobs(DateTime startTime, DateTime endTime)
        {
            return this.Context.Jobs
                .Include(p => p.Part)
                .Include(re => re.Entries)
                .Where(j => j.CreationDate >= startTime && j.CreationDate <= endTime).ToArray();
        }

        public Job[] GetJobs(JobStateType stateType)
        {
            return this.Context.Jobs
                .Include(p => p.Part)
                .Include(re => re.Entries)
                .Where(j => j.GetCurrentState().State == stateType).ToArray();
        }
    }
}
