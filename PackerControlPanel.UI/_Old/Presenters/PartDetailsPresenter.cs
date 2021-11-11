using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PackerControlPanel.UI.Presenters
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Views;

    public class PartDetailsPresenter : IPresenter<IPartDetailsView>
    {
        private IPartDetailsView _View;
        private IPartRepository _Parts;
        private Part _Part;

        public PartDetailsPresenter(IPartDetailsView view, IPartRepository parts, Part part)
        {
            this.View = view;
            this._Parts = parts;
            this._Part = part;

            this._view_LoadPart(this, new PartEventArgs(_Part));
        }

        public IPartDetailsView View
        {
            get { return this._View; }
            set
            {
                this._View = value;
                this.SetupView();
            }
        }

        private void SetupView()
        {
            _View.ParentChanged += _view_ParentChanged;
            _View.LoadPart += _view_LoadPart;
            _View.SaveChanges += _view_SaveChanges;
            _View.Remove += _view_Remove;
            _View.AddChild += _view_AddChild;
            _View.RemoveChild += _view_RemoveChild;
        }

        private void UpdateChildren()
        {
            View.PartChildren = _Parts.GetChildren(_Part);
        }

        private void _view_RemoveChild(object sender, PartEventArgs e)
        {
            if (e.Part.Parent == _Part)
            {
                _Parts.RemoveChild(_Part, e.Part);
            }

            _Parts.SaveChanges();
            UpdateChildren();
        }

        private void _view_AddChild(object sender, PartEventArgs e)
        {
            if (_Part.Parent == e.Part)
                throw new NotSupportedException("An entity cannot be the child and the parent.");

            _Parts.AddChild(_Part, e.Part);
            _Parts.SaveChanges();

            UpdateChildren();
        }

        private void _view_LoadPart(object sender, PartEventArgs e)
        {
            View.PartID = _Part.ID;
            View.PartName = _Part.Name;
            View.PartDescription = _Part.Description;
            View.ParentID = _Part.ParentID.HasValue ? _Part.ParentID.Value : -1;
            View.BoxCount = _Part.DefaultBoxCount;
            View.PackageType = _Part.PackingInfo.BoxType;
            View.BoxingDirections = _Part.PackingInfo.BoxingDirections;

            UpdateChildren();
        }

        private void _view_SaveChanges(object sender, ModifyPartEventArgs e)
        {
            _Parts.Edit(_Part);
            _Parts.SaveChanges();
        }

        private void _view_Remove(object sender, RemovePartEventArgs e)
        {
            _Parts.Remove(e.Part);
        }

        private void _view_ParentChanged(object sender, PartParentChangeEventArgs e)
        {
            _Parts.AddChild(this._Part, e.NewParent);
            _Parts.SaveChanges();

            e.ParentAccepted = true;
        }
    }
}
