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
    public interface IReceiverManView : IView<IList<Receiver>>
    {
        ReceiverManPresenter Presenter { get; set; }

        Receiver LoadedReceiver { get; set; }
        ReceiverEntry SelectedItem { get; set; }
        IReceiverEntryInfoView EntryInfo { get; set; }
        
        event EventHandler<ReceiverEventArgs> ReceiverChanged;
        event EventHandler<ReceiverEventArgs> UpdateReceiver;
        event EventHandler<ReceiverEventArgs> DeleteReceiver;
        
        event EventHandler<ReceiverEntryEventArgs> SelectionChanged;
    }
}
