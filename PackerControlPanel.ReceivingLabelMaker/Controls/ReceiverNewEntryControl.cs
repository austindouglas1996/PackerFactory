using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackerControlPanel.RPCP.Common;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
using PackerControlPanel.RPCP.Forms;
using PackerControlPanel.Image;
using PackerControlPanel.Image.Views;
using PackerControlPanel.Data.Common;
using PackerControlPanel.UI;
using PackerControlPanel.Image.Presenters;
using PackerControlPanel.Image.Drawings;

namespace PackerControlPanel.RPCP.Controls
{
    public partial class ReceiverNewEntryControl : UserControl, ILabelFactoryBaseView<LabelOrder>
    {
        /// <summary>
        /// Manages repository inventory.
        /// </summary>
        private PackerUnitOfWork Worker;

        /// <summary>
        /// Manages the creation of receiver entries and labels.
        /// </summary>
        private LabelFactoryProcessor<LabelOrder> _Processor;

        /// <summary>
        /// UI Presenter.
        /// </summary>
        private LabelFactoryPresenter<LabelOrder> _Presenter;

        /// <summary>
        /// Initializes a new instance of the receivernewentrycontrol controller.
        /// </summary>
        /// <param name="worker"></param>
        public ReceiverNewEntryControl(PackerUnitOfWork worker)
        {
            this.Worker = worker;

            // Create our processor. Uses the default factory processor.
            this._Processor = new LabelFactoryProcessorDefault(this, new LabelOrderBuilder<LabelOrder>());

            // Create and start the presenter. We no longer use the DescRepository.
            _Presenter = new LabelFactoryPresenter<LabelOrder>(this, this.Worker, null, new DefaultLabelDrawing());

            InitializeComponent();

            // Set box types.
            this.BoxTypeCb.Items.AddRange(PackageInfo.BoxTypes);
        }

        public event EventHandler UpdateImgPreview;
        public event AddPartEventHandler CreatePart;
        public event GetPartEventHandler PartNameChanged;
        public event GetJobEventHandler JobNameChanged;
        public event ActionEventHandler Action;

        public LabelFactoryProcessor<LabelOrder> Processor
        {
            get { return _Processor; }
        }

        public LabelFactoryPresenter<LabelOrder> Presenter
        {
            get { return _Presenter; }
        }

        public string PackerName
        {
            get { return PackerTb.Text; }
            set { PackerTb.Text = value; }
        }

        public string PartName
        {
            get { return PartNameTb.Text; }
            set
            {
                PartNameTb.Text = value;
                OnPartNameChanged();
            }
        }

        public Part GetPart
        {
            get { return Worker.Parts.Get(PartName); }
        }

        public string PartDescription
        {
            get { return DescriptionTb.Text; }
            set { DescriptionTb.Text = value; }
        }

        public int[] Boxes
        {
            get
            {
                return Helper.SplitStringToList<int>(BoxesTb.Text).ToArray();
            }

            set
            {
                BoxesTb.Text = Helper.SplitArrayToString<int>(value);
            }
        }

        public int[] BoxCount
        {
            get
            {
                return Helper.SplitStringToList<int>(BoxCountsTb.Text).ToArray();
            }

            set
            {
                BoxCountsTb.Text = Helper.SplitArrayToString<int>(value);
            }
        }

        public string WorkOrder
        {
            get { return WorkOrderTb.Text; }
            set
            {
                WorkOrderTb.Text = value;

                if (this.JobNameChanged != null)
                    this.JobNameChanged(this, new GetJobEventArgs(value));
            }
        }

        public Job GetJob
        {
            get
            {
                if (String.IsNullOrEmpty(WorkOrder))
                    return Worker.Jobs.Get(" ");

                return Worker.Jobs.Get(WorkOrder);
            }
        }

        public string LotOrder
        {
            get { return "Deprecated"; }
            set { throw new NotSupportedException(); }
        }

        public char[] Shift
        {
            get { return new char[0]; }
            set { throw new NotSupportedException(); }
        }

        public string MfrDates
        {
            get { return ""; }
            set { }
        }

        public Dictionary<DateTime[], int>[] MfrDatesProcessed
        {
            get { return new Dictionary<DateTime[], int>[0]; }
        }

        public Bitmap PreviewImg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Reset()
        {
            OnResetClicked(this, EventArgs.Empty);
        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public void UpdateView()
        {
            this.Refresh();
        }

        protected virtual void OnCreatePart(Part existingPart = null)
        {
            NewPartForm newPart = new NewPartForm(Worker, PartName);
            DialogResult result = newPart.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (CreatePart != null)
                {
                    CreatePart(this, new AddPartEventArgs(newPart.NewPart));
                }
            }
        }

        protected virtual void OnPartNameChanged()
        {
            // Reset the part information.
            if (PartName == "")
            {
                this.DescriptionTb.Text = "";
                this.BoxCountTb.Text = "";
                this.BoxTypeCb.SelectedIndex = 0;

                // Disable part editing.
                this.PartEditBtn.Enabled = false;
                this.PartEditBtn.BackColor = Color.SlateGray;
            }
            else
            {
                // Retrieve the part.
                Part part = GetPart;

                // Part not found. Let's create it?
                if (part == null)
                {
                    OnCreatePart();
                    part = GetPart;
                }

                if (part == null)
                    return;

                // Set part information.
                this.DescriptionTb.Text = part.Description;
                this.BoxCountTb.Text = part.DefaultBoxCount.ToString();
                this.BoxTypeCb.SelectedIndex = this.BoxTypeCb.FindStringExact(GetPart.PackingInfo.BoxType.ToString());

                // Enable edit box.
                this.PartEditBtn.Enabled = true;
                this.PartEditBtn.BackColor = Color.DodgerBlue;
            }

            if (PartNameChanged != null)
                PartNameChanged(this, new GetPartEventArgs(PartName));
        }

        private void OnAction(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PartName) ||
                string.IsNullOrEmpty(BoxesTb.Text) ||
                string.IsNullOrEmpty(BoxCountTb.Text))
            {
                MessageBox.Show("Make sure all text fields have some type of value before creating an entry.");
                return;
            }

            var actionHandler = new LabelFactoryActionHandler();

            if (GetJob == null)
            {
                DialogResult result = MessageBox.Show("Unable to find job. Would you like to create and assign to this part?", "Unable to find job.", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Aborting process.");
                    return;
                }
                else
                {
                    Job job = new Job(GetPart, WorkOrder);
                    Worker.Jobs.Add(job);
                    Worker.Complete();
                }
            }

            if (BoxCount[0] != GetPart.DefaultBoxCount && GetPart.DefaultBoxCount != -1)
            {
                DialogResult result = MessageBox.Show(
                    "Box count does not match that of the default part box count. Would you still like to proceed?", 
                    "Box count mismatch.", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;
            }

            if (Action != null)
                this.Action(this, new ActionEventArgs(actionHandler));

            this.PartNameTb.Focus();
        }

        /// <summary>
        /// Allow part editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditPartClick(object sender, EventArgs e)
        {
            this.PartEditCancelBtn.Visible = true;
            this.PartEditBtn.Visible = false;
            this.PartSaveInfoBtn.Visible = true;

            this.BoxTypeCb.Enabled = true;
            this.BoxCountTb.Enabled = true;
        }

        /// <summary>
        /// Cancel part editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelPartClick(object sender, EventArgs e)
        {
            this.PartEditCancelBtn.Visible = false;
            this.PartEditBtn.Visible = true;
            this.PartSaveInfoBtn.Visible = false;

            this.BoxTypeCb.Enabled = false;
            this.BoxCountTb.Enabled = false;
        }

        /// <summary>
        /// Reset part form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResetClicked(object sender, EventArgs e)
        {
            this.PartName = "";
            this.PartNameTb.Clear();
            this.BoxCountsTb.Clear();
            this.BoxesTb.Clear();
            this.WorkOrderTb.Clear();
            this.OnPartNameChanged();
        }

        /// <summary>
        /// Save part information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSavePartClick(object sender, EventArgs e)
        {
            if (GetPart == null)
                return;

            if (this.BoxCountTb.Text == "")
            {
                MessageBox.Show("Failed to save part information: BoxCount was empty or null.");
                return;
            }

            GetPart.DefaultBoxCount = Convert.ToInt32(this.BoxCountTb.Text);
            GetPart.PackingInfo.BoxType = this.BoxTypeCb.Text;

            Worker.Parts.Edit(GetPart);

            this.OnCancelPartClick(sender, e);
        }

        private void PartFocusLost(object sender, EventArgs e)
        {
            this.OnPartNameChanged();
        }
    }
}
