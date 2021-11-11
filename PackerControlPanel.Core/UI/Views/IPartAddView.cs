using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Views
{
    public interface IPartAddView : IView<Part>
    {
        event EventHandler<AddPartEventArgs> AddPart;
    }
}
