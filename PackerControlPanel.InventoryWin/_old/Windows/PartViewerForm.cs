using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data.Repository;
using PackerControlPanel.InventoryWin.Controls;
using PackerControlPanel.InventoryWin.Forms;
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
    public partial class PartViewerForm : Form
    {
        private IPartRepository parts;

        public PartViewerForm(IPartRepository parts)
        {
            InitializeComponent();

            LvSearch.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Box Count", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Box Type", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Creation Date", 100, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Description", 200, HorizontalAlignment.Left);

            this.parts = parts;

            foreach (var p in parts.GetAll().OrderBy(p => p.Name))
            {
                LvSearch.ListView.Items.Add(new ListViewItem(new string[]
                {
                    p.ID.ToString(),
                    p.Name,
                    p.DefaultBoxCount.ToString(),
                    p.PackingInfo.BoxType.ToString(),
                    p.CreationDate.ToShortDateString(),
                    p.Description,
                }));
            }

            this.LvSearch.ListView.DoubleClick += LvSearch_DoubleClick;
            this.SizeChanged += PartViewerForm_SizeChanged;
        }

        private void PartViewerForm_SizeChanged(object sender, EventArgs e)
        {
            this.LvSearch.Width = this.Width - 20;
        }

        private void LvSearch_DoubleClick(object sender, EventArgs e)
        {
            if (this.LvSearch.ListView.SelectedItems.Count > 0)
            {
                // Get selected item.
                ListViewItem selectedItem = this.LvSearch.ListView.SelectedItems[0];

                var editor = new PartViewer(this.parts, parts.Get(Int32.Parse(selectedItem.SubItems[0].Text)));
                editor.Show(this);
            }
        }
    }
}
