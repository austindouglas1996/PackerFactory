using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
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
    public partial class HomePanel : Form
    {
        private InventoryManager _InventoryMan;

        public HomePanel()
        {
            InitializeComponent();

            // Create connection.
            this._InventoryMan = new InventoryManager();
            this._InventoryMan.CreateConnection("ReceivingPackerDb");
        }

        internal InventoryManager InventoryManager
        {
            get { return this._InventoryMan; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pForm = new PartViewerForm(InventoryManager.Worker.Parts);
            pForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pForm = new JobViewerForm(InventoryManager.Worker.Jobs);
            pForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var pForm = new ReceiverManagerForm(InventoryManager);
            pForm.ShowDialog();
        }
    }
}
