using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.UI.Views
{
    public interface IJobObjectView
    {
        int JobID { get; set; }
        int PartID { get; set; }
        string JobName { get; set; }
        string PartName { get; set; }
        bool IsGlobal { get; set; }
        int TotalReceived { get; set; }
        JobStateType State { get; set; }
        DateTime CreationTime { get; set; }
        DateTime ModifiedTime { get; set; }
        DateTime CompletionTime { get; set; }
    }
}
