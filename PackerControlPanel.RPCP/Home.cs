using PackerControlPanel.Data;
using PackerControlPanel.RPCP.Forms;
using PackerControlPanel.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.RPCP
{
    public partial class Home : Form
    {
        private PackerUnitOfWork _Worker;

        public Home(PackerUnitOfWork worker)
        {
            InitializeComponent();
            _Worker = worker;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReceivingWin win = new ReceivingWin(_Worker);

            this.Visible = false;

            win.ShowDialog();


            this.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TransferWin win = new TransferWin(_Worker);

            this.Visible = false;

            win.ShowDialog();


            this.Visible = true;
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SkidLabelMakerForm win = new SkidLabelMakerForm(_Worker);
            this.Visible = false;
            win.ShowDialog();
            this.Visible = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PartBrowserSelector win = new PartBrowserSelector(_Worker);
            this.Visible = false;
            win.ShowDialog();
            this.Visible = true;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowForm(new JobBrowserSelector(_Worker));
        }

        private void ShowForm(Form f)
        {
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }
    }
}
