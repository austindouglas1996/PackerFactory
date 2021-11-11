using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.RPCP.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.RPCP.Forms
{
    public partial class ViewItemForm : Form
    {
        public ViewItemForm(IReceiverEntriesRepository repository, ReceiverEntry entry)
        {
            InitializeComponent();

            _Entry = entry;

            ReceiverEntryModelControl control = new ReceiverEntryModelControl(repository);
            control.Location = (new Point(12, 12));
            control.LoadEntry(entry);

            this.Controls.Add(control);
        }

        public ReceiverEntry Entry
        {
            get { return _Entry; }
        }
        private ReceiverEntry _Entry;
    }
}
