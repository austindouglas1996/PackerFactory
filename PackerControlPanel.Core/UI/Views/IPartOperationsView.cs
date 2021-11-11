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
    public interface IPartOperationsView : IView<List<Part>>
    {
        PartOperationsPresenter Presenter { get; set; }
        
        event EventHandler<AddPartEventArgs> AddPart;
        event EventHandler<GetPartEventArgs> GetPart;
        event EventHandler<ModifyPartEventArgs> UpdatePart;
        event EventHandler<RemovePartEventArgs> RemovePart;
    }
}
