using EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    public class Transfer : IEntity, IUserObject
    {
        public Transfer()
            : this("")
        {

        }

        public Transfer(string name = "")
        {
            if (name == "")
                name = DateTime.Now.ToShortDateString();

            this.Name = name;
            this.UserObjects = new List<Tuple<string, string>>();
            this.Entries = new List<TransferEntry>();
            this.CreationTime = DateTime.Now;
            this.State = ReceiverStateType.None;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public ReceiverStateType State { get; set; }
        public List<Tuple<string, string>> UserObjects { get; set; }
        public ICollection<TransferEntry> Entries { get; set; }

        [XmlElement("CreationTime")]
        public DateTime CreationTime { get; set; }
    }
}
