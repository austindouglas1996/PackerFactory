using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.UI.Presenters;
using PackerControlPanel.UI.Views;
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
    public partial class JobDetails : Form, IJobDetailsView
    {
        private IJobRepository _JobRepository;
        private IReceiverEntriesRepository _EntryRepository;
        private JobDetailsPresenter _Presenter;
        private Job _SelectedJob;

        public JobDetails(RepositoryBank bank)
            : this(bank.Worker.Jobs, bank.Worker.ReceiverEntries)
        {
        }

        public JobDetails(IJobRepository jobs, IReceiverEntriesRepository entries)
        {
            InitializeComponent();

            this._JobRepository = jobs;
            this._EntryRepository = entries;
        }

        public JobDetailsPresenter Presenter
        {
            get { return _Presenter; }
            set { this._Presenter = value; }
        }

        public Job Model
        {
            get { return _SelectedJob; }
            set { throw new NotSupportedException("Use LoadPart"); }
        }

        public event EventHandler<ModifyJobEventArgs> SaveChanges;
        public event EventHandler<JobOwnerChangeEventArgs> OwnerChanged;
        public event EventHandler<ModifyJobEventArgs> Remove;

        public void LoadPart(Job job)
        {
            JobIDTxt.Text = job.ID.ToString();
            JobNameTxt.Text = job.Name;
            JobPartIDTxt.Text = job.Part.ID.ToString();
            JobPartNameTxt.Text = job.Part.Name;
            JobCreationTxt.Text = job.CreationDate.ToShortDateString();
            JobModifiedTxt.Text = job.Entries.Last().CreationDate.ToShortDateString();
            JobCompletionTxt.Text = job.CompletionDate.ToShortDateString();
            JobReceivedTxt.Text = job.TotalReceived.ToString();
            JobGlobalCb.Checked = job.IsGlobal;
        }

        public void SavePart()
        {

        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message, e.GetType().ToString());
        }

        public void UpdateView()
        {
            this.Refresh();
        }
    }
}
