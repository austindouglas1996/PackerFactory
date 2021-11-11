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

namespace PackerControlPanel.UI.Forms
{
    public partial class PartGetForm : Form
    {
        private IPartRepository _Parts;

        public PartGetForm(IPartRepository parts)
        {
            InitializeComponent();

            this._Parts = parts;
            this.SearchBox.TextChanged += SearchBox_TextChanged;

            this.PopulateView();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.PartView1.FindItemWithText(this.SearchBox.Text, true, 0);
            if (item != null)
                this.PartView1.TopItem = item;
        }

        public bool MultiSelect
        {
            get { return PartView1.MultiSelect; }
            set { PartView1.MultiSelect = value; }
        }

        public Part[] Value { get; private set; }

        private void PopulateView()
        {
            foreach (var part in _Parts.GetAll())
            {
                this.PartView1.Items.Add(CreateItem(part));
            }

            PartView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            PartView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private ListViewItem CreateItem(Part part)
        {
            ListViewItem item = new ListViewItem(new string[]
            {
                part.ID.ToString(),
                part.Name.ToString(),
                part.Description.ToString(),
                part.DefaultBoxCount.ToString(),
                part.PackingInfo.BoxType,
                part.Parent == null ? "None" : part.Parent.Name.ToString(),
                part.LastModifiedDate.ToShortDateString(),
                part.CreationDate.ToShortDateString()
            });

            return item;
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            List<Part> chosen = new List<Part>();

            foreach (ListViewItem item in this.PartView1.SelectedItems)
            {
                int id = Convert.ToInt32((item.SubItems[0].Text));
                chosen.Add(_Parts.Get(id));
            }

            Value = chosen.ToArray();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
