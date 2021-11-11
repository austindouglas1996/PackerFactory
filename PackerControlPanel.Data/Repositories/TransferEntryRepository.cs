using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Repository
{
    public class TransferEntryRepository : XmlRepository<TransferEntry, PackerContext>, ITransferEntryRepository
    {
        public TransferEntryRepository(PackerContext context) : base(context, "TransferEntriesDB.xml")
        {
        }

        public List<TransferEntry> GetOrphans()
        {
            return this.GetAll().Where(t => t.Transfer == null).ToList();
        }
    }
}
