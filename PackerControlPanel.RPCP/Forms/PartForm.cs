using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.Data;
using PackerControlPanel.UI;
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
    public partial class PartForm : Form, IPartDetailsView
    {
        private PartDetailsPresenter _Presenter;
        private PackerUnitOfWork _Worker;
        private Part _LoadedPart;

        public PartForm(PackerUnitOfWork worker, Part part)
        {
            _Worker = worker;
            InitializeComponent();

            BoxTypeCb.Items.AddRange(PackageInfo.BoxTypes);

            Presenter = new PartDetailsPresenter(this, worker.Parts, part);
            _LoadedPart = part;
        }

        public PartDetailsPresenter Presenter
        {
            get { return _Presenter; }
            set { _Presenter = value; }
        }

        public Part Model
        {
            get { return _LoadedPart; }
            set { _LoadedPart = value; if (this.LoadPart != null) this.LoadPart(this, new PartEventArgs(value)); }
        }

        public int PartID
        {
            get { return Convert.ToInt32(IDTxt.Text); }
            set { IDTxt.Text = value.ToString(); }
        }

        public string PartName
        {
            get { return NameTxt.Text; }
            set { NameTxt.Text = value; }
        }

        public string PartDescription
        {
            get { return DescriptionTxt.Text; }
            set { DescriptionTxt.Text = value; }
        }

        public int BoxCount
        {
            get { return Convert.ToInt32(BoxCountTxt.Text); }
            set { BoxCountTxt.Text = value.ToString(); }
        }

        public string PackageType
        {
            get { return (string)BoxTypeCb.SelectedItem; }
            set
            {
                
                BoxTypeCb.SelectedIndex = PackageInfo.BoxTypes.ToList().IndexOf(value);
            }
        }

        public string BoxingDirections
        {
            get { return null; }
            set { }
        }
        
        public DateTime CreationTime
        {
            get { return _LoadedPart.CreationDate; }
            set { CreationTxt.Text = value.ToShortDateString(); }
        }

        public DateTime LastModifiedTime
        {
            get { return _LoadedPart.LastModifiedDate; }
            set { ModifiedTxt.Text = value.ToShortDateString(); }
        }

        public event EventHandler<PartEventArgs> LoadPart;
        public event EventHandler<ModifyPartEventArgs> SaveChanges;
        public event EventHandler<RemovePartEventArgs> Remove;

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public void UpdateView()
        {
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NoteViewerForm note = new NoteViewerForm(_LoadedPart);
            note.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JobBrowserSelector selector = new JobBrowserSelector(_Worker, _LoadedPart);
            selector.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.SaveChanges != null)
                this.SaveChanges(this, new ModifyPartEventArgs(_LoadedPart.ID, _LoadedPart));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Remove != null)
                this.Remove(this, new RemovePartEventArgs(_LoadedPart));

            this.Close();
        }
    }
}
