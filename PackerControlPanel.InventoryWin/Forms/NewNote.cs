using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Forms
{
    public partial class NewNote : Form
    {
        private Note note;

        public NewNote()
        {
            InitializeComponent();
        }

        public Note GetNote()
        {
            return note;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.note = new Note(this.textBox1.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
