using EntityRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain
{
    /// <summary>
    /// Represents a entry for a simple date. Helpful with inserting into a database.
    /// </summary>
    public class ReceiverEntryDateEntry : IEntity
    {
        public ReceiverEntryDateEntry()
        {

        }

        public ReceiverEntryDateEntry(DateTime date)
        {
            this.Date = date;
        }

        public int ID { get; set; }
        public int EntryID { get; set; }

        [ForeignKey("EntryID")]
        public virtual ReceiverEntry Entry { get; set; }
        public DateTime Date { get; set; }
    }
}
