using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data.Common;
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
    public partial class ReceiverExporterSelector : Form
    {
        private Receiver r;

        public ReceiverExporterSelector(Receiver r)
        {
            InitializeComponent();

            if (r == null)
                throw new ArgumentNullException("Receiver cannot be null.");
            this.r = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export(0);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Export(1);
            this.Close();
        }

        private void Export(int style)
        {
            ReceiverExporterHtml exporter = null;

            switch (style)
            {
                case 0:
                exporter = new ReceiverExporterHtml("./Receivers/", false);
                break;
                case 1:
                exporter = new ReceiverExporterHtml("./Receivers/", true);
                break;
                default:
                    exporter = new ReceiverExporterHtml("./Receivers/", false);
                    break;
            }

            string path = exporter.Export(this.r);

            Process.Start(path);
        }
    }
}
