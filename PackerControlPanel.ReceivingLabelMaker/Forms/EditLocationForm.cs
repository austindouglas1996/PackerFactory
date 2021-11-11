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
    public partial class EditLocationForm : Form
    {
        public EditLocationForm()
        {
            InitializeComponent();
        }

        public string StoredLocation
        {
            get { return LocationTb.Text; }
        }

        public bool SetAll
        {
            get { return checkBox1.Checked; }
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnAcceptClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void KeyPress_SetAll(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.checkBox1.Checked = !this.checkBox1.Checked;
            }
        }
    }
}
