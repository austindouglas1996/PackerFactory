using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.UI
{
    public delegate void PartEventHandler(object sender, PartEventArgs e);
    public delegate void AddPartEventHandler(object sender, AddPartEventArgs e);
    public delegate void GetPartEventHandler(object sender, GetPartEventArgs e);
    public delegate void ModifyPartEventHandler(object sender, ModifyPartEventArgs e);
    public delegate void RemovePartEventHandler(object sender, RemovePartEventArgs e);
    public delegate void PartParentChangeEventHandler(object sender, PartParentChangeEventArgs e);
    public delegate void PartNoteEventHandler(object sender, PartNoteEventArgs e);
    public delegate void PartNoteModifyEventHandler(object sender, PartNoteModifyEventArgs e);

    public delegate void JobEventHandler(object sender, JobEventArgs e);
    public delegate void AddJobEventHandler(object sender, AddJobEventArgs e);
    public delegate void GetJobEventHandler(object sender, GetJobEventArgs e);
    public delegate void ModifyJobEventHandler(object sender, ModifyJobEventArgs e);
    public delegate void RemoveJobEventHandler(object sender, RemoveJobEventArgs e);
    public delegate void JobOwnerChangeEventHandler(object sender, JobOwnerChangeEventArgs e);
    public delegate void JobStateChangeEventHandler(object sender, JobStateChangeEventArgs e);

    public delegate void ReceiverEventHandler(object sender, ReceiverEventArgs e);
    public delegate void GetReceiverEventHandler(object sender, GetReceiverEventArgs e);
    public delegate void ModifyReceiverEventHandler(object sender, ModifyReceiverEventArgs e);
    public delegate void RemoveReceiverEventHandler(object sender, RemoveReceiverEventArgs e);

    public delegate void ReceiverEntryEventHandler(object sender, ReceiverEntryEventArgs e);
    public delegate void CreateReceiverEntryHandler(object sender, CreateReceiverEntryEventArgs e);
    public delegate void AddReceiverEntryEventHandler(object sender, AddReceiverEntryEventArgs e);
    public delegate void GetReceiverEntryEventHandler(object sender, GetReceiverEntryEventArgs e);
    public delegate void ModifyReceiverEntryEventHandler(object sender, ModifyReceiverEntryEventArgs e);
    public delegate void RemoveReceiverEntryEventHandler(object sender, RemoveReceiverEntryEventArgs e);

    public class PartEventArgs : EventArgs
    {
        public Part Part { get; set; }

        public PartEventArgs()
        {
        }

        public PartEventArgs(Part part)
        {
            this.Part = part;
        }
    }

    public class AddPartEventArgs : PartEventArgs
    {
        public AddPartEventArgs(Part newPart)
            : base()
        {
            this.Part = newPart;
            Handled = false;
        }

        public bool Handled { get; set; }
    }

    public class GetPartEventArgs : PartEventArgs
    {
        public GetPartEventArgs(string partName)
        {
            this.RequestedPartName = partName;
        }

        public GetPartEventArgs(int partId)
        {
            this.RequestedPartID = partId;
        }

        public string RequestedPartName { get; set; }
        public int RequestedPartID { get; set; }
    }

    public class ModifyPartEventArgs : PartEventArgs
    {
        public ModifyPartEventArgs(int index, Part part)
        {
            this.Index = index;
            this.Part = part;
        }

        public int Index { get; set; }
    }

    public class RemovePartEventArgs : PartEventArgs
    {
        public RemovePartEventArgs(Part oldPart)
        {
            this.Part = oldPart;
        }

        public bool Handled { get; set; }
    }

    public class PartParentChangeEventArgs : PartEventArgs
    {
        public PartParentChangeEventArgs(Part part, Part newParent)
        {
            this.Part = part;
            this.NewParent = newParent;
        }
        
        public Part NewParent { get; set; }
        public bool ParentAccepted { get; set; }
    }

    public class PartNoteEventArgs : PartEventArgs
    {
        public PartNoteEventArgs(Part part, Note note)
        {
            this.Part = part;
            this.Note = note;
        }
        
        public Note Note { get; set; }
    }

    public class PartNoteModifyEventArgs : PartNoteEventArgs
    {
        public PartNoteModifyEventArgs(Part part, int index, Note note)
            : base(part, note)
        {
            this.Index = index;
        }
        
        public int Index { get; set; }
    }

    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(Job job)
        {
            this.Job = job;
        }

        public JobEventArgs()
        {

        }

        public Job Job { get; set; }
    }

    public class AddJobEventArgs : JobEventArgs
    {
        public AddJobEventArgs(Job newJob)
        {
            Job = newJob;
            Handled = false;
        }
        
        public bool Handled { get; set; }
    }

    public class GetJobEventArgs : JobEventArgs
    {
        public GetJobEventArgs(string jobName)
        {
            JobName = jobName;
        }

        public GetJobEventArgs(int jobID)
        {
            JobID = jobID;
        }

        public int JobID { get; set; }
        public string JobName { get; set; }
    }

    public class ModifyJobEventArgs : JobEventArgs
    {
        public ModifyJobEventArgs(int index, Job job)
        {
            this.Index = index;
            this.Job = job;
        }

        public int Index { get; set; }
    }

    public class RemoveJobEventArgs : JobEventArgs
    {
        public RemoveJobEventArgs(Job job)
        {
            this.Job = job;
        }

        public bool Handled { get; set; }
    }

    public class JobOwnerChangeEventArgs : JobEventArgs
    {
        public JobOwnerChangeEventArgs(Job job, Part newOwner)
        {
            this.Job = job;
            this.NewOwner = newOwner;
        }

        public Part NewOwner { get; set; }
    }

    public class JobStateChangeEventArgs : JobEventArgs
    {
        public JobStateChangeEventArgs(Job job, JobState newState)
        {
            this.Job = job;
            this.NewState = newState;
        }

        public JobState NewState { get; set; }
    }

    public class ReceiverEventArgs : EventArgs
    {
        public ReceiverEventArgs(Receiver receiver)
        {
            this.Receiver = receiver;
        }

        public Receiver Receiver { get; set; }
    }

    public class GetReceiverEventArgs : ReceiverEventArgs
    {
        public GetReceiverEventArgs(string receiverName)
            : base(null)
        {
            this.ReceiverName = ReceiverName;
        }

        public GetReceiverEventArgs(int receiverID)
            : base(null)
        {
            this.ReceiverID = receiverID;
        }

        public int ReceiverID { get; set; }
        public string ReceiverName { get; set; }
    }

    public class ModifyReceiverEventArgs : ReceiverEventArgs
    {
        public ModifyReceiverEventArgs(int id, Receiver receiver)
            : base(receiver)
        {
        }

        public int ID { get; set; }
        public bool Handled { get; set; }
    }

    public class RemoveReceiverEventArgs : ReceiverEventArgs
    {
        public RemoveReceiverEventArgs(Receiver receiver)
            : base(receiver)
        {
            base.Receiver = receiver;
        }

        public bool Handled { get; set; }
    }

    public class ReceiverEntryEventArgs : EventArgs
    {
        public ReceiverEntryEventArgs(ReceiverEntry entry)
        {
            this.Entry = entry;
        }

        public ReceiverEntry Entry { get; set; }
    }

    public class CreateReceiverEntryEventArgs : EventArgs
    {
        public CreateReceiverEntryEventArgs(ReceiverEntry entry)
        {
            this.NewEntry = entry;
        }

        public ReceiverEntry NewEntry { get; set; }
    }

    public class AddReceiverEntryEventArgs : ReceiverEntryEventArgs
    {
        public AddReceiverEntryEventArgs(ReceiverEntry entry)
            : base(entry)
        {

        }

        public bool Handled { get; set; }
    }

    public class GetReceiverEntryEventArgs : ReceiverEntryEventArgs
    {
        public GetReceiverEntryEventArgs(int receiverEntryID)
            : base(null)
        {
            this.ReceiverEntryID = receiverEntryID;
        }

        public int ReceiverEntryID { get; set; }
    }

    public class ModifyReceiverEntryEventArgs : ReceiverEntryEventArgs
    {
        public ModifyReceiverEntryEventArgs(int id, ReceiverEntry entry)
            : base(entry)
        {
            this.Index = id;
        }

        public int Index { get; set; }
    }

    public class RemoveReceiverEntryEventArgs : ReceiverEntryEventArgs
    {
        public RemoveReceiverEntryEventArgs(ReceiverEntry entry)
            : base(entry)
        {
        }

        public bool Handled { get; set; }
    }
   
}
