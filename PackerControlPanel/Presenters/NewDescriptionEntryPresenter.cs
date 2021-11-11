using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Data.Common;
using PackerControlPanel.Data.Repository;
using PackerControlPanel.Data.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Presenters
{
    public class NewDescriptionEntryPresenter : IPresenter<INewDescriptionEntryView>
    {
        private IPartDescRepository _repository;
        private INewDescriptionEntryView _view;

        public NewDescriptionEntryPresenter(INewDescriptionEntryView view, IPartDescRepository repository)
        {
            this._repository = repository;
            this.InitView();
        }

        public INewDescriptionEntryView View
        {
            get { return _view; }
            set { _view = value; }
        }

        private void InitView()
        {
            _view.Accept += _view_Accept;
            _view.Cancel += _view_Cancel;
        }

        private void _view_Cancel(object sender, EventArgs e)
        {
        }

        private void _view_Accept(object sender, CanExecuteEventArgs e)
        {
            if (_repository.Contains(_view.PartName))
            {
                e.CanExecute = false;
                e.ErrorMsg = "A part already exists by that name.";
                return;
            }

            _repository.Add(_view.Model);

            e.CanExecute = true;
        }
    }
}
