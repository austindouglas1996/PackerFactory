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
    public partial class JobsCollectionViewer : Form
    {
        private IJobRepository _Jobs;
        private IPartRepository _Parts;

        public JobsCollectionViewer(IPartRepository parts, IJobRepository jobs)
        {
            InitializeComponent();
            this._Jobs = jobs;
            this._Parts = parts;

            // Add columns.
            this.JobCollection.ListView.Columns.AddRange(Helpers.Helper.JobColumnHeader);

            // Populate list.
            this.PopulateList();

            this.JobCollection.ListView.MouseDoubleClick += ListView_MouseDoubleClick;
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.JobCollection.ListView.SelectedItems.Count > 0)
            {
                var selectedItem = this.JobCollection.ListView.SelectedItems[0];
                var selectedIndex = this.JobCollection.ListView.Items.IndexOf(selectedItem);

                var job = _Jobs.Get(Int32.Parse(selectedItem.SubItems[0].Text));

                JobViewer viewer = new JobViewer(_Parts, _Jobs, job);
                viewer.ShowDialog();
            }
        }

        private void PopulateList()
        {
            foreach (var job in this._Jobs.GetAll())
            {
                this.JobCollection.ListView.Items.Add(new ListViewItem(new string[]
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
    }
}
