using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Forms;
using PackerControlPanel.Image.Presenters;
using PackerControlPanel.Image.Views;
using PackerControlPanel.Image.Repository;
using System.Drawing;
using System.Reflection;
using System.Linq;
using PackerControlPanel.Data.Common;
using PackerControlPanel.Data.Presenters;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data.Views;

namespace PackerControlPanel.Image.Forms
{
    public class DescriptionManForm : Form, IDescriptionManView
    {
        private ListView _List;
        private TextBox _PartTb;
        private TextBox _DescTb;
        private TextBox _SelectedPartTb;
        private TextBox _SelectedDescTb;

        private List<PartDescInfo> _Descriptions;
        private DescriptionManPresenter _presenter;

        public DescriptionManForm(IPartDescRepository repository)
        {
            this.Width = 760;
            this.Height = 800;

            this.InitializeContent();
            _presenter = new DescriptionManPresenter(this, repository);
        }

        public event AddPartDescEventHandler AddPart;
        public event RemovePartDescEventHandler RemovePart;
        public event ModifyPartDescEventHandler EditPart;

        public DescriptionManPresenter Presenter
        {
            get { return _presenter; }
        }

        public List<PartDescInfo> Descriptions
        {
            get { return _Descriptions; }
            set
            {
                this._Descriptions = value;
                this.UpdateView();
            }
        }

        public PartDescInfo SelectedItem
        {
            get; set;
        }

        private PartDescInfo GetSelectedItem
        {
            get
            {
                if (_List.SelectedItems.Count > 0)
                {
                    ListViewItem item = _List.SelectedItems[0];
                    if (item != null)
                    {
                        PartDescInfo part = _Descriptions.FirstOrDefault(p => p.PartName == item.SubItems[0].Text);
                        if (part == null)
                            ShowErrorMessage(new ArgumentNullException("Failed to find that part."));

                        return part;
                    }
                }

                return null;
            }
        }

        public List<PartDescInfo> Model
        {
            get { return _Descriptions; }
            set { _Descriptions = value; }
        }

        public void UpdateView()
        {
            _List.Items.Clear();

            foreach (var item in _Descriptions)
            {
                this.AddItem(item.PartName, item.FormalDescription);
            }
        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message, e.GetType().Name);
        }

        protected virtual void InitializeContent()
        {
            _List = new ListView();
            _List.Width = 400;
            _List.Height = 700;
            _List.Location = new Point(20, 50);
            _List.View = View.Details;
            _List.GridLines = true;
            _List.FullRowSelect = true;
            _List.MultiSelect = true;
            _List.ItemSelectionChanged += (obj, e) =>
            {
                PartDescInfo selected = GetSelectedItem;
                if (selected != null)
                {
                    _SelectedPartTb.Text = selected.PartName;
                    _SelectedDescTb.Text = selected.FormalDescription;
                    SelectedItem = selected;
                }
            };
            _List.Columns.Add("Part Name", -2);
            _List.Columns.Add("Part Description", -2);

            GroupBox box = new GroupBox();
            box.Width = 300;
            box.Height = 140;
            box.Location = new Point(430, 50);
            box.Text = "Add a new entry.";

            System.Windows.Forms.Label partlbl = new System.Windows.Forms.Label();
            partlbl.Text = "Part Name:";
            partlbl.Location = Point.Add(partlbl.Location, new Size(10, 30));
            box.Controls.Add(partlbl);

            _PartTb = new TextBox();
            _PartTb.Width = 150;
            _PartTb.Location = Point.Add(partlbl.Location, new Size(partlbl.Width, 0));
            box.Controls.Add(_PartTb);

            System.Windows.Forms.Label descLbl = new System.Windows.Forms.Label();
            descLbl.Text = "Description:";
            descLbl.Location = Point.Add(partlbl.Location, new Size(0, partlbl.Height + 10));
            box.Controls.Add(descLbl);

            _DescTb = new TextBox();
            _DescTb.Width = 150;
            _DescTb.Location = Point.Add(descLbl.Location, new Size(descLbl.Width, 0));
            box.Controls.Add(_DescTb);

            Button acceptBtn = new Button();
            acceptBtn.Location = Point.Add(descLbl.Location, new Size(0, descLbl.Height + 10));
            acceptBtn.Text = "Add";
            acceptBtn.Click += (obj, e) => OnAddPart();
            box.Controls.Add(acceptBtn);

            GroupBox box1 = new GroupBox();
            box1.Text = "Currently selected entry.";
            box1.Width = box.Width;
            box1.Height = box.Height;
            box1.Location = Point.Add(box.Location, new Size(0, box.Height + 20));

            System.Windows.Forms.Label partLbl1 = new System.Windows.Forms.Label()
            {
                Text = "PartInfo Name:",
                Location = new Point(10, 30)
            };
            box1.Controls.Add(partLbl1);

            _SelectedPartTb = new TextBox()
            {
                Width = 150,
                Location = Point.Add(partLbl1.Location, new Size(partLbl1.Width, 0)),
                ReadOnly = true
            };
            box1.Controls.Add(_SelectedPartTb);

            System.Windows.Forms.Label partDescLbl1 = new System.Windows.Forms.Label()
            {
                Text = "Description:",
                Location = new Point(partLbl1.Location.X, partLbl1.Location.Y + partLbl1.Height + 10)
            };
            box1.Controls.Add(partDescLbl1);

            _SelectedDescTb = new TextBox()
            {
                Width = 150,
                Location = Point.Add(partDescLbl1.Location, new Size(partDescLbl1.Width, 0)),
                ReadOnly = true
            };
            box1.Controls.Add(_SelectedDescTb);

            Button editBtn = new Button();
            editBtn.Location = Point.Add(partDescLbl1.Location, new Size(0, partDescLbl1.Height + 10));
            editBtn.Text = "Edit";
            editBtn.Click += (obj, e) => OnEditPart();
            box1.Controls.Add(editBtn);

            Button removeBtn = new Button();
            removeBtn.Location = Point.Add(editBtn.Location, new Size(editBtn.Width + 10, 0));
            removeBtn.Text = "Remove";
            removeBtn.Click += (obj, e) => OnRemovePart();
            box1.Controls.Add(removeBtn);

            this.Controls.Add(_List);
            this.Controls.Add(box);
            this.Controls.Add(box1);
        }

        private void OnAddPart()
        {
            if (String.IsNullOrEmpty(_PartTb.Text))
            {
                ShowErrorMessage(new ArgumentNullException("PartInfo name cannot be empty."));
                return;
            }

            var addEvent = new AddPartDescEventArgs(new PartDescInfo(_PartTb.Text, _DescTb.Text));
            NewDescriptionEntryForm entryForm = new NewDescriptionEntryForm();
            DialogResult r = entryForm.ShowDialog();

            if (r == DialogResult.OK)
            {
                if (this.AddPart != null)
                    this.AddPart(this, addEvent);
            }

            // Add item.
            this.AddItem(_PartTb.Text, _DescTb.Text);

            // Reset field.
            _PartTb.Text = "";
            _DescTb.Text = "";
        }

        private void OnRemovePart()
        {
            if (SelectedItem == null)
            {
                ShowErrorMessage(new ArgumentNullException("No part currently selected."));
                return;
            }

            if (this.RemovePart != null)
                this.RemovePart(this, new RemovePartDescEventArgs(SelectedItem));

            _Descriptions.Remove(SelectedItem);
            _List.Items[0].Selected = true;

            UpdateView();
        }

        private void OnEditPart()
        {
            int selectedIndex = -1;
            if (SelectedItem == null)
            {
                ShowErrorMessage(new ArgumentNullException("No part currently selected."));
                return;
            }

            selectedIndex = _Descriptions.IndexOf(SelectedItem);

            var edit = new ModifyPartDescEventArgs(selectedIndex, SelectedItem);

            NewDescriptionEntryForm entryForm = new NewDescriptionEntryForm(edit.PartDesc.PartName);
            DialogResult r = entryForm.ShowDialog();

            if (r == DialogResult.OK)
            {
                var newValues = entryForm.GetValue;
                edit.PartDesc.PartName = newValues.PartName;
                edit.PartDesc.FormalDescription = newValues.FormalDescription;

                if (this.EditPart != null)
                    this.EditPart(this, edit);
            }

            if (edit.Handled)
                _Descriptions[selectedIndex] = edit.PartDesc;

            UpdateView();
        }

        private void AddItem(string partName, string partDescription)
        {
            if (this._List == null)
                throw new ArgumentNullException("List is null.");

            this._List.Items.Add(new ListViewItem(new[] { partName, partDescription }));
        }
    }
}