using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain
{
    public struct JobState
    {
        public JobState(JobStateType status, Note remarks = null)
            : this()
        {
            this.State = status;
            this.Remarks = remarks;
            this.CreationDate = DateTime.Now;
        }

        [Column(TypeName = "DateTime")]
        public DateTime CreationDate { get; set; }
        public JobStateType State { get; set; }
        public Note Remarks { get; set; }
    }
}
