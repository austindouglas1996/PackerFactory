using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Manager
{
    public partial class PartMan : Form, IPartOperationsView
    {
        private List<Part> _Parts;
        private Part SelectedPart;

        public PartMan()
        {
            InitializeComponent();

            this.PartView.ItemSelectionChanged += PartView_ItemSelectionChanged;

            this.Presenter = new PartOperationsPresenter(this, Program.Inventory.Parts);
            if (LoadParts != null)
                LoadParts(this, EventArgs.Empty);
        }

        private void PartView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var selectedItems = PartView.SelectedItems;

            if (selectedItems.Count != 0)
            {
                int id = Convert.ToInt32(PartView.SelectedItems[0].SubItems[0].Text);

                SelectedPart = Model.FirstOrDefault(p => p.ID == id);
                textBox1.Text = SelectedPart.Name;
                textBox2.Text = SelectedPart.Description;
                textBox3.Text = SelectedPart.DefaultBoxCount.ToString();

                Part parent = SelectedPart.Parent;
                textBox4.Text = parent == null ? "No parent." : parent.Name;
                textBox5.Text = parent == null ? "No parent." : parent.Description;

                textBox6.Text = SelectedPart.CreationDate.ToShortDateString();
                textBox7.Text = SelectedPart.LastModifiedDate.ToShortDateString();

                foreach (var job in SelectedPart.Jobs)
                {
                    SelectedPartJobView.Items.Clear();
                    SelectedPartJobView.Items.Add(new ListViewItem(new[]
                    {
                        job.ID.ToString(),
                        job.Name.ToString(),
                        job.TotalReceived.ToString(),
                        job.GetCurrentState.State.ToString(),
                        job.CreationTime.ToShortDateString(),
                        job.CompletionTime.ToShortDateString(),
                    }));
                }
            }
        }

        public PartOperationsPresenter Presenter { get; set; }
        public List<Part> Model
        {
            get { return _Parts; }
            set
            {
                _Parts = value;
                UpdateView();
            }
        }

        public event EventHandler LoadParts;
        public event EventHandler<AddPartEventArgs> AddPart;
        public event EventHandler<GetPartEventArgs> GetPart;
        public event EventHandler<ModifyPartEventArgs> UpdatePart;
        public event EventHandler<RemovePartEventArgs> RemovePart;

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message, e.GetType().Name);
        }

        public void UpdateView()
        {
            PopulateList();
        }

        protected void PopulateList()
        {
            PartView.Items.Clear();
            foreach (var part in this.Model)
            {
                PartView.Items.Add(new ListViewItem(new[]
                {
                    part.ID.ToString(),
                    part.Name,
                    part.Description,
                    part.DefaultBoxCount.ToString() + "pc",
                    part.PackingInfo.BoxType.ToString(),
                    part.CreationDate.ToShortDateString(),
                    part.LastModifiedDate.ToShortDateString()
                }));
            }
        }
    }
}
