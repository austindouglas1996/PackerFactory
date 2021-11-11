using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Views
{
    public interface IJobDetailsView : IView<Job>, IJobObjectView
    {
        JobDetailsPresenter Presenter { get; set; }

        event EventHandler<ModifyJobEventArgs> SaveChanges;
        event EventHandler<JobOwnerChangeEventArgs> OwnerChanged;
        event EventHandler<ModifyJobEventArgs> Remove;
    }
}
