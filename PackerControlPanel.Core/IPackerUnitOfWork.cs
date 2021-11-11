using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core
{
    public interface IPackerUnitOfWork
    {
        IPartRepository Parts { get; }
        IJobRepository Jobs { get; }
        IReceiverRepository Receivers { get; }
        IReceiverEntriesRepository ReceiverEntries { get; }
        IDateEntryRepository DateEntries { get; }
        ITransferRepository Transfers { get; }
        ITransferEntryRepository TransfersEntries { get; }
        ISkidRepository Skids { get; }
        int Complete();
    }
}
