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

namespace PackerControlPanel.InventoryWin.Windows
{
    /// <summary>
    /// Displays a dialog window showing all recievers provided allowed one to be selected and return.
    /// </summary>
    public partial class ReceiverBrowserSelecter : Form
    {
        private IReceiverRepository receivers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverBrowserSelecter"/> class.
        /// </summary>
        /// <param name="receivers"></param>
        /// <param name="multiSelect"></param>
        public ReceiverBrowserSelecter(IReceiverRepository receivers)
        {
            this.receivers = receivers;

            InitializeComponent();

            LvSearch.ListView.MultiSelect = false;

            LvSearch.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Title", 100, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("# Of Entries.", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Creation Time", -2, HorizontalAlignment.Left);

            foreach (var receiver in receivers.GetAll())
            {
                LvSearch.ListView.Items.Add(new ListViewItem(new string[]
                {
                    receiver.ID.ToString(),
                    receiver.Name,
                    receiver.Title,
                    receiver.Entries.Count.ToString(),
                    receiver.CreationTime.ToShortDateString()
                }));
            }

            LvSearch.ListView.MouseDoubleClick += ListView_MouseDoubleClick;
        }

        /// <summary>
        /// Gets the value selected if one was.
        /// </summary>
        public Receiver SelectedValue { get; set; }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetSelectedValue();
            this.Close();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (LvSearch.ListView.SelectedItems.Count > 0)
            {
                this.SetSelectedValue();
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
                SelectedValue = receivers.Get(Int32.Parse(LvSearch.ListView.SelectedItems[0].SubItems[0].Text));
            }
        }
    }
}
