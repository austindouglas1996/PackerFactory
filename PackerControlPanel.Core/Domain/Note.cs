using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain
{
    /// <summary>
    /// Represents a simple message.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="message"></param>
        public Note(string message)
        {
            this.Message = message;
            this.CreationTime = DateTime.Now;
        }

        public Note()
        {

        }

        public int ID { get; set; }
        
        public int ParentID { get; set; }

        [ForeignKey("ParentID")]
        public virtual object Parent { get; set; }

        /// <summary>
        /// Gets or sets the desired message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the note creation time.
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime CreationTime { get; set; }
    }
}
