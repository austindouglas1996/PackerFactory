using System;
using System.ComponentModel;

namespace PackerControlPanel.Core
{
    public enum ReceiverStateType
    {
        [Description("No state is set.")]
        None = 0,

        [Description("Receiver is in-progress.")]
        InProgress = 1,

        [Description("Receiver contents are currently being placed into storage.")]
        InProgressDelivery = 2,

        [Description("Receiver has been completed. No more items can be added.")]
        Received = 3,

        [Description("Transfer document has been transferred. No more items can be added.")]
        Transferred = 4
    }
}