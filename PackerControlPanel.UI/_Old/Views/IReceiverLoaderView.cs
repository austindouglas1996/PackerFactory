using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.UI.Views
{
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Presenters;
    public interface IReceiverLoaderView : IView<IList<Receiver>>
    {
        ReceiverLoaderPresenter Presenter { get; set; }

        Receiver Selected { get; }
    }
}
