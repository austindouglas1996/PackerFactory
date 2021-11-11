using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Skids.Domain
{
    public class Skid : IEntity
    {
        public int ID { get; set; }
        public int PartID { get; set; }
        public int JobID { get; set; }

        public string Part { get; set; }
        public string Job { get; set; }

        public int[] Boxes { get; set; }
        public int[] BoxCounts { get; set; }

        public SkidStateType Type { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public void SetPart(Part part)
        {
            Part = part.Name;
            PartID = part.ID;
        }

        public void SetJob(Job job)
        {
            Job = job.Name;
            JobID = job.ID;
        }
    }
}
