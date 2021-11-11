using EntityRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    /// <summary>
    /// Holds the information on a stored part with name, description the default amount of pieces to place in each box and boxing directions.
    /// </summary>
    [Table("Parts")]
    public class Part : IEntity, IUserObject, INote
    {
        private string _name = "";
        private int _defaultBoxCount = -1;

        public Part(string partName, int boxCount, string description = "", string boxType = null)
            : this()
        {
            if (boxType == null)
                boxType = PackageInfo.BoxTypes[0];

            this.Name = partName;
            this.DefaultBoxCount = boxCount;
            this.Description = description;
            this.PackingInfo = new PackageInfo(boxType, "");
        }

        public Part()
        {
            this.CreationDate = DateTime.Now;
            this.LastModifiedDate = DateTime.Now;
            this.Jobs = new List<Job>();
            this.Notes = new List<Note>();
            this.PackingInfo = new PackageInfo(PackageInfo.BoxTypes[0], "");
            this.UserObjects = new List<Tuple<string, string>>();
        }

        [XmlElement("ID")]
        public int ID { get; set; }

        [XmlElement("Name")]
        public string Name
        {
            get { return this._name.ToUpper(); }
            set { this._name = value.ToUpper(); }
        }

        [XmlElement("Description")]
        public string Description
        {
            get
            {
                return this._Description == "" ? "N/A" : this._Description;
            }
            set
            {
                this._Description = value;
            }
        }
        private string _Description;

        [XmlElement("PackingInfo")]
        public PackageInfo PackingInfo { get; set; }

        [XmlElement("DefaultBoxCount")]
        public virtual int DefaultBoxCount
        {
            get
            {
                return _defaultBoxCount;
            }

            set
            {
                _defaultBoxCount = value;
                this.LastModifiedDate = DateTime.Now;
            }
        }

        [XmlElement("CreationTime")]
        [Column(TypeName = "DateTime")]
        public DateTime CreationDate { get; set; }

        [XmlElement("ModifiedTime")]
        [Column(TypeName = "DateTime")]
        public DateTime LastModifiedDate { get; set; }

        [XmlElement("UserObjects")]
        public List<Tuple<string, string>> UserObjects { get; set; }

        [XmlIgnore]
        public ICollection<Job> Jobs { get; set; }

        [XmlIgnore]
        public virtual ICollection<Note> Notes { get; set; }

        [XmlIgnore]
        public virtual ICollection<ReceiverEntry> Entries { get; set; }
    }
}
