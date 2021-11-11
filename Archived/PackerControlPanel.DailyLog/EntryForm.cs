using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.DailyLog
{
    public partial class EntryForm : Form
    {
        private List<ActivityLog> Logs;

        private ActivityLog Log;
        private bool EditingEntry = false;

        public EntryForm(List<ActivityLog> logs, ActivityLog log)
            : this(logs)
        {
            this.EditingEntry = true;

            this.Log = log;

            this.title.Text = "Edit log. " + log.Date.ToString("dd-MM-yyyy");
            this.checkedPans.Text = log.CheckedPans.ToString();
            this.redTaggedPans.Text = log.RedTaggedPans.ToString();
            this.unCheckedPans.Text = log.UnCheckedPans.ToString();
            this.secondOPPans.Text = log.SecondOPPans.ToString();
            this.remarks.Text = log.Remarks;
        }

        public EntryForm(List<ActivityLog> logs)
        {
            InitializeComponent();

            this.Logs = logs;
            this.dateTimePicker1.Value = DateTime.Now;

            this.checkedPans.LostFocus += TextBox_LostFocus;
            this.redTaggedPans.LostFocus += TextBox_LostFocus;
            this.unCheckedPans.LostFocus += TextBox_LostFocus;
            this.secondOPPans.LostFocus += TextBox_LostFocus;

            this.Log = new ActivityLog();
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
                return;

            int value = 0;
            bool result = int.TryParse(textBox.Text, out value);

            if (!result)
            {
                MessageBox.Show("Failed to convert string to Int32. Please only use numbers.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.Text = "";
            }
        }

        /// <summary>
        /// Save click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Log.ID = Logs.Count() + 1;
            Log.Date = dateTimePicker1.Value;
            Log.CheckedPans = Int32.Parse(this.checkedPans.Text);
            Log.UnCheckedPans = Int32.Parse(this.unCheckedPans.Text);
            Log.RedTaggedPans = Int32.Parse(this.redTaggedPans.Text);
            Log.SecondOPPans = Int32.Parse(this.secondOPPans.Text);
            Log.Remarks = this.remarks.Text;

            if (this.EditingEntry)
                this.Logs[this.Logs.IndexOf(this.Logs.FirstOrDefault(i => i.ID == Log.ID))] = Log;
            else
                this.Logs.Add(Log);

            this.Close();
        }

        /// <summary>
        /// Close click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
