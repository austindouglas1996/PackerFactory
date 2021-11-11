
using PackerControlPanel.InventoryWin.Forms;
using PackerControlPanel.InventoryWin.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin
{
    public partial class InventoryForm : Form
    {
        private InventoryManager _inventory;

        public InventoryForm()
        {
            InitializeComponent();

            _inventory = new InventoryManager();
            _inventory.CreateConnection("ReceivingPackerDb");

            this.ConnectionStatus.Text = "Connected.";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PartCollectionViewer v = new PartCollectionViewer(_inventory.Worker.Parts);
            v.ShowDialog();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PartCreator creator = new PartCreator(_inventory.Worker.Parts);
            creator.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JobsCollectionViewer viewer = new JobsCollectionViewer(_inventory.Worker.Parts, _inventory.Worker.Jobs);
            viewer.ShowDialog();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JobCreator creator = new JobCreator(_inventory.Worker.Jobs, _inventory.Worker.Parts);
            creator.ShowDialog();
        }
    }
}
