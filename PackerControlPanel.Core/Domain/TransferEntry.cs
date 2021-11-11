using EntityRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    public class TransferEntry : IEntity, IUserObject, INote
    {
        public TransferEntry(ReceiverEntry receiverEntry)
            : this()
        {
            this.ReceiverEntry = receiverEntry;
        }

        public TransferEntry()
        {
            this.UserObjects = new List<Tuple<string, string>>();
            this.Notes = new List<Note>();
        }

        public int ID { get; set; }

        [ForeignKey("Transfer")]
        public int TransferID { get; set; }

        [ForeignKey("ReceiverEntry")]
        public int ReceiverEntryID { get; set; }

        public Transfer Transfer { get; set; }
        public ReceiverEntry ReceiverEntry { get; set; }

        /// <summary>
        /// Location where to be transferred to.
        /// </summary>
        public string StoredLocation { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public List<Tuple<string, string>> UserObjects { get; set; }

        [XmlElement("CreationTime")]
        public DateTime CreationTime { get; set; }
    }
}
