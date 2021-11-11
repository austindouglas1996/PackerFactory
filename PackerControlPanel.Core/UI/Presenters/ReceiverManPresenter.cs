using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Presenters
{
    public class ReceiverManPresenter : IPresenter<IReceiverManView>
    {
        private IReceiverRepository _Repository;
        private IReceiverManView _View;

        public ReceiverManPresenter(IReceiverManView view, IReceiverRepository repository)
        {
            View = view;
            _Repository = repository;
        }

        public IReceiverManView View
        {
            get { return _View; }
            set
            {
                _View = value;
                SetupView(value);
            }
        }

        private void SetupView(IReceiverManView view)
        {
            _View.Load += _View_Load;
            _View.UpdateReceiver += _View_UpdateReceiver;
            _View.DeleteReceiver += _View_DeleteReceiver;
        }

        private void _View_DeleteReceiver(object sender, ReceiverEventArgs e)
        {
            _Repository.Remove(e.Receiver);
        }

        private void _View_UpdateReceiver(object sender, ReceiverEventArgs e)
        {
            _Repository.Edit(e.Receiver);
        }

        private void _View_Load(object sender, EventArgs e)
        {
            _View.Model = _Repository.GetAll().ToList();
        }
    }
}
