using PackerControlPanel.Core.Domain;
using PackerControlPanel.Image;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.UI.Forms
{
    using PackerControlPanel.Core;
    using PackerControlPanel.Core.Repository;
    using PackerControlPanel.Data;
    using PackerControlPanel.Image.Helpers;
    using PackerControlPanel.UI.Forms;
    using System.Drawing.Printing;

    public partial class ConfirmationForm : Form
    {
        private bool Offline = false;
        private PackerUnitOfWork _Inventory;
        private IReceiverRepository _Receivers;
        private LabelFactoryWin _Owner;

        private Receiver _SelectedReceiver;
        private ILabelOrder[] _Orders;

        public ConfirmationForm(PackerUnitOfWork inventory, LabelFactoryWin win, ILabelOrder[] orders)
        {
            InitializeComponent();

            this._Owner = win;

            this._Orders = orders;

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterOptions.Items.Add(printer);
            }

            if (inventory != null)
            {
                this._Receivers = inventory.Receivers;

                foreach (var receiver in _Receivers.GetReceivers(ReceiverStateType.InProgress))
                {
                    ActiveReceivers.Items.Add(receiver.Name == null ? "No name" : receiver.Name);
                }
            }

            this._Inventory = inventory;
        }

        public ConfirmationForm(LabelFactoryWin win, ILabelOrder[] orders)
            : this(null, win, orders)
        {
            this.Offline = true;
            this.ReceiveCb.Enabled = !this.Offline;
        }

        public LabelFactoryActionHandler CreateHandler()
        {
            LabelFactoryActionHandler handler = new LabelFactoryActionHandler();

            if (ReceiveCb.Checked && !Offline)
            {
                LabelFactoryActionReceive receive
                    = new LabelFactoryActionReceive(_Inventory, _SelectedReceiver);
                handler.Actions.Add(receive);
            }

            if (PrintCb.Checked)
            {
                LabelFactoryActionPrint print
                    = new LabelFactoryActionPrint(this._Owner.Presenter.Drawing, new StandardPrintController());
                handler.Actions.Add(print);
            }

            return handler;
        }

        private void SetReceiver(Receiver receiver)
        {
            if (Offline)
                return;

            this._SelectedReceiver = receiver;
            this.ReceiverNameTxt.Text = receiver.Name;
        }

        private void Cb_CheckChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;

            if (box.Name == "PrintCb")
            {
                PrintBox.Enabled = box.Checked;
            }
            else if (box.Name == "ReceiveCb")
            {
                ReceiveBox.Enabled = box.Checked;
            }
        }

        private void ReceiverChooseBtn_Click(object sender, EventArgs e)
        {
            if (Offline)
                return;

            //ReceiverGet get = new ReceiverGet(_Receivers);
        }

        private void ActiveReceiver_SelectionChanged(object sender, EventArgs e)
        {
            if (Offline)
                return;

            var selectedName = ActiveReceivers.GetItemText(this.ActiveReceivers.SelectedItem);


            SetReceiver(_Receivers.Get(selectedName));
            ReceiverNameTxt.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
