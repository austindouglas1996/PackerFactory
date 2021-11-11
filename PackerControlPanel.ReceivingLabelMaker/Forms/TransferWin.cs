using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
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
    public partial class TransferWin : Form
    {
        private PackerUnitOfWork _Worker;
        private Transfer ActiveTransfer;

        private bool AllowEditing
        {
            get { return ActiveTransfer.State != Core.ReceiverStateType.Received; }
        }

        public TransferWin(PackerUnitOfWork Worker)
        {
            _Worker = Worker;
            InitializeComponent();

            PoolView.ListView.Columns.Add("Part Name", 93, HorizontalAlignment.Left);
            PoolView.ListView.Columns.Add("Job Name", 102, HorizontalAlignment.Left);
            PoolView.ListView.Columns.Add("Total", 102, HorizontalAlignment.Left);
            PoolView.ListView.Columns.Add("Received Location", 127, HorizontalAlignment.Left);
            PoolView.ListView.MultiSelect = true;
            PoolView.ListView.MouseUp += PoolView_MouseUp;

            DocView.ListView.Columns.Add("Part Name", 93, HorizontalAlignment.Left);
            DocView.ListView.Columns.Add("Job Name", 102, HorizontalAlignment.Left);
            DocView.ListView.Columns.Add("Total", 102, HorizontalAlignment.Left);
            DocView.ListView.Columns.Add("Received Location", 127, HorizontalAlignment.Left);
            DocView.ListView.Columns.Add("Stored Location", 127, HorizontalAlignment.Left);
            DocView.ListView.MultiSelect = true;
            DocView.ListView.MouseUp += DocView_MouseUp;

            LoadPool();
            TransferDocumentChanged();
        }

        public void LoadPool()
        {
            if (PoolView.IsSearching)
            {
                PoolView.CancelSearch();
            }

            PoolView.ListView.Items.Clear();

            foreach (var entry in _Worker.TransfersEntries.GetOrphans())
            {
                ListViewItem item = new ListViewItem(
                    new[]
                    {
                        entry.ReceiverEntry.Part.Name,
                        entry.ReceiverEntry.Job.Name,
                        entry.ReceiverEntry.Total.ToString(),
                        entry.ReceiverEntry.Location,
                        entry.StoredLocation
                    });

                item.Tag = entry;

                PoolView.ListView.Items.Add(item);
            }
        }

        public void LoadDoc()
        {
            if (DocView.IsSearching)
            {
                // Cancel any type of search before loading the document.
                DocView.CancelSearch();
            }

            DocView.ListView.Items.Clear();

            bool transferNull = ActiveTransfer == null;

            groupBox1.Enabled = !transferNull;
            MsClose.Enabled = !transferNull;
            MsTransferDelete.Enabled = !transferNull;
            MsPoolAdd.Enabled = !transferNull;
            MsDocEdit.Enabled = !transferNull;
            MsDocRemove.Enabled = !transferNull;

            if (!transferNull)
            {
                bool Transferred = ActiveTransfer.State == ReceiverStateType.Transferred;

                MsTransferDelete.Enabled = !Transferred;
                MsPoolAdd.Enabled = !Transferred;
                MsDocEdit.Enabled = !Transferred;
                MsDocRemove.Enabled = !Transferred;
                button3.Enabled = !Transferred;

                TransferNameTb.Text = ActiveTransfer.Name;
                CreationDateTb.Text = ActiveTransfer.CreationTime.ToShortDateString();

                foreach (var entry in _Worker.TransfersEntries.Find(r => r.TransferID == ActiveTransfer.ID))
                {
                    ListViewItem item = new ListViewItem(
                        new[]
                        {
                            entry.ReceiverEntry.Part.Name,
                            entry.ReceiverEntry.Job.Name,
                            entry.ReceiverEntry.Total.ToString(),
                            entry.ReceiverEntry.Location,
                            entry.StoredLocation
                        });

                    item.Tag = entry;

                    DocView.ListView.Items.Add(item);
                }
            }
            else
            {
                TransferNameTb.Text = "";
                CreationDateTb.Text = "";
            }
        }

        protected void TransferDocumentChanged()
        {
            bool allow = ActiveTransfer == null;

            if (ActiveTransfer == null)
            {
                TransferNameTb.Text = "";
                CreationDateTb.Text = "";
            }
            else
            {
                LoadDoc();
            }

            groupBox1.Enabled = !allow;
            DocView.Enabled = !allow;
            MsPoolAdd.Enabled = !allow;
        }

        private void PoolView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = PoolView.ListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    MsPool.Show(Cursor.Position);
                }
            }
        }

        private void DocView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = DocView.ListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    bool selectedOne = GetSelectedDocItems.Count() == 1;
                    MsDocView.Enabled = selectedOne;
                        
                    MsDoc.Show(Cursor.Position);
                }
            }
        }

        private void MsCreate_Clicked(object sender, EventArgs e)
        {
            if (ActiveTransfer != null)
            {
                DialogResult result = MessageBox.Show
                    ("A transfer document is already loaded. Are you sure you want to create a new one?", "Document already loaded.", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes)
                    return;
            }

            Transfer newTrans = new Transfer(DateTime.Now.ToShortDateString());

            // Add.
            _Worker.Transfers.Add(newTrans);
            _Worker.Complete();

            // Set.
            this.ActiveTransfer = newTrans;
            this.TransferDocumentChanged();
        }

        private List<ListViewItem> GetSelectedPoolItems
        {
            get
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (var i in PoolView.ListView.SelectedItems)
                {
                    items.Add((ListViewItem)i);
                }

                return items;
            }
        }

        private List<ListViewItem> GetSelectedDocItems
        {
            get
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (var i in DocView.ListView.SelectedItems)
                {
                    items.Add((ListViewItem)i);
                }

                return items;
            }
        }

        private void MsAdd_Clicked(object sender, EventArgs e)
        {
            if (this.ActiveTransfer.State == ReceiverStateType.Transferred)
                return;

            var items = GetSelectedPoolItems;

            foreach (ListViewItem item in items)
            {
                TransferEntry entry = (TransferEntry)item.Tag;
                entry.TransferID = ActiveTransfer.ID;
            }

            _Worker.Complete();

            LoadPool();
            LoadDoc();
        }

        private void MsLoad_Click(object sender, EventArgs e)
        {
            TransferBrowserSelector selector = new TransferBrowserSelector(_Worker.Transfers);
            DialogResult result = selector.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.ActiveTransfer = selector.SelectedValue;
                this.TransferDocumentChanged();
            }
        }

        private void MsClose_Click(object sender, EventArgs e)
        {
            this.ActiveTransfer = null;
            this.TransferDocumentChanged(); // This should really be automated. 6/27/21
        }

        private void MsDocEdit_Click(object sender, EventArgs e)
        {
            List<ListViewItem> selected = GetSelectedDocItems;

            if (selected.Count == 0)
                return;

            EditLocationForm loc = new EditLocationForm();
            DialogResult result = loc.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (var item in selected)
                {
                    TransferEntry entry = (TransferEntry)item.Tag;
                    entry.StoredLocation = loc.StoredLocation;

                    // This is extremely inefficent, but we need results. 
                    // TODO: Just look at it. 
                    if (loc.SetAll)
                    {
                        foreach (var order in this.ActiveTransfer.Entries.Where(r => r.ReceiverEntry.Job == entry.ReceiverEntry.Job))
                        {
                            order.StoredLocation = loc.StoredLocation;
                        }
                    }
                }

                _Worker.Complete();
            }

            this.LoadDoc();
        }

        private void Extract_Click(object sender, EventArgs e)
        {
            TransferExporterHtml export = new TransferExporterHtml("./Transfers");
            string path = export.Export(this.ActiveTransfer);

            Process.Start(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransferExporterHtml export = new TransferExporterHtml("./Transfers");
            string path = export.Export(_Worker.TransfersEntries.GetOrphans(), new Transfer("Exported Pool"), true);

            Process.Start(path);
        }

        private void MsDoc_DeleteClick(object sender, EventArgs e)
        {
            var selected = GetSelectedDocItems;
            foreach (var item in selected)
            {
                TransferEntry entry = (TransferEntry)item.Tag;
                entry.StoredLocation = "";
                entry.TransferID = -1;
            }

            _Worker.Complete();

            this.LoadDoc();
            this.LoadPool();
        }

        private void DocSet_Click(object sender, EventArgs e)
        {
            this.ActiveTransfer.Name = TransferNameTb.Text;
            _Worker.Complete();
        }

        private void MsTransferDelete_Click(object sender, EventArgs e)
        {
            if (ActiveTransfer.Entries.Count > 0)
            {
                MessageBox.Show("You cannot delete a transfer document with entries.", "Unable to delete.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show
                ("Are you sure you want to delete this transfer", "Delete transfer document",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;
            
            this._Worker.Transfers.Remove(this.ActiveTransfer);
            this._Worker.Complete();

            this.ActiveTransfer = null;
            this.LoadDoc();
        }

        private void TransferComplete_Click(object sender, EventArgs e)
        {
            if (this.ActiveTransfer.State == ReceiverStateType.Transferred)
                return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to set this transfer as complete? This cannot be undone.",
                "Set receiver as complete warning.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            this.ActiveTransfer.State = ReceiverStateType.Transferred;

            this._Worker.Transfers.Edit(this.ActiveTransfer);
            this._Worker.Complete();

            this.LoadDoc();
        }

        private void MsDocNotes_Click(object sender, EventArgs e)
        {
            TransferEntry entry = (TransferEntry)GetSelectedDocItems[0].Tag;

            NoteViewerForm viewer = new NoteViewerForm(entry);
            viewer.ShowDialog();

            _Worker.Complete();
        }
    }
}
