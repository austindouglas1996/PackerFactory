using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain.Model
{
    public interface IPart
    {
        int ID { get; set; }
        int? ParentID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        PackageInfo PackingInfo { get; set; }
        int DefaultBoxCount { get; set; }
        DateTime CreationDate { get; set; }
        DateTime LastModifiedDate { get; set; }
    }
}
