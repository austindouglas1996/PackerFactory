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

namespace PackerControlPanel.RPCP.Forms
{
    public partial class TransferBrowserSelector : Form
    {
        private ITransferRepository transfers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverBrowserSelecter"/> class.
        /// </summary>
        /// <param name="transfers"></param>
        /// <param name="multiSelect"></param>
        public TransferBrowserSelector(ITransferRepository transfers)
        {
            this.transfers = transfers;

            InitializeComponent();

            LvSearch.ListView.MultiSelect = false;

            LvSearch.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("State", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("# Of Entries.", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Creation Time", -2, HorizontalAlignment.Left);

            var sorted = transfers.GetAll();
            sorted.OrderBy(t => t.CreationTime);

            foreach (var transfer in sorted)
            {
                LvSearch.ListView.Items.Add(new ListViewItem(new string[]
                {
                    transfer.ID.ToString(),
                    transfer.Name,
                    transfer.State.ToString(),
                    transfer.Entries.Count().ToString(),
                    transfer.CreationTime.ToShortDateString()
                }));
            }

            LvSearch.ListView.MouseDoubleClick += ListView_MouseDoubleClick;
        }

        /// <summary>
        /// Gets the value selected if one was.
        /// </summary>
        public Transfer SelectedValue { get; set; }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetSelectedValue();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (LvSearch.ListView.SelectedItems.Count > 0)
            {
                this.SetSelectedValue();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Finds the selected item in the listview and then and sets <see cref="SelectedValue"/> with the selected item.
        /// </summary>
        private void SetSelectedValue()
        {
            if (LvSearch.ListView.SelectedItems.Count > 0)
            {
                SelectedValue = transfers.Get(Int32.Parse(LvSearch.ListView.SelectedItems[0].SubItems[0].Text));
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
