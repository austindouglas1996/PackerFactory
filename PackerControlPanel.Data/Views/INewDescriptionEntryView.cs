using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Views
{
    public interface INewDescriptionEntryView : IView<PartDescInfo>
    {
        string PartName { get; set; }
        string Description { get; set; }

        event CanExecuteEventHandler Accept;
        event EventHandler Cancel;
    }
}
