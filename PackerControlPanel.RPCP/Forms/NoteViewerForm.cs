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

namespace PackerControlPanel.RPCP.Forms
{
    public partial class NoteViewerForm : Form
    {
        private INote _Notes;

        public NoteViewerForm(INote notes)
        {
            InitializeComponent();

            this._Notes = notes;
            this.RefreshItems();
        }

        private void RefreshItems()
        {
            this.listView1.Items.Clear();

            foreach (var note in _Notes.Notes)
            {
                ListViewItem item = new ListViewItem(
                    new[]
                    {
                        note.ID.ToString(),
                        note.Message,
                        note.CreationTime.ToShortDateString()
                    });

                item.Tag = note;

                this.listView1.Items.Add(item);
            }
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            NoteForm newNote = new NoteForm("New Note");
            DialogResult result = newNote.ShowDialog();

            if (result == DialogResult.OK)
            {
                _Notes.Notes.Add(newNote.GetNote());
                RefreshItems();
            }
        }

        private void RemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selected in this.listView1.SelectedItems)
            {
                Note n = (Note)selected.Tag;
                this._Notes.Notes.Remove(n);
            }

            RefreshItems();
        }

        private void RemoveAll_Click(object sender, EventArgs e)
        {
            _Notes.Notes.Clear();
            RefreshItems();
        }

        private void MsViewItem_Click(object sender, EventArgs e)
        {
            Note n = (Note)this.listView1.SelectedItems[0].Tag;
            NoteForm note = new NoteForm(n, "Edit Note");
            DialogResult result = note.ShowDialog();

            if (result == DialogResult.OK)
            {
                n.Message = note.GetNote().Message;

                RefreshItems();
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    MsItems.Show(Cursor.Position);
                }
            }
        }
    }
}
