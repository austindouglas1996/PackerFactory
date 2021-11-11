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
    public interface IReceiverEntryInfoView : IView<ReceiverEntry>
    {
        ReceiverEntryInfoPresenter Presenter { get; set; }

        event EventHandler<ReceiverEntryEventArgs> EntryChanged;

        ReceiverEntry Entry { get; set; }
        int JobID { get; set; }
        int PartID { get; set; }
        int ID { get; set; }
        int BoxCount { get; set; }
        int Boxes { get; set; }
        string Location { get; set; }
        DateTime CreationTime { get; set; }
    }
}
