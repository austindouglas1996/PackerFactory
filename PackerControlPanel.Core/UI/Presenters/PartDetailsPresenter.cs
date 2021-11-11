using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;
using PackerControlPanel.Core.Domain;

namespace PackerControlPanel.Core.UI.Presenters
{

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
            _View.LoadPart += _view_LoadPart;
            _View.SaveChanges += _view_SaveChanges;
            _View.Remove += _view_Remove;
        }

        private void _view_LoadPart(object sender, PartEventArgs e)
        {
            View.PartID = _Part.ID;
            View.PartName = _Part.Name;
            View.PartDescription = _Part.Description;
            View.BoxCount = _Part.DefaultBoxCount;
            View.PackageType = _Part.PackingInfo.BoxType;
            View.BoxingDirections = _Part.PackingInfo.BoxingDirections;
            View.CreationTime = _Part.CreationDate;
            View.LastModifiedTime = _Part.LastModifiedDate;
        }

        private void _view_SaveChanges(object sender, ModifyPartEventArgs e)
        {
            _Part.ID = View.PartID;
            _Part.Name = View.PartName;
            _Part.Description = View.PartDescription;
            _Part.DefaultBoxCount = View.BoxCount;
            _Part.PackingInfo.BoxType = View.PackageType;
            _Part.PackingInfo.BoxingDirections = View.BoxingDirections;
            _Part.CreationDate = View.CreationTime;
            _Part.LastModifiedDate = View.LastModifiedTime;

            _Parts.Edit(_Part);
            _Parts.SaveChanges();
        }

        private void _view_Remove(object sender, RemovePartEventArgs e)
        {
            _Parts.Remove(e.Part);
        }
    }
}
