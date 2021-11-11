using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Repository
{
    public interface IReceiverEntriesRepository : IRepository<ReceiverEntry>
    {
        ReceiverEntry GetEntryWithInfo(int id);

        ReceiverEntry[] GetEntriesFromReceiver(int receiverID);
        ReceiverEntry[] GetEntriesFromReceiver(string receiverName);

        ReceiverEntry[] GetEntriesFromJob(int jobID);
        ReceiverEntry[] GetEntriesFromJob(string jobName);

        ReceiverEntry[] GetEntriesFromPart(int partID);
        ReceiverEntry[] GetEntriesFromPart(string partName);

        ReceiverEntry[] GetEntriesFromDate(DateTime date);
    }
}
