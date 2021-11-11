using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackerControlPanel.Image.Views;
using PackerControlPanel.Data;
using PackerControlPanel.Image.Presenters;
using PackerControlPanel.Image;
using PackerControlPanel.Image.Repository;
using PackerControlPanel.Core.Domain;
using System.Drawing.Printing;
using PackerControlPanel.Image.Drawings;
using PackerControlPanel.Data.Common;
using PackerControlPanel.Core.Repository;

namespace PackerControlPanel.UI.Image.Controls
{
    public partial class LabelFactoryControl : UserControl, ILabelFactoryBaseView<LabelOrder>
    {
        private bool Offline = false;

        /// <summary>
        /// Manages our db and model data.
        /// </summary>
        private PackerUnitOfWork _Inventory;

        /// <summary>
        /// Manages the view logic.
        /// </summary>
        private LabelFactoryPresenter<LabelOrder> _Presenter;

        /// <summary>
        /// Manages the creation of all labels.
        /// </summary>
        private LabelFactoryProcessor<LabelOrder> _Processor;

        /// <summary>
        /// Manages the descriptions of parts.
        /// </summary>
        private IPartDescRepository _DescriptionRepository;

        /// <summary>
        /// Designer view entry.
        /// </summary>
        public LabelFactoryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelFactoryControl"/> class.
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="descRepository"></param>
        public LabelFactoryControl(PackerUnitOfWork worker, IPartDescRepository descRepository, bool offline)
        {
            this.Offline = offline;

            InitializeComponent();

            // Get inventory setup.
            this._Inventory = worker;

            if (descRepository == null)
                throw new ArgumentException("Description repository is null.");

            // Description repository.
            this._DescriptionRepository = descRepository;

            if (offline)
            {
                this._Presenter = new LabelFactoryPresenter<LabelOrder>(this, descRepository, new DefaultLabelDrawing());
                this._Processor = new LabelFactoryProcessorDefaultOffline(this, new LabelOrderBuilder<LabelOrder>());
            }
            else
            {
                this._Presenter = new LabelFactoryPresenter<LabelOrder>(this, this._Inventory, descRepository, new DefaultLabelDrawing());
                this._Processor = new LabelFactoryProcessorDefault(this, new LabelOrderBuilder<LabelOrder>());

            }

            this.OrderNumTb.TextChanged += OrderNumTb_TextChanged;

            this.Reset();
        }

        private void RunLabelsBtn_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action(this, null);
        }

        private void OrderNumTb_TextChanged(object sender, EventArgs e)
        {
            if (Offline)
                return;

            if (this.JobNameChanged != null)
                this.JobNameChanged(this, new GetJobEventArgs(WorkOrder));

            if (this.GetJob != null)
                this.EditJobBtn.Enabled = true;
            else
                this.EditJobBtn.Enabled = false;
        }

        #region Fields
        public string PackerName
        {
            get
            {
                return this.PackerNameTb.Text;
            }
            set
            {
                this.PackerNameTb.Text = value;
            }
        }

        public string PartName
        {
            get { return PartNameTb.Text; }
            set
            {
                PartNameTb.Text = value;
            }
        }

        public string PartDescription
        {
            get
            {
                if (_DescriptionRepository == null)
                    return "";

                if (_SelectedPart == null || _SelectedPart.PartName != this.PartName)
                    _SelectedPart = _DescriptionRepository.FirstOrDefault(p => p.PartName == this.PartName);

                if (_SelectedPart == null)
                    return "No description.";

                return _SelectedPart.FormalDescription;
            }
        }
        private PartDescInfo _SelectedPart = null;

        public int[] Boxes
        {
            get { return SplitStringToList<int>(BoxesTb.Text).ToArray(); }
            set
            {
                if (value == null)
                    BoxesTb.ToString();

                BoxesTb.Text = SplitArrayToString<int>(value);
            }
        }

        public int[] BoxCount
        {
            get { return SplitStringToList<int>(BoxCountTb.Text).ToArray(); }
            set
            {
                if (value == null)
                    BoxCountTb.Text = "";

                BoxCountTb.Text = SplitArrayToString<int>(value);
            }
        }

        public string WorkOrder
        {
            get { return OrderNumTb.Text; }
            set { OrderNumTb.Text = value; }
        }

        public string LotOrder
        {
            get { return LotOrderTb.Text; }
            set { LotOrderTb.Text = value; }
        }

        public char[] Shift
        {
            get { return SplitStringToList<char>(ShiftsTb.Text).ToArray(); }
            set
            {
                if (value == null)
                    ShiftsTb.Text = "";

                ShiftsTb.Text = SplitArrayToString<char>(value);
            }
        }

        public string MfrDates
        {
            get { return MfrDatesTb.Text; }
            set { MfrDatesTb.Text = value; }
        }

        public Dictionary<DateTime[], int>[] MfrDatesProcessed
        {
            get
            {
                return _MfrDatesProcessed;
            }
        }
        private Dictionary<DateTime[], int>[] _MfrDatesProcessed = new List<Dictionary<DateTime[], int>>().ToArray();

        public Bitmap PreviewImg
        {
            get { return _PreviewImg; }
            set
            {
                _PreviewImg = value;
            }
        }
        private Bitmap _PreviewImg;

        public LabelFactoryPresenter<LabelOrder> Presenter
        {
            get { return _Presenter; }
        }

        public LabelFactoryProcessor<LabelOrder> Processor
        {
            get { return _Processor; }
        }

        public Part GetPart
        {
            get
            {
                if (this.Offline)
                    return new Part(PartName, 0, PartDescription);

                Part part = _Inventory.Parts.FirstOrDefault(p => p.Name.ToLower() == PartName.ToLower());

                if (part == null)
                {
                    part = new Part(PartName.ToLower(), -1);
                }

                return part;
            }
        }

        public Job GetJob
        {
            get
            {
                if (this.Offline)
                    return new Job(GetPart, WorkOrder);

                Job job = _Inventory.Jobs.FirstOrDefault(j => j.Name.ToLower() == WorkOrder.ToLower());

                if (job == null)
                    job = new Job(GetPart, WorkOrder.ToLower());

                return job;
            }
        }

        LabelFactoryProcessor<LabelOrder> ILabelFactoryBaseView<LabelOrder>.Processor
        {
            get { return _Processor; }
        }

        #endregion

        public event AddPartEventHandler CreatePart;
        public event EventHandler UpdateImgPreview;
        public event AddPartDescEventHandler CreatePartDesc;
        public event GetPartEventHandler PartNameChanged;
        public event GetJobEventHandler JobNameChanged;
        public event ActionEventHandler Action;

        public void Reset()
        {
            if (!this.checkBox1.Checked)
                this.PackerNameTb.Text = "";

            PartName = "";
            Boxes = null;
            BoxCount = null;
            WorkOrder = "";
            Shift = null;
            MfrDates = "";

            this.OnUpdatePreview(EventArgs.Empty);
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message, e.GetType().Name);
        }

        protected void OnCreatePart(AddPartEventArgs e)
        {
            if (CreatePart != null)
                CreatePart(this, e);
        }

        protected void OnCreatePartDesc(AddPartDescEventArgs e)
        {
            if (CreatePartDesc != null)
                CreatePartDesc(this, e);
        }

        protected void OnUpdatePreview(EventArgs e)
        {
            if (UpdateImgPreview != null)
                UpdateImgPreview(this, e);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void UpdatePreviewBtn_Click(object sender, EventArgs e)
        {
            this.OnUpdatePreview(e);
        }

        private void PartName_LostFocus(object sender, EventArgs e)
        {
            if (this.Offline)
                return;

            if (string.IsNullOrEmpty(PartName))
                return;

            if (this.PartNameChanged != null)
                this.PartNameChanged(this, new GetPartEventArgs(PartNameTb.Text));

            if (this.GetPart != null)
                this.EditPartBtn.Enabled = true;
            else
                this.EditPartBtn.Enabled = false;

            if (this._Inventory.Parts.Get(PartNameTb.Text) == null)
            {
                /*
                PartCreatorForm pForm = new PartCreatorForm(this._Inventory.Parts);
                DialogResult result = pForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    OnCreatePart(new AddPartEventArgs(pForm.Model));
                }
                */
            }
        }

        private void MfrDates_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MfrDatesTb.Text))
            {
                this._MfrDatesProcessed = new List<Dictionary<DateTime[], int>>().ToArray();
                return;
            }

            _MfrDatesProcessed = MfrDateProcessor.Standard.DecipherString(this.MfrDates);

        }

        private void CheckBox_BtnClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckBox check = (CheckBox)sender;
                if (check == null)
                    throw new InvalidCastException("Invalid cast");

                check.Checked = !check.Checked;
            }
        }

        private List<T> SplitStringToList<T>(string args)
        {
            if (string.IsNullOrEmpty(args))
                return new List<T>();

            List<T> values = new List<T>();

            foreach (var val in args.Split(','))
            {
                values.Add((T)Convert.ChangeType(val, typeof(T)));
            }

            return values;
        }

        private string SplitArrayToString<T>(T[] array)
        {
            if (array == null)
                return "";

            if (array.Length == 0)
                return "";

            string value = "";
            foreach (var entry in array)
                value += entry.ToString() + ",";

            // I'm lazy ):
            value = value.TrimEnd(',');

            return value;
        }
    }
}
