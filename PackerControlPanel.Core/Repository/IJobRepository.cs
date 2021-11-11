using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Repository
{
    public interface IJobRepository : IRepository<Job>
    {
        Job Get(string jobName);
        int GetID(string jobName);

        Job[] GetJobs(Part part);
        Job[] GetJobs(int partID);
        Job[] GetJobs(DateTime startTime, DateTime endTime);
        Job[] GetJobs(JobStateType stateType);
    }
}
