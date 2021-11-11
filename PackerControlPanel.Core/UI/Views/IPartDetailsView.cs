using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Views
{
    public interface IPartDetailsView : IView<Part>, IPartObjectView
    {
        PartDetailsPresenter Presenter { get; set; }

        event EventHandler<PartEventArgs> LoadPart;
        event EventHandler<ModifyPartEventArgs> SaveChanges;
        event EventHandler<RemovePartEventArgs> Remove;
    }
}
