using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain.Model
{
    interface IJob
    {
        int ID { get; set; }
        int PartID { get; set; }
        string Name { get; set; }
        bool IsGlobal { get; set; }
        int TotalReceived { get; set; }
        DateTime CreationDate { get; set; }
        DateTime CompletionTime { get; set; }
        ICollection<JobState> JobStateHistory { get; set; }
    }
}
