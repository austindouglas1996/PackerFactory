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

namespace PackerControlPanel.RPCP.Forms
{
    using PackerControlPanel.Core;
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Data;
    using PackerControlPanel.Data.Common;
    using PackerControlPanel.Image;
    using PackerControlPanel.Image.Drawings;
    using System.Drawing.Printing;
    using PackerControlPanel.RPCP.Controls;
    using System.Diagnostics;

    public partial class ReceivingWin : Form
    {
        /// <summary>
        /// Manages our db and model data.
        /// </summary>
        private PackerUnitOfWork _Inventory;

        /// <summary>
        /// Manages the creation of all labels.
        /// </summary>
        private LabelFactoryProcessor<LabelOrder> _Processor;

        /// <summary>
        /// Manages the program settings.
        /// </summary>
        private Settings _Settings = Program.Settings;

        /// <summary>
        /// Gets or sets the windows active receiver document.
        /// </summary>
        private Receiver ActiveReceiver
        {
            get { return _ActiveReceiver; }
            set
            {
                _ActiveReceiver = value;
                ReceiverChanged();
            }
        }
        private Receiver _ActiveReceiver;

        /// <summary>
        /// Allow the user to edit the receiver?
        /// </summary>
        private bool EnableEditing
        {
            get
            {
                if (this.ActiveReceiver != null)
                {
                    return (this.ActiveReceiver.State != ReceiverStateType.Received);
                }

                return true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivingWin"/> class.
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="descRepository"></param>
        public ReceivingWin(PackerUnitOfWork worker)
        {
            // Get inventory setup.
            this._Inventory = worker;

            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            this.NewEntryController = new ReceiverNewEntryControl(this._Inventory);
            this.NewEntryController.Location = new Point(11, 22);
            this.NewEntryController.Action += NewEntryController_Action;
            this.ReceiverEntryGroup.Controls.Add(this.NewEntryController);

            this.ActiveReceiver = null;
        }

        private void ReceiverChanged()
        {
            bool receiverNull = this.ActiveReceiver == null;

            if (!receiverNull)
            {
                ReceiverNameTb.Text = this.ActiveReceiver.Name;
                CreationDateTb.Text = this.ActiveReceiver.CreationTime.ToShortDateString();

                listView1.Enabled = EnableEditing;

                // Always allow the name to change.
                ReceiverOptionsGroup.Enabled = true;
                ReceiverEntryGroup.Enabled = EnableEditing;

                // Allow user to complete.
                ReceiverCompleteBtn.Enabled = EnableEditing;

                // Menu strips.
                MsEditLocation.Enabled = EnableEditing;
                MsDeleteItem.Enabled = EnableEditing;
            }
            else
            {
                ReceiverNameTb.Text = "";
                CreationDateTb.Text = "";

                ReceiverOptionsGroup.Enabled = false;
                ReceiverEntryGroup.Enabled = false;
            }

            listView1.Enabled = !receiverNull;
            MsReceiverClose.Enabled = !receiverNull;
            MsReceiverDelete.Enabled = !receiverNull;
            MsReceiverExtract.Enabled = !receiverNull;

            this.RefreshItems();
        }

        private void RefreshItems()
        {
            this.listView1.Items.Clear();
            if (this.ActiveReceiver != null)
            {
                foreach (var entry in this.ActiveReceiver.Entries)
                {
                    ListViewItem item = new ListViewItem(
                        new[]
                        {
                            entry.Part.Name,
                            entry.Job.Name,
                            entry.Boxes.ToString(),
                            entry.BoxCount.ToString(),
                            entry.Location
                        });

                    item.Tag = entry;
                    this.listView1.Items.Add(item);
                }
            }
        }

        private void OnReceiver_CreateNew(object sender, EventArgs e)
        {
            if (this.ActiveReceiver != null)
            {
                DialogResult result = MessageBox.Show("A receiver is already loaded. Would you like to create a new one?", "Create new?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            // Close current receiver.
            OnReceiver_Close(this, e);

            Receiver r = new Receiver();
            r.Name = DateTime.Now.ToShortDateString();
            this._Inventory.Receivers.Add(r);

            // Set new receiver.
            this.ActiveReceiver = r;
        }

        private void OnReceiver_Load(object sender, EventArgs e)
        {
            var selector = new ReceiverBrowserSelecter(_Inventory.Receivers);
            selector.Location = this.Location;
            DialogResult result = selector.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.ActiveReceiver = selector.SelectedValue;
            }
        }

        private void OnReceiver_Close(object sender, EventArgs e)
        {
            this.ActiveReceiver = null;
        }

        private void OnReceiver_Extract(object sender, EventArgs e)
        {
            ReceiverExporterSelector select = new ReceiverExporterSelector(this.ActiveReceiver);
            select.ShowDialog();
        }

        private void OnReceiver_Save(object sender, EventArgs e)
        {
            this.ActiveReceiver.Name = ReceiverNameTb.Text;
            this._Inventory.Receivers.Edit(this.ActiveReceiver);
            this._Inventory.Complete();
        }

        private void OnReceiver_Delete(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                ("Are you sure you want to delete this receiver?", "Delete receiver", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            _Inventory.Receivers.Remove(this.ActiveReceiver);
            _Inventory.Complete();

            this.ActiveReceiver = null;
        }

        private void NewEntryController_Action(object sender, ActionEventArgs e)
        {
            try
            {
                LabelFactoryActionHandler handler = new LabelFactoryActionHandler();

                if (_Settings.OfflineNoDb && this._Processor == null)
                {
                    this._Processor = new LabelFactoryProcessorDefaultOffline(this.NewEntryController, new LabelOrderBuilder<LabelOrder>());
                }
                else
                {
                    this._Processor = new LabelFactoryProcessorDefault(this.NewEntryController, new LabelOrderBuilder<LabelOrder>());
                }

                // Add a print action if we're printing labels.
                if (_Settings.PrintEntries)
                {
                    LabelFactoryActionPrint print = new LabelFactoryActionPrint(new DefaultLabelDrawing(), new StandardPrintController());
                    handler.Actions.Add(print);
                }

                // Add a receive action.
                LabelFactoryActionReceive receive = new LabelFactoryActionReceive(this._Inventory, ActiveReceiver);
                handler.Actions.Add(receive);

                handler.Execute(_Processor.Execute());

                _Inventory.Complete();
                this.NewEntryController.Reset();

                this.RefreshItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnEntry_View(object sender, EventArgs e)
        {
            ReceiverEntry entry = (ReceiverEntry)GetSelectedItems[0].Tag;

            ViewItemForm viewItem = new ViewItemForm(_Inventory.ReceiverEntries,entry);
            viewItem.Location = this.Location;
            viewItem.ShowDialog();
        }

        private void OnEntry_SetLocation(object sender, EventArgs e)
        {
            EditLocationForm loc = new EditLocationForm();
            loc.Location = this.Location;
            DialogResult result = loc.ShowDialog();

            if (result != DialogResult.OK)
                return;

            foreach (var items in GetSelectedItems)
            {
                ReceiverEntry tag = (ReceiverEntry)items.Tag;

                tag.Location = loc.StoredLocation;

                if (loc.SetAll)
                {
                    foreach (var order in this.ActiveReceiver.Entries.Where(r => r.Job == tag.Job && r.ID != tag.ID))
                    {
                        order.Location = loc.StoredLocation;
                    }
                }
            }

            this.RefreshItems();
            this._Inventory.Complete();
        }

        private void OnEntry_Delete(object sender, EventArgs e)
        {
            foreach (var items in GetSelectedItems)
            {
                ReceiverEntry tag = (ReceiverEntry)items.Tag;

                this._Inventory.ReceiverEntries.Remove(tag);

                listView1.Items.Remove(items);
            }

            this.RefreshItems();
            this._Inventory.Complete();
        }

        private void ListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    // Only allow one item be viewed at a time.
                    MsViewItem.Enabled = (GetSelectedItems.Count() == 1);
                    
                    ItemMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private List<ListViewItem> GetSelectedItems
        {
            get
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (var i in listView1.SelectedItems)
                {
                    items.Add((ListViewItem)i);
                }

                return items;
            }
        }

        private void Reciever_CompleteClick(object sender, EventArgs e)
        {
            if (this.ActiveReceiver.State == ReceiverStateType.Received)
                return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to set this receiver as complete? This cannot be undone. Setting a receiver as complete means, no entries " +
                "can be added, edited, or removed. This will place the receiver in an archived state of read access only. Are you sure you're " +
                "done with this receiver?",
                "Set receiver as complete warning.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            // Set completed state.
            this.ActiveReceiver.State = ReceiverStateType.Received;

            foreach (var entry in this.ActiveReceiver.Entries)
            {
                this._Inventory.TransfersEntries.Add(new TransferEntry(entry));
            }

            this._Inventory.Complete();

            this.ReceiverChanged();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiverEntry entry = (ReceiverEntry)GetSelectedItems[0].Tag;

            NoteViewerForm note = new NoteViewerForm(entry);
            note.ShowDialog();

            _Inventory.Complete();
        }
    }
}
