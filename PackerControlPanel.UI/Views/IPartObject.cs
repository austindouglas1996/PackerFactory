using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.UI.Views
{
    public interface IPartObjectView
    {
        int PartID { get; set; }
        string PartName { get; set; }
        string PartDescription { get; set; }
        int ParentID { get; set; }
        int BoxCount { get; set; }
        string PackageType { get; set; }
        string BoxingDirections { get; set; }
        Part[] PartChildren { get; set; }
        DateTime CreationTime { get; set; }
        DateTime LastModifiedTime { get; set; }
    }
}
