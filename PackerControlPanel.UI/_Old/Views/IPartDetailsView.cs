using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI;

namespace PackerControlPanel.UI.Views
{
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Presenters;
    public interface IPartDetailsView : IView<Part>
    {
        PartDetailsPresenter Presenter { get; set; }

        event EventHandler<PartEventArgs> LoadPart;
        event EventHandler<ModifyPartEventArgs> SaveChanges;
        event EventHandler<PartParentChangeEventArgs> ParentChanged;
        event EventHandler<RemovePartEventArgs> Remove;
        event EventHandler<PartEventArgs> AddChild;
        event EventHandler<PartEventArgs> RemoveChild;

        int PartID { get; set; }
        string PartName { get; set; }
        string PartDescription { get; set; }
        int ParentID { get; set; }
        int BoxCount { get; set; }
        string PackageType { get; set; }
        string BoxingDirections { get; set; }
        Part[] PartChildren { get; set; }
    }
}
