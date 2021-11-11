using EntityRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    /// <summary>
    /// Represents a collection of items.
    /// </summary>
    public class Receiver : IEntity, IUserObject, INote
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Receiver"/> class.
        /// </summary>
        public Receiver()
        {
            this.Entries = new List<ReceiverEntry>();
            this.UserObjects = new List<Tuple<string, string>>();
            this.CreationTime = DateTime.Now;
        }

        [XmlElement("ID")]
        public int ID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("CreationTime")]
        public DateTime CreationTime { get; set; }

        [XmlElement("UserObjects")]
        public List<Tuple<string, string>> UserObjects { get; set; }

        [XmlIgnore]
        public ICollection<ReceiverEntry> Entries { get; set; }

        [XmlIgnore]
        public virtual ICollection<Note> Notes { get; set; }

        public ReceiverStateType State { get; set; }

        [XmlElement("Items")]
        [NotMapped]
        public List<ReceiverEntry> GetEntries
        {
            get { return this.Entries.ToList(); }
            set { throw new NotSupportedException("The property 'getentries' is a read-only property."); }
        }
    }
}
