using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.UI.Presenters
{
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Views;

    public class JobDetailsPresenter : IPresenter<IJobDetailsView>
    {
        private IJobDetailsView _view;
        private IJobRepository _jobs;

        public JobDetailsPresenter(IJobDetailsView view, IJobRepository jobs)
        {
            View = view;
            _jobs = jobs;
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
            _jobs.Edit(e.Job);
        }
    }
}
