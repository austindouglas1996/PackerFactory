using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Common;
using PackerControlPanel.Image.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.RPCP.Forms
{
    public partial class SkidLabelMakerForm : Form
    {
        PackerUnitOfWork _Worker;

        public SkidLabelMakerForm(PackerUnitOfWork worker)
        {
            InitializeComponent();
            _Worker = worker;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Part part = _Worker.Parts.Get(textBox1.Text);
            Job job = _Worker.Jobs.Get(textBox2.Text);
            int[] boxes = null;
            int[] boxCounts = null;

            if (part == null)
            {
                MessageBox.Show("Unable to find that part.");
                return;
            }
            else if (job == null)
            {
                MessageBox.Show("Unable to find that job.");
                return;
            }

            if (job.Part != part)
            {
                MessageBox.Show("Part does not belong to that job. Unable to create label.");
                return;
            }

            try
            {
                boxes = StringToIntArray(textBox3.Text);
                boxCounts = StringToIntArray(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Failed to valiate boxes and boxcount. Make sure values are spaced properly.");
            }     

            Skid newSkid = new Skid();
            newSkid.Part = part;
            newSkid.Job = job;
            newSkid.Boxes = boxes;
            newSkid.BoxCounts = boxCounts;

            SkidExporterHtml html = new SkidExporterHtml("./Skids/");
            string path = html.Export(newSkid);

            Process.Start(path);

           // _Worker.Skids.Add(newSkid);
            _Worker.Complete();

            this.Reset();
        }

        private void Reset()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
        }

        private int[] StringToIntArray(string str)
        {
            List<int> values = new List<int>();
            foreach (string val in str.Split(','))
            {
                try
                {
                    values.Add(Convert.ToInt32(val));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return values.ToArray();
        }
    }
}
