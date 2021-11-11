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

namespace PackerControlPanel.InventoryWin.Forms
{
    public partial class JobCreator : Form
    {
        private IJobRepository _jobs;
        private IPartRepository _parts;

        private Part selectedPart;
        private Job job;

        public JobCreator(IJobRepository jobs, IPartRepository parts)
        {
            InitializeComponent();

            this._jobs = jobs;
            this._parts = parts;

            JobName.LostFocus += JobName_LostFocus;
            PartName.LostFocus += PartName_LostFocus;
        }

        public Job GetResult()
        {
            return this.job;
        }

        private void PartName_LostFocus(object sender, EventArgs e)
        {
            Part p = _parts.GetPartWithJobs(PartName.Text);
            if (p == null)
            {
                MessageBox.Show("Unable to find a part by that name.");
                PartName.BackColor = Color.Red;
                return;
            }

            PartName.BackColor = Color.White;

            this.selectedPart = p;
        }

        private void JobName_LostFocus(object sender, EventArgs e)
        {
            if (_jobs.GetJobByName(JobName.Text) != null)
            {
                MessageBox.Show("A job by that name already exists. Please choose a new name.");
                JobName.BackColor = Color.Red;
                return;
            }

            JobName.BackColor = Color.White;
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            job = new Job(selectedPart, JobName.Text);
            this._jobs.Add(job);

            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
