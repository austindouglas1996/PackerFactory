using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Common;
using PackerControlPanel.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.RPCP.Forms
{
    public partial class JobForm : Form, IJobDetailsView
    {
        private PackerUnitOfWork _Worker;
        private Job _LoadedJob;
        private JobDetailsPresenter _Presenter;

        public JobForm(PackerUnitOfWork worker, Job job)
        {
            InitializeComponent();

            EntriesView.ListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            EntriesView.ListView.Columns.Add("Part Name", 100, HorizontalAlignment.Left);
            EntriesView.ListView.Columns.Add("Boxes", 100, HorizontalAlignment.Left);
            EntriesView.ListView.Columns.Add("Box Count", 150, HorizontalAlignment.Left);
            EntriesView.ListView.Columns.Add("Total Received", 150, HorizontalAlignment.Left);
            EntriesView.ListView.Columns.Add("Creation Time", 150, HorizontalAlignment.Left);
            EntriesView.ListView.Columns.Add("Received Location", 150, HorizontalAlignment.Left);
            EntriesView.ListView.MouseUp += Entries_MouseUp;

            _Worker = worker;
            _LoadedJob = job;
            _Presenter = new JobDetailsPresenter(this, _Worker.Jobs, job);

            this.StateCb.DataSource = Enum.GetValues(typeof(JobStateType));

            LoadEntries();
        }

        public JobDetailsPresenter Presenter
        {
            get { return _Presenter; }
            set { _Presenter = value; }
        }

        public Job Model
        {
            get { return _LoadedJob; }
            set { throw new NotSupportedException("Setting the model not supported."); }
        }

        public int JobID
        {
            get { return Convert.ToInt32(IDTxt.Text); }
            set { IDTxt.Text = value.ToString(); }
        }

        public int PartID
        {
            get { return Convert.ToInt32(PartIDTxt.Text); }
            set { PartIDTxt.Text = value.ToString(); }
        }

        public string JobName
        {
            get { return NameTxt.Text; }
            set { NameTxt.Text = value; }
        }

        public string PartName
        {
            get { return PartNameTxt.Text; }
            set { PartNameTxt.Text = value; }
        }

        public bool IsGlobal
        {
            get { return GlobalCb.Checked; }
            set { GlobalCb.Checked = value; }
        }

        public int TotalReceived
        {
            get { return Convert.ToInt32(TotalReceivedTxt.Text); }
            set { TotalReceivedTxt.Text = value.ToString(); }
        }

        public JobStateType State
        {
            get
            {
                JobStateType state;
                Enum.TryParse<JobStateType>(StateCb.SelectedValue.ToString(), out state);
                return state;
            }
            set { StateCb.SelectedValue = value; }
        }

        public DateTime CreationTime
        {
            get { return _LoadedJob.CreationDate; }
            set { CreationTxt.Text = value.ToShortDateString(); }
        }

        public DateTime ModifiedTime
        {
            get { return _LoadedJob.LastModifiedDate; }
            set { ModifiedTxt.Text = value.ToShortDateString(); }
        }

        public DateTime CompletionTime
        {
            get { return _LoadedJob.CompletionDate; }
            set { CompletionTxt.Text = value.ToShortDateString(); }
        }

        public event EventHandler<ModifyJobEventArgs> SaveChanges;
        public event EventHandler<JobOwnerChangeEventArgs> OwnerChanged;
        public event EventHandler<ModifyJobEventArgs> Remove;

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public void UpdateView()
        {
            this.Refresh();
        }

        private List<ListViewItem> GetSelectedItems
        {
            get
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (var i in EntriesView.ListView.SelectedItems)
                {
                    items.Add((ListViewItem)i);
                }

                return items;
            }
        }


        private void LoadEntries()
        {
            if (_LoadedJob.Entries == null)
                return; 

            foreach (var entry in _LoadedJob.Entries)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    entry.ID.ToString(),
                    entry.Part.Name,
                    entry.Boxes.ToString(),
                    entry.BoxCount.ToString(),
                    entry.Total.ToString(),
                    entry.CreationDate.ToShortDateString(),
                    entry.Location
                });
                item.Tag = entry;

                EntriesView.ListView.Items.Add(item);
            }
        }

        private void UpdateJob_Click(object sender, EventArgs e)
        {
            if (this.SaveChanges != null)
                this.SaveChanges(this, new ModifyJobEventArgs(_LoadedJob.ID, _LoadedJob));

            _Worker.Complete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JobHtmlExporter jobExport = new JobHtmlExporter("./Jobs");
            string ex = jobExport.Export(this._LoadedJob);
            Process.Start(ex);
        }

        private void Entries_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void Notes_Click(object sender, EventArgs e)
        {
            if (GetSelectedItems.Count == 0)
                return; 

            ReceiverEntry entry = (ReceiverEntry)(GetSelectedItems[0].Tag);

            NoteViewerForm note = new NoteViewerForm(entry);
            note.ShowDialog();

            _Worker.Complete();
        }
    }
}
