using EntityRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{

    /// <summary>
    /// Represents a entry within a <see cref="Receiver"/> class instance.
    /// </summary>
    public class ReceiverEntry : IEntity, INote
    {
        public ReceiverEntry()
        {
            this.ManuDates = new List<ReceiverEntryDateEntry>();
            this.UserObjects = new List<Tuple<string, string>>();
            this.Notes = new List<Note>();
            this.CreationDate = DateTime.Now;
        }

        [XmlElement("ID")]
        public int ID { get; set; }

        [XmlElement("GroupID")]
        public int GroupID { get; set; }

        [XmlElement("ReceiverID")]
        [ForeignKey("Receiver")]
        public int ReceiverID { get; set; }

        [XmlElement("PartID")]
        [ForeignKey("Part")]
        public int PartID { get; set; }

        [XmlElement("JobID")]
        [ForeignKey("Job")]
        public int JobID { get; set; }


        [XmlIgnore]
        public Receiver Receiver { get; set; }

        [XmlIgnore]
        public Part Part { get; set; }

        [XmlIgnore]
        public Job Job { get; set; }

        [XmlElement("IsHidden")]
        public bool Hidden { get; set; }


        [XmlElement("BoxCount")]
        public int BoxCount { get; set; }

        [XmlElement("Boxes")]
        public int Boxes { get; set; }

        [XmlElement("Location")]
        public string Location { get; set; }

        [XmlElement("CreationDate")]
        public DateTime CreationDate { get; set; }

        [XmlIgnore]
        public virtual ICollection<ReceiverEntryDateEntry> ManuDates { get; set; }

        [XmlElement("UserObjects")]
        public List<Tuple<string, string>> UserObjects { get; set; }

        [XmlElement("ManufactureDates")]
        [NotMapped]
        public List<ReceiverEntryDateEntry> GetManuDates
        {
            get { return this.ManuDates.ToList(); }
            set { throw new NotSupportedException("'GetManuDates' is a read-only property."); }
        }

        [XmlIgnore]
        public virtual ICollection<Note> Notes { get; set; }

        /// <summary>
        /// Gets the total amount of collected pieces.
        /// </summary>
        public int Total
        {
            get { return Boxes * BoxCount; }
        }

        /// <summary>
        /// Gets a value indicating whether this item boxcount matches the part boxcount.
        /// </summary>
        public bool IsPartial
        {
            get 
            {
                if (Part == null)
                    throw new ArgumentNullException("Part is null");

                return Part.DefaultBoxCount != this.BoxCount; 
            }
        }

        /// <summary>
        /// Builds a new instance of the <see cref="ReceiverEntry"/> class one step at a time.
        /// </summary>
        public class Builder
        {
            private ReceiverEntry entry;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="id">Manually set the ID of the entry (Not recomended)</param>
            public Builder(int id = 0)
            {
                entry = new ReceiverEntry();
                entry.CreationDate = DateTime.Now;

                if (id != 0)
                    entry.ID = id;
            }

            /// <summary>
            /// Set the receiver ID to the entry.
            /// </summary>
            /// <param name="receiverId"></param>
            /// <returns></returns>
            public Builder SetReceiver(int receiverId)
            {
                entry.ReceiverID = receiverId;
                return this;
            }

            /// <summary>
            /// Set the group ID which can be managed to group a bunch of entities.
            /// </summary>
            /// <param name="groupId"></param>
            /// <returns></returns>
            public Builder SetGroup(int groupId)
            {
                entry.GroupID = groupId;
                return this;
            }

            /// <summary>
            /// Set the job ID.
            /// </summary>
            /// <param name="jobId"></param>
            /// <returns></returns>
            public Builder SetJob(int jobId)
            {
                entry.JobID = jobId;
                return this;
            }

            /// <summary>
            /// Set the part ID.
            /// </summary>
            /// <param name="partId"></param>
            /// <returns></returns>
            public Builder SetPart(int partId)
            {
                entry.PartID = partId;
                return this;
            }

            /// <summary>
            /// Set the amount of boxes and amount of pieces in each box.
            /// </summary>
            /// <param name="boxes"></param>
            /// <param name="boxCount"></param>
            /// <returns></returns>
            public Builder SetInfo(int boxes, int boxCount)
            {
                entry.Boxes = boxes;
                entry.BoxCount = boxCount;
                return this;
            }

            /// <summary>
            /// Set manufacture dates.
            /// </summary>
            /// <param name="dates"></param>
            /// <returns></returns>
            public Builder SetManufactureDates(params DateTime[] dates)
            {
                foreach (var date in dates)
                {
                    entry.ManuDates.Add(new ReceiverEntryDateEntry(date));
                }

                return this;
            }

            /// <summary>
            /// Add notes to the entry.
            /// </summary>
            /// <param name="notes"></param>
            /// <returns></returns>
            public Builder AddNotes(params Note[] notes)
            {
                foreach (var note in notes)
                    entry.Notes.Add(note);

                return this;
            }

            /// <summary>
            /// Returns the created entry by the provided values.
            /// </summary>
            /// <returns></returns>
            public ReceiverEntry Build()
            {
                if (entry.ReceiverID == -1 || entry.JobID == -1 || entry.PartID == -1)
                    throw new ArgumentOutOfRangeException("ReceiverID, JobID, and PartID must be set prior to build.");

                if (entry.Job != null)
                    if (entry.Job.PartID != entry.PartID && !entry.Job.IsGlobal)
                        throw new NotSupportedException(string.Format("The job '{0}' does not belong to the part '{1}'.", entry.Job.Name, entry.Part.Name));

                return entry;
            }
        }
    }
}
