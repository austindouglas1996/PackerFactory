using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
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
    public partial class NewPartForm : Form
    {
        private PackerUnitOfWork Worker;

        public NewPartForm(PackerUnitOfWork worker, string partName = "")
        {
            this.Worker = worker;
            InitializeComponent();

            this.BoxTypeCb.Items.AddRange(PackageInfo.BoxTypes);

            this.PartNameTb.Text = partName;
        }

        public Part NewPart { get; set; }

        private void OnPartFocusLost(object sender, EventArgs e)
        {
            if (PartNameTb.Text != "" || PartNameTb.Text != " ")
            {
                if (Worker.Parts.Get(PartNameTb.Text) != null)
                {
                    MessageBox.Show("Error. Sorry, that part already exists. Please choose a different name.");
                }
            }
        }

        private void OnSubmitClick(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "")
            {
                EmptyText("Part Name");
                return;
            }
            if (BoxCountTb.Text == "")
            {
                EmptyText("Box Count");
                return;
            }
            if (BoxTypeCb.Text == "")
            {
                EmptyText("BoxType; Wait? How did you do that :|");
                return;
            }

            int val = -1;
            bool tried = Int32.TryParse(BoxCountTb.Text, out val);

            if (!tried)
            {
                MessageBox.Show("Oops! BoxCount must have an integer value.");
                return;
            }

            NewPart = new Part(PartNameTb.Text, val, "Deprecated", BoxTypeCb.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EmptyText(string name)
        {
            MessageBox.Show("Oops! Looks like you left a box empty. Please make sure you fill out box: " + name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
