using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Windows
{
    using PackerControlPanel.Data;

    public partial class ReceiverManagerForm : Form
    {
        private Receiver loadedDocument;

        private InventoryManager inventory;
        private IReceiverRepository receivers;

        private IReadOnlyList<TextBox> NewItemBoxes;

        public ReceiverManagerForm(InventoryManager inventory)
        {
            this.inventory = inventory;
            this.receivers = inventory.Worker.Receivers;

            InitializeComponent();

            LvSearch.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Part Name", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Job Name", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Boxes", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Box count", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Manu. Dates", 300, HorizontalAlignment.Left);

            LvSearch.ListView.MouseDoubleClick += ListView_MouseDoubleClick;

            NewItemBoxes = new List<TextBox>()
            {
                NItem_PartName,
                NItem_JobName,
                NItem_Boxes,
                NItem_BoxCount,
                NItem_ManufactureDates
            }.AsReadOnly();
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView view = (ListView)sender;
            if (view.SelectedItems.Count > 0)
            {
                int viewID = view.SelectedItems[0].Index;
                int id = Int32.Parse(view.SelectedItems[0].SubItems[0].Text);
                ReceiverEntry entry = inventory.Worker.ReceiverEntries.GetEntryWithInfo(id);

                ReceiverEntryEditorForm editor = new ReceiverEntryEditorForm(this.inventory, entry);
                editor.ShowDialog();

                view.Items[viewID] = new ListViewItem(EntryToStringArray(entry));
            }
        }

        public event EventHandler DocumentLoaded;
        public event EventHandler DocumentUnloaded;
        public event EventHandler ViewRefreshed;

        public Receiver GetLoadedDocument
        {
            get { return this.loadedDocument; }
        }

        public void RefreshView()
        {
            this.LvSearch.ListView.Items.Clear();

            // Load entries.
            foreach (var entry in this.loadedDocument.Entries)
            {
                this.LvSearch.ListView.Items.Add(new ListViewItem(EntryToStringArray(entry)));
            }
        }

        public void LoadReceiver(Receiver doc)
        {
            if (this.loadedDocument != null)
                this.UnloadReceiver();

            this.loadedDocument = doc;

            this.OnDocumentLoaded(EventArgs.Empty);

            // Set properties.
            this.DocID.Text = doc.ID.ToString();
            this.DocName.Text = doc.Name;
            this.DocTitle.Text = doc.Title;

            this.RefreshView();
        }

        public void UnloadReceiver()
        {
            this.OnDocumentUnloaded(EventArgs.Empty);

            this.loadedDocument = null;
            this.LvSearch.ListView.Items.Clear();

            this.DocID.Text = "";
            this.DocName.Text = "";
            this.DocTitle.Text = "";
        }


        private void NItem_AddItem_Click(object sender, EventArgs e)
        {
            bool createdPart = false;
            bool createdJob = false;

            Part part = null;
            Job job = null;

            int boxes = int.Parse(NItem_Boxes.Text);
            int boxCount = int.Parse(NItem_BoxCount.Text);

            // Try to get part.
            part = inventory.Worker.Parts.GetPartWithJobs(NItem_PartName.Text);
            if (part == null)
            {
                DialogResult result = MessageBox.Show(string.Format("Failed to find a part by the name '{0}'. Do you wish to create it now?", NItem_PartName.Text),
                    "Error with part name.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    part = new Part(NItem_PartName.Text, -1, "");
                    createdPart = true;
                }
                else
                {
                    NItem_PartName.BackColor = Color.Red;
                    return;
                }
            }

            // Try to get job.
            job = inventory.Worker.Jobs.GetJobByName(NItem_JobName.Text);
            if (job == null)
            {
                DialogResult result = MessageBox.Show(string.Format("Failed to find a job by the name '{0}'. Do you wish to create it now?", NItem_JobName.Text),
                    "Error with job name.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    job = new Job();
                    job.Name = NItem_JobName.Text;
                    job.Part = part;

                    createdJob = true;
                }
                else
                {
                    NItem_JobName.BackColor = Color.Red;
                    return;
                }
            }

            // No match. 
            if (job.Part != part)
            {
                MessageBox.Show(string.Format("The job #'{0}' does not belong to the part '{1}'. Instead belongs to '{2}'.", job.Name, part.Name, job.Part.Name),
                    "Fatal Error. Invalid match.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }

            if (createdPart)
                this.inventory.Worker.Parts.Add(part);

            if (createdJob)
                this.inventory.Worker.Jobs.Add(job);

            ReceiverEntry entry = new ReceiverEntry.Builder()
                .SetPart(part.ID)
                .SetJob(job.ID)
                .SetReceiver(this.loadedDocument.ID)
                .SetInfo(boxes, boxCount)
                .SetManufactureDates(NItem_ManufactureDates.Text.Split(',').ToDateTimeArray())
                .Build();

            // Add entry.
            this.inventory.Worker.ReceiverEntries.Add(entry);

            // Clear fields.
            NItem_ClearBtn_Click(this, e);

            // Refresh the view.
            this.RefreshView();
        }

        private void NItem_ClearBtn_Click(object sender, EventArgs e)
        {
            foreach (var box in this.NewItemBoxes)
            {
                box.Text = "";
            }
        }



        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiverBrowserSelecter browser = new ReceiverBrowserSelecter(this.receivers);
            browser.ShowDialog();

            Receiver selectedValue = browser.SelectedValue;

            if (selectedValue != null)
                this.LoadReceiver(selectedValue);
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Receiver newReceiver = new Receiver();
            newReceiver.Name = "NoName";
            newReceiver.Title = "NoTitle";

            receivers.Add(newReceiver);

            this.LoadReceiver(newReceiver);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UnloadReceiver();
        }

        protected void OnDocumentLoaded(EventArgs e)
        {
            this.SaveBtn.Enabled = true;
            this.DeleteBtn.Enabled = true;
            this.DocName.Enabled = true;
            this.DocTitle.Enabled = true;

            if (this.DocumentLoaded != null)
                this.DocumentLoaded(this, e);
        }

        protected void OnDocumentUnloaded(EventArgs e)
        {
            this.SaveBtn.Enabled = !true;
            this.DeleteBtn.Enabled = !true;
            this.DocName.Enabled = !true;
            this.DocTitle.Enabled = !true;

            if (this.DocumentUnloaded != null)
                this.DocumentUnloaded(this, e);
        }

        private string[] EntryToStringArray(ReceiverEntry entry)
        {
            string manuDates = "";
            foreach (ReceiverEntryDateEntry manuDate in entry.ManuDates)
            {
                manuDates += manuDate.Date.ToString("MM-dd-yy") + ",";
            }

            string[] newArray = new string[]
                {
                    entry.ID.ToString(),
                    entry.Part.Name,
                    entry.Job.Name,
                    entry.Boxes.ToString(),
                    entry.BoxCount.ToString(),
                    manuDates
                };

            return newArray;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = "Receivers/" + this.loadedDocument.Name + ".html";

            if (!Directory.Exists("Receivers/"))
                Directory.CreateDirectory("Receivers/");

            HtmlReceiverExporter exporter = new HtmlReceiverExporter("Receivers/");
            exporter.Export(this.loadedDocument);

            Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "//" + path);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.loadedDocument != null)
            {
                this.loadedDocument.Name = this.DocName.Text;
                this.receivers.Edit(this.loadedDocument);
            }
        }
    }
}
