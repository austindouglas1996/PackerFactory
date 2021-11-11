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
    public partial class ListViewForm : Form
    {
        private ListViewColumnSorter LvColumnSorter;

        public ListViewForm()
        {
            InitializeComponent();

            this.LvColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = this.LvColumnSorter;
            this.listView1.ColumnClick += ListView1_ColumnClick;
        }

        public ListView ListView
        {
            get { return this.listView1; }
            set { this.listView1 = value; }
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (AscendingRBTN.Checked)
                this.LvColumnSorter.Order = SortOrder.Ascending;
            else
                this.LvColumnSorter.Order = SortOrder.Descending;

            this.listView1.Sort();
        }

        private void AscendingRBTN_CheckedChanged(object sender, EventArgs e)
        {
            AscendingRBTN.Checked = true;
            DescendingRBTN.Checked = false;

            this.listView1.Sort();
        }

        private void DescendingRBTN_CheckedChanged(object sender, EventArgs e)
        {
            AscendingRBTN.Checked = false;
            DescendingRBTN.Checked = true;

            this.listView1.Sort();
        }
    }
}
