using System;
using System.Linq;
using System.Collections.Generic;
using PackerControlPanel.Data.Views;
using PackerControlPanel.Data.Repository;
using PackerControlPanel.UI;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Data.Common;
using PackerControlPanel.Core.Repository;

namespace PackerControlPanel.Data.Presenters
{
    public class DescriptionManPresenter : IPresenter<IDescriptionManView>
    {
        private IDescriptionManView _view;
        private IPartDescRepository _repository;

        public DescriptionManPresenter(IDescriptionManView view, IPartDescRepository repository)
        {
            _view = view;
            _repository = repository;

            InitializeView();
        }

        public IDescriptionManView View
        {
            get { return _view; }
        }

        private void InitializeView()
        {
            _view.AddPart += OnAddPart;
            _view.RemovePart += OnRemovePart;
            _view.EditPart += OnEditPart;
            _view.Descriptions = _repository.GetAll().ToList();
        }

        private void OnAddPart(object sender, AddPartDescEventArgs e)
        {
            if (_repository.Contains(e.PartDesc.PartName))
            {
                _view.ShowErrorMessage(new InvalidOperationException("A Part already exists by that name."));
                return;
            }

            _repository.Add(e.PartDesc);

            e.Handled = true;
            _repository.SaveChanges();
        }

        private void OnRemovePart(object sender, RemovePartDescEventArgs e)
        {
            if (!_repository.Contains(e.PartDesc.PartName))
            {
                _view.ShowErrorMessage(new InvalidOperationException("No Part exists by that name."));
                return;
            }

            _repository.Remove(e.PartDesc);

            e.Handled = true;
            _repository.SaveChanges();
        }

        private void OnEditPart(object sender, ModifyPartDescEventArgs e)
        {
            if (!_repository.Contains(e.PartDesc.PartName))
            {
                _view.ShowErrorMessage(new InvalidOperationException("No Part exists by that name."));
                return;
            }

            e.Handled = true;

            var partDesc = _repository.Get(e.PartDesc.ID);
            partDesc = e.PartDesc;

            _repository.Edit(e.PartDesc);
        }
    }
}