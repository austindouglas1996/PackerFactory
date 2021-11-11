using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.UI.Views
{
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Presenters;
    public interface IJobOperationsView : IView<List<Job>>
    {
        JobOperationsPresenter Presenter { get; set; }
        
        event EventHandler<AddJobEventArgs> AddJob;
        event EventHandler<RemoveJobEventArgs> RemoveJob;
        event EventHandler<GetJobEventArgs> GetJob;
        event EventHandler<ModifyJobEventArgs> UpdateJob;
    }
}
