using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.UI.Views
{
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Presenters;
    public interface IJobDetailsView : IView<Job>
    {
        JobDetailsPresenter Presenter { get; set; }

        event EventHandler<ModifyJobEventArgs> SaveChanges;
        event EventHandler<JobOwnerChangeEventArgs> OwnerChanged;
        event EventHandler<ModifyJobEventArgs> Remove;
    }
}
