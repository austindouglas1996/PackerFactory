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
    public partial class JobViewerForm : Form
    {
        private IJobRepository _Jobs;

        public JobViewerForm(IJobRepository jobsCollection)
        {
            InitializeComponent();

            LvSearch.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Part ID/Name", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Complete Quantity", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Creation Date", 100, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Completion Date", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Last Entry Date", 150, HorizontalAlignment.Left);

            this._Jobs = jobsCollection;

            foreach (var job in this._Jobs.GetAll())
            {
                bool containsEntries = job.Entries.Count != 0;

                LvSearch.ListView.Items.Add(new ListViewItem(new string[]
                {
                    job.ID.ToString(),
                    job.Name,
                    string.Format("({0}) {1}", job.PartID, job.Part.Name),
                    job.TotalReceived.ToString(),
                    job.CreationDate.ToShortDateString(),
                    job.CompletionDate.ToShortDateString(),
                    containsEntries == true ? job.Entries.Last().CreationTime.ToShortDateString() : "No entries found."
                }));
            }
        }
    }
}
