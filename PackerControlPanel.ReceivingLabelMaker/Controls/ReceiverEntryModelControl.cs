using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;

namespace PackerControlPanel.RPCP.Controls
{
    public partial class ReceiverEntryModelControl : UserControl, IReceiverEntryInfoView
    {
        private bool _AllowEdit = false;
        private ReceiverEntryInfoPresenter _Presenter;
        private IReceiverEntriesRepository _Repository;
        private ReceiverEntry _Model;

        public ReceiverEntryModelControl()
        {
            InitializeComponent();
        }

        public ReceiverEntryModelControl(IReceiverEntriesRepository repository)
        {
            InitializeComponent();
            _Repository = repository;

            this.Presenter = new ReceiverEntryInfoPresenter(this, repository);
        }

        public event PartEventHandler PartViewClick;
        public event JobEventHandler JobViewClick;
        public event ReceiverEventHandler ReceiverViewClick;
        public event ReceiverEntryEventHandler ReceiverLocationViewClick;
        public event EventHandler EditModeChanged;
        public event EventHandler<ReceiverEntryEventArgs> EntryChanged;

        public bool AllowEdit
        {
            get { return _AllowEdit; }
            set
            {
                _AllowEdit = value;
                OnEditModeChanged(EventArgs.Empty);
            }
        }

        public ReceiverEntryInfoPresenter Presenter
        {
            get { return _Presenter; }
            set { _Presenter = value; }
        }

        public int JobID
        {
            get
            {
                if (String.IsNullOrEmpty(JobIDTxt.Text))
                    return -1;

                return Convert.ToInt32(JobIDTxt.Text);
            }
            set { JobIDTxt.Text = value.ToString(); }
        }

        public int PartID
        {
            get
            {
                if (String.IsNullOrEmpty(PartIDTxt.Text))
                    return -1;

                return Convert.ToInt32(PartIDTxt.Text);
            }
            set { PartIDTxt.Text = value.ToString(); }
        }

        public int ReceiverID
        {
            get
            {
                if (String.IsNullOrEmpty(ReceiverIDTxt.Text))
                    return -1;

                return Convert.ToInt32(ReceiverIDTxt.Text);
            }

            set { ReceiverIDTxt.Text = value.ToString(); }
        }

        public string PartName
        {
            get { return PartNameTxt.Text; }
            set { PartNameTxt.Text = value; }
        }

        public string JobName
        {
            get { return JobNameTxt.Text; }
            set { JobNameTxt.Text = value; }
        }

        public int ID
        {
            get
            {
                if (String.IsNullOrEmpty(IDTxt.Text))
                    return -1;

                return Convert.ToInt32(IDTxt.Text);
            }
            set { IDTxt.Text = value.ToString(); }
        }

        public int BoxCount
        {
            get { if (!String.IsNullOrEmpty(BoxCountTxt.Text)) { return Convert.ToInt32(BoxCountTxt.Text); } return 0; }
            set { BoxCountTxt.Text = value.ToString(); UpdateTotal(); }
        }

        public int Boxes
        {
            get
            {
                if (!String.IsNullOrEmpty(BoxesTxt.Text))
                {
                    return Convert.ToInt32(BoxesTxt.Text);
                }

                return 0;
            }
            set { BoxesTxt.Text = value.ToString(); UpdateTotal(); }
        }

        public DateTime CreationTime
        {
            get { return DateTime.Parse(string.IsNullOrEmpty(CreationTxt.Text) ? DateTime.Now.ToString() : CreationTxt.Text); }
            set { CreationTxt.Text = value.ToShortDateString(); }
        }

        public ReceiverEntry Model
        {
            get { return _Model; }
            set { _Model = value; if (_Model != null) if (EntryChanged != null) EntryChanged(this, new ReceiverEntryEventArgs(value)); }
        }

        public string StoredBin
        {
            get { return StoredBinTxt.Text; }
            set { StoredBinTxt.Text = value; }
        }

        public void ChangeEntry(ReceiverEntry entry)
        {
            this.Model = entry;

            if (this.EntryChanged != null)
                this.EntryChanged(this, new ReceiverEntryEventArgs(entry));
        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public void UpdateView()
        {
            this.Refresh();
        }

        public void LoadEntry(ReceiverEntry entry)
        {
            this.Model = entry;

            if (this.EntryChanged != null)
                this.EntryChanged(this, new ReceiverEntryEventArgs(entry));
        }

        protected void OnEditModeChanged(EventArgs e)
        {
            if (EditModeChanged != null)
                EditModeChanged(this, e);

            SaveChangesBtn.Visible = AllowEdit;
            PartNameTxt.ReadOnly = !AllowEdit;
            JobNameTxt.ReadOnly = !AllowEdit;
        }
        
        private void UpdateTotal()
        {
            TotalTxt.Text = string.Format("{0}", Boxes * BoxCount);
        }

        private void EditModeBtn_Click(object sender, EventArgs e)
        {
            AllowEdit = !AllowEdit;
        }

        private void PartViewBtn_Click(object sender, EventArgs e)
        {
            if (PartViewClick != null)
                PartViewClick(this, new PartEventArgs(Model.Part));
        }

        private void JobViewBtn_Click(object sender, EventArgs e)
        {
            if (JobViewClick != null)
                JobViewClick(this, new JobEventArgs(Model.Job));
        }

        private void ReceiverViewBtn_Click(object sender, EventArgs e)
        {
            if (ReceiverViewClick != null)
                ReceiverViewClick(this, new ReceiverEventArgs(Model.Receiver));
        }

        private void StoredBinView_Click(object sender, EventArgs e)
        {
            if (ReceiverLocationViewClick != null)
                ReceiverLocationViewClick(this, new ReceiverEntryEventArgs(Model));
        }

        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
