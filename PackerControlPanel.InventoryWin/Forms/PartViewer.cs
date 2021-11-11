using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.InventoryWin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Forms
{
    public partial class PartViewer : Form
    {
        private IPartRepository PartCollection;
        private Part part;

        public PartViewer(IPartRepository partCollection, Part part)
        {
            this.PartCollection = partCollection;

            InitializeComponent();

            var PackageTypes = Enum.GetNames(typeof(PackageType));
            for (int i = 0; i < PackageTypes.Count(); i++)
            {
                // Get the original type.
                PackageType pType = (PackageType)Enum.Parse(typeof(PackageType), PackageTypes[i]);

                this.partBoxTypeCB.Items.Add(new PackageTypeItem(i, pType));
            }

            this.LoadPart(part);

            this.NotesAdd.Click += NotesAdd_Click;
            this.NotesRemove.Click += NotesRemove_Click;
            this.NotesRemoveAll.Click += NotesRemoveAll_Click;
        }

        private void NotesRemoveAll_Click(object sender, EventArgs e)
        {
            this.part.Notes.Clear();

            // Edit part, repopulate list.
            this.PartCollection.Edit(this.part);
            this.PopulateNoteList();
        }

        private void NotesRemove_Click(object sender, EventArgs e)
        {
            if (this.NotesList.SelectedItems.Count > 0)
            {
                var selectedItem = this.NotesList.SelectedItems[0];
                var note = this.part.Notes.FirstOrDefault(p => p.ID == Int32.Parse(selectedItem.SubItems[0].Text));


                if (note != null)
                {
                    this.part.Notes.Remove(note);

                    // Edit part, repopulate list.
                    this.PartCollection.Edit(this.part);
                    this.PopulateNoteList();
                }
            }
        }

        private void NotesAdd_Click(object sender, EventArgs e)
        {
            NewNote note = new NewNote();
            note.ShowDialog();

            if (note.GetNote() != null)
            {
                this.part.Notes.Add(note.GetNote());

                // Edit part, repopulate list.
                this.PartCollection.Edit(this.part);
                this.PopulateNoteList();
            }
        }

        /// <summary>
        /// Get the part loaded.
        /// </summary>
        public Part GetPart
        {
            get { return this.part; }
        }

        /// <summary>
        /// Take the part information and replace UI values.
        /// </summary>
        /// <param name="part"></param>
        protected virtual void LoadPart(Part part)
        {
            this.part = part;

            this.partIDTB.Text = part.ID.ToString();
            this.partNameTB.Text = part.Name;
            this.partDescTB.Text = part.Description;

            if (part.Parent != null)
            {
                this.partParentIDTb.Text = part.ParentID.ToString();
                this.partParentNameTB.Text = part.Parent.Name;
                this.partParentDescTB.Text = part.Parent.Description;

                this.partBoxCountTB.Text = part.Parent.DefaultBoxCount.ToString();
                this.partBoxCountTB.ReadOnly = true;
            }
            else
            {
                this.partParentIDTb.Text = "Null";
                this.partParentNameTB.Text = "No parent.";
                this.partParentDescTB.Text = "No parent.";

                this.partBoxCountTB.Text = part.DefaultBoxCount.ToString();
                this.partBoxCountTB.ReadOnly = false;
            }
            
            this.partBoxTypeCB.SelectedIndex = Array.IndexOf(Enum.GetValues(part.PackingInfo.BoxType.GetType()), part.PackingInfo.BoxType);
            this.partBoxDirTB.Text = part.PackingInfo.BoxingDirections;

            this.PopulateJobList();

            // Setting children list.
            ChildrenList.ListView.Columns.Add("ID", -1, HorizontalAlignment.Left);
            ChildrenList.ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            ChildrenList.ListView.Columns.Add("Creation Date", 100, HorizontalAlignment.Left);
            ChildrenList.ListView.Columns.Add("Modified Date", 100, HorizontalAlignment.Left);

            // Populate vist.
            foreach (var child in this.PartCollection.GetPartChildren(this.part))
            {
                ChildrenList.ListView.Items.Add(new ListViewItem(new string[]
                {
                    child.ID.ToString(),
                    child.Name.ToString(),
                    child.CreationDate.ToShortDateString(),
                    child.LastModifiedDate.ToShortDateString()
                }));
            }

            this.PopulateNoteList();
        }

        /// <summary>
        /// Save the part to the collection.
        /// </summary>
        protected virtual void SavePart()
        {
            Part part = PartCollection.Get(int.Parse(this.partIDTB.Text));

            part.Name = partNameTB.Text;
            part.Description = partDescTB.Text;
            part.DefaultBoxCount = int.Parse(partBoxCountTB.Text);

            if (partParentIDTb.Text != "Null")
                part.ParentID = int.Parse(partParentIDTb.Text);

            var selectedItem = (PackageTypeItem)this.partBoxTypeCB.SelectedItem;
            if (selectedItem == null)
                throw new ArgumentNullException("Failed to get selected box type.");

            part.PackingInfo.BoxType = selectedItem.PackageType;
            part.PackingInfo.BoxingDirections = partBoxDirTB.Text;

            PartCollection.Edit(part);
        }

        private void PopulateJobList()
        {
            JobList.ListView.Columns.Clear();
            JobList.ListView.Items.Clear();

            // Setting job list.
            JobList.ListView.Columns.AddRange(Helper.JobColumnHeader);

            // Populate list.
            foreach (var job in this.part.Jobs)
            {
                JobList.ListView.Items.Add(new ListViewItem(new string[]
                {
                    job.ID.ToString(),
                    job.Name,
                    job.Part.Name,
                    job.TotalReceived.ToString(),
                    job.GetCurrentState.State.ToString(),
                    job.CreationDate.ToShortDateString(),
                    job.CompletionDate.ToShortDateString()
                }));
            }
        }

        private void PopulateNoteList()
        {
            NotesList.Columns.Clear();
            NotesList.Items.Clear();

            // Setting note list.
            NotesList.Columns.AddRange(Helper.NoteColumnHeader);

            // Populate list.
            foreach (var note in part.Notes)
            {
                NotesList.Items.Add(new ListViewItem(new string[]
                {
                    note.ID.ToString(),
                    note.Message,
                    note.CreationTime.ToShortDateString()
                }));
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            this.SavePart();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PartParentEditor p = new PartParentEditor(this.PartCollection, this.part);
            p.ShowDialog();

            this.LoadPart(this.part);
        }
    }
}
