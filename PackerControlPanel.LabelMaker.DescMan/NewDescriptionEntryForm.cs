using System;
using System.Linq;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using PackerControlPanel.Image.Views;

namespace PackerControlPanel.Image.Forms
{
    public class NewDescriptionEntryForm : Form, INewDescriptionEntryView
    {
        private static bool instanceExists = false;
        private bool initializeCalled = false;
        private TextBox nameBox;
        private TextBox descBox;

        public event CanExecuteEventHandler Accept;
        public event EventHandler Cancel;

        public NewDescriptionEntryForm(string partName = "")
        {
            if (instanceExists)
            {
                throw new ArgumentException("Only one instance allowed at once.");
            }
            else
            {
                instanceExists = true;
            }

            InitializeContent();
            PartName = partName;

            this.Height = 180;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Closing += FormIsClosing;
        }

        public bool AllowEdit
        {
            get
            {
                return nameBox.ReadOnly;
            }

            set
            {
                nameBox.ReadOnly = value;
            }
        }

        public string PartName
        {
            get
            {
                if (!initializeCalled)
                    throw new InvalidOperationException("Initialize must be called first.");

                return nameBox.Text;
            }

            set
            {
                if (!initializeCalled)
                    throw new InvalidOperationException("Initialize must be called first.");

                nameBox.Text = value;
            }
        }

        public string Description
        {
            get
            {
                if (!initializeCalled)
                    throw new InvalidOperationException("Initialize must be called first.");

                return descBox.Text;
            }

            set
            {
                if (!initializeCalled)
                    throw new InvalidOperationException("Initialize must be called first.");


                descBox.Text = value;
            }
        }

        public PartDescInfo GetValue
        {
            get { return new PartDescInfo(PartName, Description); }
        }

        public PartDescInfo Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void InitializeContent()
        {
            initializeCalled = true;

            System.Windows.Forms.Label nameLbl = new System.Windows.Forms.Label();
            nameLbl.Text = "Part Name:";
            nameLbl.Width = 70;
            nameLbl.Location = new Point(20, 20);
            this.Controls.Add(nameLbl);

            nameBox = new TextBox();
            nameBox.Location = new Point(nameLbl.Location.X + nameLbl.Width + 20, 20);
            nameBox.Width = 150;
            nameBox.ReadOnly = true;
            this.Controls.Add(nameBox);

            System.Windows.Forms.Label descLabel = new System.Windows.Forms.Label();
            descLabel.Text = "Description:";
            descLabel.Width = 70;
            descLabel.Location = new Point(nameLbl.Location.X, nameLbl.Location.Y + nameLbl.Height + 20);
            this.Controls.Add(descLabel);

            descBox = new TextBox();
            descBox.Location = new Point(descLabel.Location.X + descLabel.Width + 20, descLabel.Location.Y);
            descBox.Width = 150;
            this.Controls.Add(descBox);

            Button acceptBtn = new Button();
            acceptBtn.Click += AcceptBtn_Click;
            acceptBtn.Size = new Size(70, 30);
            acceptBtn.Location = new Point(20, descBox.Location.Y + descBox.Height + 20);
            acceptBtn.Text = "Accept";
            this.Controls.Add(acceptBtn);

            Button cancelBtn = new Button();
            cancelBtn.Click += CancelBtn_Click;
            cancelBtn.Size = new Size(70, 30);
            cancelBtn.Location = new Point(acceptBtn.Location.X + acceptBtn.Width + 10, acceptBtn.Location.Y);
            cancelBtn.Text = "Cancel";
            this.Controls.Add(cancelBtn);
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (this.Accept != null)
            {
                CanExecuteEventArgs ev = new CanExecuteEventArgs();
                this.Accept(this, ev);

                if (!ev.CanExecute)
                    ShowErrorMessage(new ArgumentException(ev.ErrorMsg));
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (this.Cancel != null)
            {
                this.Cancel(this, e);
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormIsClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instanceExists = false;
        }

        public void ShowErrorMessage(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}