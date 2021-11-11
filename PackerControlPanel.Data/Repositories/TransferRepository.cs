using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Repository
{
    public class TransferRepository : XmlRepository<Transfer, PackerContext>, ITransferRepository
    {
        public TransferRepository(PackerContext context) : base(context, "TransferDB.xml")
        {

        }

        public void AddReceiverToPool(Receiver receiver)
        {
            foreach (var entry in receiver.Entries)
            {
                TransferEntry newEntry = 
                    new TransferEntry(entry);

                this.Context.TransfersEntries.Add(newEntry);
            }
        }
    }
}
