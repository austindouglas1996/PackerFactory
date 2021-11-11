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
    public class PartOperationsPresenter : IPresenter<IPartOperationsView>
    {
        private IPartRepository _parts;
        private IPartOperationsView _view;

        public PartOperationsPresenter(IPartOperationsView view, IPartRepository parts)
        {
            this._parts = parts;
            this.View = view;
        }

        public IPartOperationsView View
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
            _view.Load += _view_LoadParts;
            _view.AddPart += _view_AddPart;
            _view.RemovePart += _view_RemovePart;
            _view.UpdatePart += _view_UpdatePart;
            _view.GetPart += _view_GetPart;
        }

        private void _view_GetPart(object sender, GetPartEventArgs e)
        {
            Part p = _parts.Get(e.RequestedPartID);
            e.Part = p;
        }

        private void _view_UpdatePart(object sender, ModifyPartEventArgs e)
        {
            _view.Model[e.Index] = e.Part;
        }

        private void _view_RemovePart(object sender, RemovePartEventArgs e)
        {
            _parts.Remove(e.Part);
        }

        private void _view_AddPart(object sender, AddPartEventArgs e)
        {
            if (!e.Handled)
            {
                _parts.Add(e.Part);
                e.Handled = true;
            }
        }

        private void _view_LoadParts(object sender, EventArgs e)
        {
            _view.Model = _parts.GetAll().ToList();
        }
    }
}
