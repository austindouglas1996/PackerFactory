using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Presenters
{
    public class ReceiverEntryInfoPresenter : IPresenter<IReceiverEntryInfoView>
    {
        private IReceiverEntryInfoView _View;
        private IReceiverEntriesRepository _Repository;

        public ReceiverEntryInfoPresenter(IReceiverEntryInfoView view, IReceiverEntriesRepository repository)
        {
            this.View = view;
            this._Repository = repository;

            this.SetupView(view);
        }

        public IReceiverEntryInfoView View
        {
            get { return _View; }
            set
            {
                _View = value;
                SetupView(value);
            }
        }

        public void SetupView(IReceiverEntryInfoView view)
        {
            view.Load += View_Load;
            view.EntryChanged += View_EntryChanged;
        }

        private void View_EntryChanged(object sender, ReceiverEntryEventArgs e)
        {
            ReceiverEntry entry = e.Entry;
            View.ID = entry.ID;
            View.JobID = entry.JobID;
            View.PartID = entry.PartID;
            View.ReceiverID = entry.ReceiverID;
            View.PartName = entry.Part.Name;
            View.JobName = entry.Job.Name;
            View.Boxes = entry.Boxes;
            View.BoxCount = entry.BoxCount;
            View.StoredBin = entry.Location;
            View.CreationTime = entry.CreationDate;
        }

        private void View_Load(object sender, EventArgs e)
        {
            View.Model = null;
        }
    }
}
