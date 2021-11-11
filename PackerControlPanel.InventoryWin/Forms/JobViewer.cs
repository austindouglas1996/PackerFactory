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
    public partial class JobViewer : Form
    {
        private IJobRepository _Jobs;
        private IPartRepository _Parts;
        private Job job;

        public JobViewer(IPartRepository parts, IJobRepository jobs, Job job)
        {
            InitializeComponent();

            EntriesList.GridLines = true;
            EntriesList.View = View.Details;
            EntriesList.Columns.AddRange(Helpers.Helper.ReceiverEntryColumnHeader);

            var jobTypes = Enum.GetNames(typeof(JobStateType));
            for (int i = 0; i < jobTypes.Count(); i++)
            {
                JobStateType jType = (JobStateType)Enum.Parse(typeof(JobStateType), jobTypes[i]);
                this.JobStatus.Items.Add(new JobStateTypeItem(i, jType));
            }

            this.PartName.LostFocus += PartName_LostFocus;

            this._Jobs = jobs;
            this._Parts = parts;
            this.LoadJob(job);
        }

        protected virtual void LoadJob(Job job)
        {
            this.job = job;

            JobID.Text = job.ID.ToString();
            JobName.Text = job.Name;
            JobCreationTime.Text = job.CreationDate.ToShortDateString();
            JobCompletionTime.Text = job.CompletionDate.ToShortDateString();
            JobStatus.SelectedIndex = Array.IndexOf(Enum.GetValues(typeof(JobStateType)), job.GetCurrentState.State);

            PartID.Text = job.Part.ID.ToString();
            PartName.Text = job.Part.Name;

            foreach (var entry in job.Entries)
            {
                EntriesList.Items.Add(new ListViewItem(new string[]
                {
                    entry.ID.ToString(),
                    entry.Receiver.Name,
                    entry.Job.Name.ToString(),
                    entry.Total.ToString(),
                    entry.BoxCount.ToString(),
                    entry.Boxes.ToString(),
                    string.Join(",", entry.ManuDates.ToList().Select(i => i.Date.ToShortDateString())),
                    entry.CreationTime.ToShortDateString()
                }));
            }

            TotalCollected.Text = job.TotalReceived.ToString();

            int total7 = 0;
            int total30 = 0;

            var entries7 = job.Entries.Where(e => e.CreationTime >= DateTime.Now - TimeSpan.FromDays(7));
            var entries30 = job.Entries.Where(e => e.CreationTime >= DateTime.Now - TimeSpan.FromDays(30));

            foreach (var e7 in entries7)
                total7 += e7.Total;

            foreach (var e30 in entries30)
                total30 += e30.Total;

            TotalCollected7.Text = total7.ToString();
            TotalCollected30.Text = total30.ToString();
        }

        protected virtual void SaveJob()
        {
            this.job.Name = this.JobName.Text;

            var selectedState = (JobStateTypeItem)this.JobStatus.SelectedItem;
            if (selectedState == null)
                throw new ArgumentNullException("Failed to retreieve the state type.");

            if (selectedState.Type != this.job.GetCurrentState.State)
            {
                this.job.SetState(selectedState.Type);
            }

            this._Jobs.Edit(this.job);
        }

        private void OpenPart_Click(object sender, EventArgs e)
        {
            PartViewer pViewer = new PartViewer(this._Parts, this.job.Part);
            pViewer.ShowDialog();
        }

        private void PartName_LostFocus(object sender, EventArgs e)
        {
            if (PartName.Text == "")
            {
                PartName.Text = this.job.Part.Name;
            }

            Part part = this._Parts.FirstOrDefault(p => p.Name.ToLower() == PartName.Text.ToLower());
            if (part == null)
            {
                MessageBox.Show("Failed to find a part by the name.");
                PartName.Focus();
            }

            this.job.Part = part;
            this.PartID.Text = part.ID.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SaveJob();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
