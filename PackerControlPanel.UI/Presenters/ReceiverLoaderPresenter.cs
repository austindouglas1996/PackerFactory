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

    public class ReceiverLoaderPresenter : IPresenter<IReceiverLoaderView>
    {
        private IReceiverLoaderView _View;
        private IReceiverRepository _Repository;

        public ReceiverLoaderPresenter(IReceiverLoaderView view, IReceiverRepository repository)
        {
            _Repository = repository;
           
        }

        public IReceiverLoaderView View
        {
            get { return View; }
            set
            {
                _View = value;
                SetupView(value);
            }
        }

        private void SetupView(IReceiverLoaderView view)
        {
            view.Load += View_Load;
        }

        private void View_Load(object sender, EventArgs e)
        {
            _View.Model = _Repository.GetAll().ToList();
        }
    }
}
