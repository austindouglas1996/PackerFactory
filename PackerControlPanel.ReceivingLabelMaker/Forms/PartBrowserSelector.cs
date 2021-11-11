using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data;
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
    public partial class PartBrowserSelector : Form
    {
        private PackerUnitOfWork _Worker;

        public PartBrowserSelector(PackerUnitOfWork worker)
        {
            _Worker = worker;
            InitializeComponent();
            
            listWithSearch1.ListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listWithSearch1.ListView.Columns.Add("Description", 150, HorizontalAlignment.Left);
            listWithSearch1.ListView.Columns.Add("Box Count", 100, HorizontalAlignment.Left);
            listWithSearch1.ListView.Columns.Add("Box Type", 150, HorizontalAlignment.Left);
            listWithSearch1.ListView.Columns.Add("Creation Time", 150, HorizontalAlignment.Left);
            listWithSearch1.ListView.Columns.Add("Modified Time", -2, HorizontalAlignment.Left);

            LoadList();

            listWithSearch1.ListView.MouseDoubleClick += ListView_MouseDoubleClick;
            listWithSearch1.ListView.MouseClick += ListView_MouseClick;
        }

        private void LoadList()
        {
            foreach (var part in _Worker.Parts.GetAll())
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    part.Name,
                    part.Description,
                    part.DefaultBoxCount.ToString() + "pc",
                    part.PackingInfo.BoxType,
                    part.CreationDate.ToShortDateString(),
                    part.LastModifiedDate.ToShortDateString()
                });
                item.Tag = part;

                listWithSearch1.ListView.Items.Add(item);
            }
        }

        private List<Part> GetSelectedItems()
        {
            List<Part> parts = new List<Part>();
            foreach (var part in listWithSearch1.ListView.SelectedItems)
            {
                parts.Add((Part)((ListViewItem)part).Tag);
            }
            return parts;
        }

        private void ViewSelected()
        {
            Part part = GetSelectedItems()[0];
            PartForm form = new PartForm(_Worker, part);
            form.ShowDialog();
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewSelected();
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSelected();
        }
    }
}
