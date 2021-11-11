using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Presenters
{
    public class JobOperationsPresenter : IPresenter<IJobOperationsView>
    {
        private IJobOperationsView _view;
        private IJobRepository _jobs;

        public JobOperationsPresenter(IJobOperationsView view, IJobRepository jobs)
        {
            View = view;
            _jobs = jobs;
        }

        public IJobOperationsView View
        {
            get { return _view; }
            set { _view = value; SetupView(); }
        }

        private void SetupView()
        {
            _view.Load += _view_LoadJobs;
            _view.AddJob += _view_AddJob;
            _view.RemoveJob += _view_RemoveJob;
            _view.GetJob += _view_GetJob;
            _view.UpdateJob += _view_UpdateJob;
        }

        private void _view_UpdateJob(object sender, ModifyJobEventArgs e)
        {
            _jobs.Edit(e.Job);
        }

        private void _view_GetJob(object sender, GetJobEventArgs e)
        {
            Job j = _jobs.Get(e.JobID);
            if (j == null)
                throw new ArgumentNullException("Invalid ID. Failed to find job.");

            e.Job = j;
        }

        private void _view_RemoveJob(object sender, RemoveJobEventArgs e)
        {
            _jobs.Remove(e.Job);
        }

        private void _view_AddJob(object sender, AddJobEventArgs e)
        {
            _view.Model.Add(e.Job);
            e.Handled = true;
        }

        private void _view_LoadJobs(object sender, EventArgs e)
        {
            _view.Model = _jobs.GetAll().ToList();
        }
    }
}
