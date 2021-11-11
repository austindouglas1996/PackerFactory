using PackerControlPanel.Image.Forms;
using PackerControlPanel.Image.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PackerControlPanel.Image.DescMan
{
    public partial class ConfigSelector : Form
    {
        public ConfigSelector()
        {
            InitializeComponent();
        }

        public string FilePath
        {
            get { return path_tb.Text; }
            set { path_tb.Text = value; }
        }

        public bool XmlRepository
        {
            get { return Xml_Cb.Checked; }
        }

        public bool DbRepository
        {
            get { return Db_Cb.Checked; }
        }

        public string DbConnectionString
        {
            get { return dbConnectionString.Text; }
            set { dbConnectionString.Text = value; }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box == null)
                throw new ArgumentException("Sender is not a checkbox.");

            switch (box.Name)
            {
                case "Xml_Cb":
                    if (Xml_Cb.Checked)
                    {
                        Db_Cb.Checked = false;
                        dbConnectionString.Enabled = false;
                    }
                    break;
                default:
                    if (Db_Cb.Checked)
                    {
                        Xml_Cb.Checked = false;
                        dbConnectionString.Enabled = true;
                    }
                    break;
            }
        }

        private void BrowseClick(object sender, EventArgs e)
        {
            OpenFileDialog filed = new OpenFileDialog();
            filed.CheckPathExists = true;
            filed.Multiselect = false;

            DialogResult r = filed.ShowDialog();
            if (r == DialogResult.OK)
            {
                path_tb.Text = filed.FileName;
            }

            filed.Dispose();
        }

        private void AcceptClick(object sender, EventArgs e)
        {
            IPartDescRepository repository = null;

            if (XmlRepository)
            {
                repository = PartDescRepositoryList.LoadFromFile(FilePath);
            }
            else if (DbRepository)
            {
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", FilePath);

                PartDescDbContext context = new PartDescDbContext(this.DbConnectionString);
                repository = new PartDescRepositoryDb(context);
            }

            DescriptionManForm manForm = new DescriptionManForm(repository);

            this.Hide();
            manForm.ShowDialog();
            this.Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
