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

namespace PackerControlPanel.RPCP.Forms
{
    public partial class NoteForm : Form
    {
        private Note _Note;

        public NoteForm(Note note, string title)
        {
            InitializeComponent();

            this.label1.Text = title;
            this.Text = title;

            this.SetNote(note);
        }

        public NoteForm(string title)
        {
            InitializeComponent();

            this.label1.Text = title;
            this.Text = title;

            this.SetNote(new Note());
        }

        public Note GetNote()
        {
            return new Note(textBox1.Text);
        }

        private void SetNote(Note note)
        {
            this._Note = note;
            this.textBox1.Text = note.Message;
            this.textBox2.Text = note.CreationTime.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
