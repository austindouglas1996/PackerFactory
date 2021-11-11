using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.UI
{
    public interface IView
    {
        void ShowErrorMessage(Exception e);
        void UpdateView();

        event EventHandler Load;
    }
}
