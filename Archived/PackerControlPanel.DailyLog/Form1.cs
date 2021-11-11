using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PackerControlPanel.DailyLog
{
    public partial class Form1 : Form
    {
        private string SettingsPath = "DailyLogs.XML";
        private List<ActivityLog> Logs = new List<ActivityLog>();

        public Form1(string[] args)
        {
            if (args.Count() > 0)
            {
                string settingsPath = args[0];
                if (!Directory.Exists(settingsPath))
                    MessageBox.Show(string.Format("Settings path '{0}' is invalid.", settingsPath), "ERROR SETTING SETTINGS PATH.");

                this.SettingsPath = settingsPath + "DailyLogs.XML";
            }

            InitializeComponent();

            // Get the logs.
            this.Logs = LoadLogs();

            // Setup the listbox.
            this.listView1.Columns.Add("ID", 50);
            this.listView1.Columns.Add("Date", 100);
            this.listView1.Columns.Add("Checked Pans.", 110);
            this.listView1.Columns.Add("UnChecked Pans.", 110);
            this.listView1.Columns.Add("Rejected Pans.", 110);
            this.listView1.Columns.Add("Require 2ND Op Pans.", 150);
            this.listView1.Columns.Add("Remarks.", 250);

            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.View = View.Details;

            // Populate.
            PopulateListView();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveLogToFile();
            base.OnClosing(e);
        }

        private void PopulateListView()
        {
            // Remove any existing items.
            this.listView1.Items.Clear();

            for (int i = 0; i < Logs.Count; i++)
            {
                var log = Logs[i];

                this.listView1.Items.Add(new ListViewItem(
                 new string[] 
                 {
                    log.ID.ToString(),
                    log.Date.ToShortDateString(),
                    log.CheckedPans.ToString(),
                    log.UnCheckedPans.ToString(),
                    log.RedTaggedPans.ToString(),
                    log.SecondOPPans.ToString(),
                    log.Remarks
                 }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntryForm entryForm = new EntryForm(this.Logs);
            entryForm.ShowDialog();

            PopulateListView();
            SaveLogToFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    // Get entry.
                    var selectedEntry = Logs.First(l => l.ID == Int32.Parse(selectedItem.Text));

                    Logs.Remove(selectedEntry);

                    // Re-populate.
                    PopulateListView();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                var selectedEntry = Logs.First(l => l.ID == Int32.Parse(selectedItem.Text));

                // Edit the entry.
                EntryForm entryForm = new EntryForm(this.Logs, selectedEntry);
                entryForm.ShowDialog();

                PopulateListView();
            }
        }

        private List<ActivityLog> LoadLogs()
        {
            if (!File.Exists(SettingsPath))
            {
                Logs = new List<ActivityLog>();
                return Logs;
            }

            XmlSerializer serializer = new XmlSerializer(Logs.GetType());
            using (var fs = new FileStream("DailyLogs.XML", FileMode.Open))
            {
                return (List<ActivityLog>)serializer.Deserialize(fs);
            }
        }

        private void SaveLogToFile()
        {
            XmlSerializer serializer = new XmlSerializer(Logs.GetType());
            using (var ws = new StreamWriter(SettingsPath))
            {
                serializer.Serialize(ws, this.Logs);
            }
        }
    }
}
