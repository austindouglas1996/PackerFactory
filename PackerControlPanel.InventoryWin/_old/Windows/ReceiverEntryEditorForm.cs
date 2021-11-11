using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Windows
{
    public partial class ReceiverEntryEditorForm : Form
    {
        private InventoryManager inventory;
        private ReceiverEntry entry;

        public ReceiverEntryEditorForm(InventoryManager manager, ReceiverEntry entry)
        {
            InitializeComponent();

            this.entry = entry;
            this.inventory = manager;

            this.LoadEntry(entry);
        }

        public ReceiverEntry Entry
        {
            get { return this.entry; }
        }

        public void LoadEntry(ReceiverEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException("Entry cannot be null.");

            this.EntryID.Text = entry.ID.ToString();
            this.GroupID.Text = "00000";
            this.ReceiverID.Text = entry.ReceiverID.ToString();

            this.PartName.Text = entry.Part.Name;
            this.JobName.Text = entry.Job.Name;
            this.ReceiverName.Text = entry.Receiver.Name;
            this.CreationDate.Text = entry.CreationTime.ToShortDateString();

            this.Boxes.Text = entry.Boxes.ToString();
            this.BoxCount.Text = entry.BoxCount.ToString();
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            Job job = this.inventory.Worker.Jobs.GetJobByName(JobName.Text);
            Part part = this.inventory.Worker.Parts.GetPartWithJobs(PartName.Text);

            if (job == null)
            {
                DisplayMessageError(string.Format("Failed to find a job by the name of '{0}'.", JobName.Text), "Error finding job.");
                return;
            }

            if (part == null)
            {
                DisplayMessageError(string.Format("Failed to find a part by the name of '{0}'. Part creation is disabled on entry editior.", PartName.Text), "Error finding part.");
                return;
            }

            if (job.Part != part)
            {
                DisplayMessageError(string.Format("Invalid match. The job #'{0}' does not belong to the part '{1}' instead belongs to '{2}'.", JobName.Text, part.Name, job.Part.Name), "Invalid Match.");
                return;
            }

            this.entry.Part = part;
            this.entry.Job = job;
            this.entry.Boxes = Int32.Parse(Boxes.Text);
            this.entry.BoxCount = Int32.Parse(BoxCount.Text);

            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DialogResult DisplayMessageError(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
