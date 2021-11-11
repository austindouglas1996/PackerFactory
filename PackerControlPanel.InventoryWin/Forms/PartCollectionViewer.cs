using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
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
    public partial class PartCollectionViewer : Form
    {
        private IPartRepository _parts;

        public PartCollectionViewer(IPartRepository parts)
        {
            InitializeComponent();
            this._parts = parts;

            this.PartCollection.ListView.MouseDoubleClick += PartCollection_MouseDoubleClick;

            // Add columns.
            this.PartCollection.ListView.Columns.AddRange(Helpers.Helper.PartColumnHeader);

            // Populate list.
            this.PopulateParts();
        }

        private void PartCollection_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.PartCollection.ListView.SelectedItems.Count > 0)
            {
                var selectedItem = this.PartCollection.ListView.SelectedItems[0];
                int selectedIndex = this.PartCollection.ListView.Items.IndexOf(selectedItem);

                var part = this._parts.FirstOrDefault(p => p.ID.ToString() == selectedItem.SubItems[0].Text);

                if (part != null)
                {
                    PartViewer viewer = new PartViewer(this._parts, part);
                    viewer.ShowDialog();

                    // Edit item.
                    this.PartCollection.ListView.Items[selectedIndex] = new ListViewItem(new string[]
                    {
                        part.ID.ToString(),
                        part.Name,
                        part.DefaultBoxCount.ToString(),
                        part.PackingInfo.BoxType.ToString(),
                        part.Description,
                        part.CreationDate.ToShortDateString()
                    });
                }
            }
        }

        private void PopulateParts()
        {
            this.PartCollection.ListView.Items.Clear();
            foreach (var part in this._parts.GetAll())
            {
                this.PartCollection.ListView.Items.Add(new ListViewItem(new string[]
                {
                    part.ID.ToString(),
                    part.Name,
                    part.DefaultBoxCount.ToString(),
                    part.PackingInfo.BoxType.ToString(),
                    part.Description,
                    part.CreationDate.ToShortDateString()
                }));
            }
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            PartCreator creator = new PartCreator(this._parts);
            creator.ShowDialog();

            Part p = creator.GetPart();
            if (p != null)
            {
                this.PartCollection.ListView.Items.Add(new ListViewItem(new string[]
                {
                    p.ID.ToString(),
                    p.Name,
                    p.DefaultBoxCount.ToString(),
                    p.PackingInfo.BoxType.ToString(),
                    p.Description,
                    p.CreationDate.ToShortDateString()
                }));
            }
        }

        private void RemoveAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to DELETE all parts?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                _parts.RemoveAll();
                PopulateParts();
            }
        }

        private void ViewSelected_Click(object sender, EventArgs e)
        {
            if (this.PartCollection.ListView.SelectedItems.Count > 0)
                this.PartCollection_MouseDoubleClick(this, new MouseEventArgs(MouseButtons.Left, 0,0,0,0));
        }

        private void RemoveSelected_Click(object sender, EventArgs e)
        {
            if (this.PartCollection.ListView.SelectedItems.Count > 0)
            {
                var selectedItem = this.PartCollection.ListView.SelectedItems[0];
                var part = this._parts.FirstOrDefault(p => p.ID.ToString() == selectedItem.SubItems[0].Text);

                _parts.Remove(part);
                PartCollection.ListView.Items.Remove(selectedItem);
            }
        }
    }
}
