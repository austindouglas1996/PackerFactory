using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Presenters
{
    public class JobDetailsPresenter : IPresenter<IJobDetailsView>
    {
        private IJobDetailsView _view;
        private IJobRepository _jobs;
        private Job _Job;

        public JobDetailsPresenter(IJobDetailsView view, IJobRepository jobs, Job job)
        {
            _jobs = jobs;
            _Job = job;
            View = view;
        }

        public IJobDetailsView View
        {
            get { return _view; }
            set
            {
                _view = value;
                SetupView();
            }
        }

        private void SetupView()
        {
            _view.SaveChanges += _view_SaveChanges;
            _view.Remove += _view_Remove;
            _view.OwnerChanged += _view_OwnerChanged;

            _view.JobID = _Job.ID;
            _view.PartID = _Job.PartID;
            _view.JobName = _Job.Name;
            _view.PartName = _Job.Part.Name;
            _view.TotalReceived = _Job.TotalReceived;
            _view.State = _Job.GetCurrentState().State;
            _view.IsGlobal = _Job.IsGlobal;
            _view.CreationTime = _Job.CreationDate;
            _view.ModifiedTime = _Job.LastModifiedDate;
            _view.CompletionTime = _Job.CompletionDate;
        }

        private void _view_OwnerChanged(object sender, JobOwnerChangeEventArgs e)
        {
            e.Job.Part = e.NewOwner;
        }

        private void _view_Remove(object sender, ModifyJobEventArgs e)
        {
            _jobs.Remove(e.Job);
        }

        private void _view_SaveChanges(object sender, ModifyJobEventArgs e)
        {
            e.Job.IsGlobal = View.IsGlobal;

            if (e.Job.GetCurrentState().State != View.State)
            {
                e.Job.SetState(View.State);
            }

            _jobs.Edit(e.Job);
        }
    }
}
