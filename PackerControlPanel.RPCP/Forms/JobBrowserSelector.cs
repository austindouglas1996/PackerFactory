using PackerControlPanel.Core.Domain;
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
    public partial class JobBrowserSelector : Form
    {
        private PackerUnitOfWork _Worker;
        private Part _Part = null;

        public JobBrowserSelector(PackerUnitOfWork Worker, Part part = null)
        {
            this._Worker = Worker;

            _Part = part;

            InitializeComponent();

            LvSearch.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Part Name", 100, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Total Received", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Total Entries", 150, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Creation Date", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("State", -2, HorizontalAlignment.Left);
            LvSearch.ListView.Columns.Add("Completion Date", -2, HorizontalAlignment.Left);

            LvSearch.ListView.MouseDoubleClick += ListView_MouseDoubleClick;
            LvSearch.ListView.MouseClick += ListView_MouseClick;

            LoadList();
        }

        private void LoadList()
        {

            foreach (var job in _Part == null ? _Worker.Jobs.GetAll() : _Part.Jobs) 
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    job.ID.ToString(),
                    job.Name,
                    job.Part.Name,
                    job.TotalReceived.ToString(),
                    job.Entries.Count().ToString(),
                    job.CreationDate.ToShortDateString(),
                    job.GetCurrentState().State.ToString(),
                    job.CompletionDate.ToShortDateString()
                });
                item.Tag = job;

                LvSearch.ListView.Items.Add(item);
            }
        }
        private List<Job> GetSelectedItems()
        {
            List<Job> jobs = new List<Job>();
            foreach (var job in LvSearch.ListView.SelectedItems)
            {
                jobs.Add((Job)((ListViewItem)job).Tag);
            }
            return jobs;
        }

        private void ViewSelected()
        {
            Job job = GetSelectedItems()[0];
            JobForm form = new JobForm(_Worker, job);
            form.ShowDialog();
        }


        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewSelected();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
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

    }
}
