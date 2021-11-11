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

    public class PartAddPresenter : IPresenter<IPartAddView>
    {
        private IPartAddView _view;
        private IPartRepository _parts;

        public PartAddPresenter(IPartAddView view, IPartRepository parts)
        {
            View = view;
            _parts = parts;
        }

        public IPartAddView View
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
            this.View.AddPart += View_AddPart;
        }

        private void View_AddPart(object sender, AddPartEventArgs e)
        {
            if (_parts.FirstOrDefault(p => p.Name.ToLower() == e.Part.Name.ToLower()) != null)
            {
                _view.ShowErrorMessage(new ArgumentException("A part already exists by that name."));
                return;
            }

            _parts.Add(e.Part);
            e.Handled = true;
        }
    }
}
