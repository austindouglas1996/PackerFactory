using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.UI;
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
    public partial class PartDetailsForm : Form, IPartDetailsView
    {
        private PartDetailsPresenter _Presenter;
        private IPartRepository _Repository;

        private Part _Part = null;
        private Part PartParent = null;
        private List<Part> _Children = new List<Part>();

        public PartDetailsForm(IPartRepository repository, Part part)
        {
            this.InitializeComponent();

            this._Repository = repository;
            this._Part = part;

            this._Presenter = new PartDetailsPresenter(this, repository, part);

            this.AcceptBtn.Click += AcceptBtn_Click;
            this.CancelBtn.Click += CancelBtn_Click;
            this.ParentSetBtn.Click += ParentSetBtn_Click;
            this.ParentClearBtn.Click += ParentClearBtn_Click;
            this.ChildrenAddBtn.Click += ChildrenAddBtn_Click;
            this.ChildrenRemoveSelectedBtn.Click += ChildrenRemoveSelectedBtn_Click;
            this.ChildrenRemoveAllBtn.Click += ChildrenRemoveAllBtn_Click;

            var cbValues = PackageInfo.BoxTypes;
            this.BoxTypeCb.DataSource = cbValues;
            this.BoxTypeCb.DisplayMember = "Name";
            this.BoxTypeCb.SelectedIndex = 1;
        }

        public new event EventHandler<PartParentChangeEventArgs> ParentChanged;
        public event EventHandler<PartEventArgs> LoadPart;
        public event EventHandler<ModifyPartEventArgs> SaveChanges;
        public event EventHandler<RemovePartEventArgs> Remove;
        public event EventHandler<PartEventArgs> AddChild;
        public event EventHandler<PartEventArgs> RemoveChild;

        public int ParentID
        {
            get
            {
                if (_ParentID != -1)
                    return _ParentID;

                if (PartParent != null)
                {
                    return PartParent.ID;
                }
                else
                    return -1;
            }

            set
            {
                _ParentID = value;

                var part = _Repository.Get(value);
                this.ParentNameTxt.Text = part == null ? "" : part.Name;
                this.ParentDescriptionTxt.Text = part == null ? "" : part.Description;
            }
        }
        private int _ParentID = -1;

        public int BoxCount
        {
            get { return Convert.ToInt32(BoxCountTxt.Text); }
            set { BoxCountTxt.Text = value.ToString(); }
        }

        public string PackageType
        {
            get
            {
                return (string)BoxTypeCb.SelectedItem;
            }
            
            set
            {
                BoxTypeCb.SelectedItem = value;
            }
        }

        public string BoxingDirections
        {
            get { return PackInstructionsTxt.Text; }
            set { PackInstructionsTxt.Text = value; }
        }

        public Part Model
        {
            get
            {
                return _Part;
            }

            set
            {
                throw new NotSupportedException("Setting the model is not supported. Use LoadPart instead.");
            }
        }
        
        public int PartID
        {
            get { return Convert.ToInt32(PartIDTxt.Text); }
            set { this.PartIDTxt.Text = value.ToString(); }
        }

        public string PartName
        {
            get { return PartNameTxt.Text; }
            set { PartNameTxt.Text = value; }
        }

        public string PartDescription
        {
            get { return DescriptionTxt.Text; }
            set { DescriptionTxt.Text = value; }
        }

        public Part[] PartChildren
        {
            get { return _Children.ToArray(); }
            set
            {
                _Children = new List<Part>(value);
                this.UpdateChildView();
            }
        }

        public PartDetailsPresenter Presenter { get => _Presenter; set => _Presenter = value; }

        private void SetParent(int parentID)
        {
            var part = _Repository.Get(parentID);
            var args = new PartParentChangeEventArgs(_Part, part);

            if (ParentChanged != null)
                ParentChanged(this, args);
        }

        private void UpdateChildView()
        {
            this.ChildrenView.Items.Clear();

            foreach (var child in this._Children)
            {
                this.ChildrenView.Items.Add(new ListViewItem(new string[]
                {
                    child.ID.ToString(),
                    child.Name,
                    child.Description,
                    "Child"
                }));
            }
        }

        private void ChildrenRemoveAllBtn_Click(object sender, EventArgs e)
        {
            foreach (var child in this._Children)
            {
                if (this.RemoveChild != null)
                    this.RemoveChild(this, new PartEventArgs(child));
            }

            UpdateChildView();
        }

        private void ChildrenRemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            if (ChildrenView.SelectedItems.Count > 0)
            {
                var selected = ChildrenView.SelectedItems;
                foreach (ListViewItem item in selected)
                {
                    Part part = _Children.First(p => p.Name == item.SubItems[1].Text);

                    if (this.RemoveChild != null)
                        this.RemoveChild(this, new PartEventArgs(part));
                }

                UpdateChildView();
            }
        }

        private void ChildrenAddBtn_Click(object sender, EventArgs e)
        {
            PartGetForm getForm = new PartGetForm(_Repository);
            getForm.MultiSelect = true;

            DialogResult result = getForm.ShowDialog();

            if (result == DialogResult.OK && getForm != null)
            {
                foreach (var child in getForm.Value)
                {
                    if (child == PartParent)
                    {
                        ShowErrorMessage(new ArgumentException("A part cannot be a parent, and a child of the same entity."));
                        continue;
                    }

                    if (child.Parent != null)
                    {
                        ShowErrorMessage(new ArgumentException("This child already has a parent. Clear it before trying to set its parent."));
                        return;
                    }

                    if (this.AddChild != null)
                        this.AddChild(this, new PartEventArgs(child));
                }

                UpdateChildView();
            }
        }

        private void ParentClearBtn_Click(object sender, EventArgs e)
        {
            ParentID = -1;
        }

        private void ParentSetBtn_Click(object sender, EventArgs e)
        {
            PartGetForm getForm = new PartGetForm(_Repository);
            DialogResult result = getForm.ShowDialog();

            if (result == DialogResult.OK && getForm.Value != null)
            {
                ParentID = getForm.Value[0].ID;
                SetParent(ParentID);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (this.SaveChanges != null)
                this.SaveChanges(this, new ModifyPartEventArgs(-1, _Part));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public void UpdateView()
        {
            this.Refresh();
        }
    }
}
