using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Repository
{
    using System.Data.Entity;
    using System.Linq.Expressions;
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;
    using PackerControlPanel.Data.Repository;

    public class DateEntryRepository : XmlRepository<ReceiverEntryDateEntry, PackerContext>, IDateEntryRepository
    {
        public DateEntryRepository(PackerContext context)
            : base(context, "DateEntriesDB.xml")
        {

        }

        public List<ReceiverEntryDateEntry> GetEntriesFromDate(DateTime date)
        {
            return base.GetAll().Where(i => i.Date == date).ToList();
        }
    }
}
