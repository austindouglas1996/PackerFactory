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
    public interface IPartOperationsView : IView<List<Part>>
    {
        PartOperationsPresenter Presenter { get; set; }
        
        event EventHandler<AddPartEventArgs> AddPart;
        event EventHandler<GetPartEventArgs> GetPart;
        event EventHandler<ModifyPartEventArgs> UpdatePart;
        event EventHandler<RemovePartEventArgs> RemovePart;
    }
}
