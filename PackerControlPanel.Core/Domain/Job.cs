using EntityRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    public class Job : IEntity, IUserObject
    {
        public Job(Part part, string name)
            : this()
        {
            this.Part = part;
            this.Name = name;
        }

        public Job()
        {
            this.Entries = new List<ReceiverEntry>();
            this.CreationDate = DateTime.Now;
            this.CompletionDate = (DateTime)SqlDateTime.MinValue;
            this.JobStateHistory = new List<JobState>();
            this.UserObjects = new List<Tuple<string, string>>();
        }

        [XmlElement("ID")]
        public int ID { get; set; }

        [XmlElement("PartID")]
        [ForeignKey("Part")]
        public int PartID { get; set; }

        [XmlIgnore]
        public Part Part { get; set; }

        [XmlElement("JobName")]
        public string Name { get; set; }

        [XmlElement("IsGlobal")]
        public bool IsGlobal { get; set; }

        [XmlIgnore]
        public int TotalReceived
        {
            get
            {
                int total = 0;
                Entries.ToList().ForEach(e => total += e.Total);
                return total;
            }
        }

        [XmlElement("CreationDate")]
        [Column(TypeName = "DateTime")]
        public DateTime CreationDate { get; set; }

        [XmlElement("CompletionDate")]
        [Column(TypeName = "DateTime")]
        public DateTime CompletionDate { get; set; }

        [XmlElement("LastModifiedDate")]
        [Column(TypeName = "DateTime")]
        public DateTime LastModifiedDate { get; set; }

        [XmlElement("UserObjects")]
        public List<Tuple<string, string>> UserObjects { get; set; }

        [XmlIgnore]
        public ICollection<ReceiverEntry> Entries { get; set; }

        [XmlIgnore]
        public ICollection<JobState> JobStateHistory { get; set; }

        /// <summary>
        /// Get the current state of the job.
        /// </summary>
        public JobState GetCurrentState()
        {
            if (this.JobStateHistory.Count() == 0)
                return new JobState(JobStateType.NotRunning, new Note("No state"));

            return this.JobStateHistory.ElementAt(this.JobStateHistory.Count() - 1);
        }

        /// <summary>
        /// Set the state of the job.
        /// </summary>
        /// <param name="newState"></param>
        /// <param name="remarks"></param>
        public void SetState(JobStateType newState, Note remarks = null)
        {
            if (this.IsGlobal && newState == JobStateType.Complete)
                throw new NotSupportedException("Global jobs cannot be set as complete.");

            if (newState == JobStateType.Complete || newState == JobStateType.CompleteWithInSufficentResults)
                this.CompletionDate = DateTime.Now;
            else
                this.CompletionDate = DateTime.MinValue;

            this.JobStateHistory.Add(new JobState(newState, remarks));
        }
    }
}
